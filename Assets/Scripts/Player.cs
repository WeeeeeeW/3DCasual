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
    private bool blockedLeft, blockedRight;
    private GameObject playerSprite;
    private ParticleSystem landingParticle;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerSprite = gameObject.transform.GetChild(0).gameObject;
        landingParticle = GameObject.Find("Landing Particle").GetComponent<ParticleSystem>();
    }

   

    // Update is called once per frame
    void Update()
    {

        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.A) && !blockedLeft)
            {
                StartCoroutine(Jump("left"));
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), 5);
            }
            else if (Input.GetKeyDown(KeyCode.D) && !blockedRight)
            {
                StartCoroutine(Jump("right"));
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
        grounded = false;
        rigidbody.useGravity = false;
        float timer = 0f;
        switch (direction)
        {
            case "left":
                playerSprite.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                Target[0] = GameObject.Find("LeftJump").transform.position;
                Target[1] = GameObject.Find("LeftLand").transform.position;
                break;
            case "right":
                playerSprite.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                Target[0] = GameObject.Find("RightJump").transform.position;
                Target[1] = GameObject.Find("RightLand").transform.position;     
                break;
        }
        while (timer < .1f)
        {
            playerSprite.gameObject.transform.localScale = Vector3.Lerp(playerSprite.gameObject.transform.localScale, new Vector3(1, .7f, .7f), .4f);
            transform.position = Vector3.Lerp(transform.position, Target[0], 0.35f);
            timer += Time.deltaTime;
            yield return new WaitForSeconds(.01f);
        }
        timer = 0;
        while (timer < .15f)
        {
            rigidbody.useGravity = true;
            playerSprite.gameObject.transform.localScale = Vector3.Lerp(playerSprite.gameObject.transform.localScale, new Vector3(1, 1, 1), .4f);
            transform.position = Vector3.Lerp(transform.position, Target[1], 0.35f);
            timer += Time.deltaTime;
            yield return new WaitForSeconds(.01f);
        }
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Platform")
        {
            StopAllCoroutines();
            Debug.Log(collision.transform.name);
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

}
