using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour
{
    public static Player _instance { get; private set; }
    [SerializeField]
    private bool grounded;
    [SerializeField] private Vector3[] Target;
    private Rigidbody rigidbody;

    [SerializeField]
   // private bool blockedLeft, blockedRight;


    private bool blockedLeft, blockedRight,isSliding;
    public bool isJumping;
    private GameObject playerSprite;
    private ParticleSystem landingParticle;


    public bool jumping;

    private Vector3 leftJump, leftLand, rightJump, rightLand;

    int step = 0;

    public bool startgame;


    //private Vector3 leftJump, leftLand, rightJump, rightLand;
    //int step = 0;
    void Awake()
    {       
        _instance = this;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerSprite = gameObject.transform.GetChild(0).gameObject;
        landingParticle = GameObject.Find("Landing Particle").GetComponent<ParticleSystem>();

        jumping = false;
        startgame = false;

        isJumping = false;
        isSliding = false;

        leftJump = GameObject.Find("LeftJump").transform.position;
        leftLand = GameObject.Find("LeftLand").transform.position;
        rightJump = GameObject.Find("RightJump").transform.position;
        rightLand = GameObject.Find("RightLand").transform.position;
    }

   

    // Update is called once per frame
    void Update()
    {

       // Debug.Log("Blocked Left " + blockedLeft);
       // Debug.Log("Blocked Right " + blockedRight);

        if (grounded && Time.timeScale > 0)
        {
            if (Input.GetKeyDown(KeyCode.A) && !blockedLeft && !isJumping && !isSliding)
            {
                startgame = true;
                StartCoroutine(Jump("left"));
                step++;
                CheckSpawn();
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), 5);
            }
            else if (Input.GetKeyDown(KeyCode.D) && !blockedRight && !isJumping && !isSliding)
            {
                startgame = true;
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
        Manager.instance.score++;
        isJumping = true;
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
            timer += Time.smoothDeltaTime;
            yield return new WaitForSecondsRealtime(.01f);
        }
        timer = 0;
        while (timer < .1f)
        {
            rigidbody.useGravity = true;
            playerSprite.gameObject.transform.localScale = Vector3.Lerp(playerSprite.gameObject.transform.localScale, new Vector3(1, 1, 1), .4f);
            transform.position = Vector3.Lerp(transform.position, Target[1], 0.35f);
            timer += Time.smoothDeltaTime;
            yield return new WaitForSecondsRealtime(.01f);
        }
        Vector3 tempPos = transform.position;
        tempPos.x = Mathf.Round(tempPos.x);
        tempPos.y = Mathf.Round(tempPos.y);
        tempPos.z = Mathf.Round(tempPos.z);
        transform.position = tempPos;
        //Debug.Log(transform.position);
        leftJump = GameObject.Find("LeftJump").transform.position;
        leftLand = GameObject.Find("LeftLand").transform.position;
        rightJump = GameObject.Find("RightJump").transform.position;
        rightLand = GameObject.Find("RightLand").transform.position;
        isJumping = false;
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        waterTimer = 0;
        if (collision.transform.tag == "Platform")
        {
            grounded = true;
            landingParticle.transform.position = collision.GetContact(0).point;
            landingParticle.Play();
        }
        if (collision.transform.name.Contains("QuickSandBroken"))
        {          
            StartCoroutine("Destroy");
        }
    }
    float waterTimer = 0;
    private void OnCollisionStay(Collision collision)
    {
        if(waterTimer < Manager.instance.waterSliderTimer)
            waterTimer += Time.deltaTime;
        if (collision.transform.name.Contains("Water") && waterTimer >= Manager.instance.waterSliderTimer)
        {
            step++;
            CheckSpawn();
            switch (collision.transform.rotation.y)
            {
                case -1f:
                    StartCoroutine(waterSlide("right"));
                    break;
                default:
                    StartCoroutine(waterSlide("left"));
                    break; 
            }
        }
    }

    IEnumerator waterSlide(string direction)
    {
        isSliding = true;
        grounded = false;
        rigidbody.useGravity = false;
        float slideTimer = 0f;
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
        while (slideTimer < .1f)
        {
            transform.position = Vector3.Lerp(transform.position,new Vector3(Target[0].x,transform.position.y, Target[0].z), 0.35f);
            slideTimer += Time.deltaTime;
            yield return new WaitForSeconds(.01f);
        }
        slideTimer = 0;
        while (slideTimer < .15f)
        {
            rigidbody.useGravity = true;
            transform.position = Vector3.Lerp(transform.position, Target[1], 0.35f);
            slideTimer += Time.deltaTime;
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
        isSliding = false;
        yield return null;

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
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.5f);
        Dead();
    }
}
