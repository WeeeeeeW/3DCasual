using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour
{
    [SerializeField]
    private bool grounded;
    [SerializeField] private Vector3[] Target;
    private Rigidbody rigidbody;
    private bool blockedLeft, blockedRight, jumping;
    private GameObject playerSprite;
    private ParticleSystem landingParticle;
    private Vector3 leftJump, leftLand, rightJump, rightLand;
    int step = 0;
  
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerSprite = gameObject.transform.GetChild(0).gameObject;
        landingParticle = GameObject.Find("Landing Particle").GetComponent<ParticleSystem>();
        jumping = false;

        leftJump = GameObject.Find("LeftJump").transform.position;
        leftLand = GameObject.Find("LeftLand").transform.position;
        rightJump = GameObject.Find("RightJump").transform.position;
        rightLand = GameObject.Find("RightLand").transform.position;
    }

   

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.A) && !blockedLeft && !jumping)
            {
                StartCoroutine(Jump("left"));
                step++;
                CheckSpawn();
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), 5);
            }
            else if (Input.GetKeyDown(KeyCode.D) && !blockedRight && !jumping)
            {
                StartCoroutine(Jump("right"));
                step++;
                CheckSpawn();
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 2), 5);


            }
        }
        //if (Input.touchCount == 1)
        //{
        //    var touch = Input.touches[0];
        //    if (touch.position.x < Screen.width / 2)
        //    {
        //        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), 5);
        //        Debug.Log("left");
        //    }
        //    else if (touch.position.x > Screen.width / 2)
        //    {
        //        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 2), 5);
        //        Debug.Log("right");
        //    }
        //}
    }



    IEnumerator Jump(string direction)
    {
        jumping = true;
        grounded = false;
        rigidbody.useGravity = false;
        float timer = 0f;
        switch (direction)
        {
            case "left":
                playerSprite.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                Target[0] = leftJump;
                Target[1] = leftLand;
                break;
            case "right":
                playerSprite.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                Target[0] = rightJump;
                Target[1] = rightLand; 
                break;
        }
        while (timer < .05f)
        {
            playerSprite.gameObject.transform.localScale = Vector3.Lerp(playerSprite.gameObject.transform.localScale, new Vector3(1, .7f, .7f), .4f);
            transform.position = Vector3.Lerp(transform.position, Target[0], 0.35f);
            timer += Time.deltaTime;
            yield return new WaitForSeconds(.01f);
        }
        timer = 0;
        while (timer < .1f)
        {
            rigidbody.useGravity = true;
            playerSprite.gameObject.transform.localScale = Vector3.Lerp(playerSprite.gameObject.transform.localScale, new Vector3(1, 1, 1), .4f);
            transform.position = Vector3.Lerp(transform.position, Target[1], 0.35f);
            timer += Time.deltaTime;
            yield return new WaitForSeconds(.01f);
        }
        Vector3 tempPos = transform.position;
        tempPos.x = Mathf.Round(tempPos.x);
        tempPos.y = Mathf.Round(tempPos.y);
        tempPos.z = Mathf.Round(tempPos.z);
        transform.position = tempPos;
        leftJump = GameObject.Find("LeftJump").transform.position;
        leftLand = GameObject.Find("LeftLand").transform.position;
        rightJump = GameObject.Find("RightJump").transform.position;
        rightLand = GameObject.Find("RightLand").transform.position;
        jumping = false;
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Platform")
        {
            grounded = true;
            landingParticle.transform.position = collision.GetContact(0).point;
            landingParticle.Play();
        }
    }
    public void setBlock(string _blockedSide,bool _isBlocked)
    {
        switch(_blockedSide)
        {
            case "left":
                blockedLeft = _isBlocked;
                break;
            case "right":
                blockedRight = _isBlocked;
                break;
        }
    }
    void CheckSpawn(){
        if (step == 4)
        {
            step = 0;
           Manager.instance.SpawnLand();
        }
    }

    void Dead()
    {
        Destroy(this.gameObject);
    }
}
