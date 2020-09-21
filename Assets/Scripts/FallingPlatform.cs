using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Player player;
    Vector3 originPos;
    enum platform { quickSand, quickSandBroken }
    platform typeOfFallingPlatform;
    public bool blockJump;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameObject.transform.GetComponent<Platform>().once = false;
        //if (this.gameObject.name == "QuickSandbroken")
        //{
        //    typeOfFallingPlatform = platform.quickSandBroken;
        //}
        //else if (this.gameObject.name == "QuickSand")
        //{
        //    typeOfFallingPlatform = platform.quickSand;
        //}
        //originPos = gameObject.transform.position;
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //originPos = transform.position;
    }
    void Update()
    {
        if ((originPos.y - transform.position.y) > 3)
        {
            // player.transform.SendMessage("Dead");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            //if (typeOfFallingPlatform == platform.quickSandBroken)
            //{
            //    gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //    gameObject.GetComponent<Rigidbody>().useGravity = true;
            //    Player._instance.jumping = true;
            //}
            //else if (typeOfFallingPlatform == platform.quickSand)
            //{
            //   StartCoroutine("Falling");
            //}

            //StartCoroutine("Falling");
            Invoke("PlatformFalling",0.1f);
        }
        //{           
        //    gameObject.GetComponent<Rigidbody>().useGravity = true;
        //}
    }
    //private IEnumerator Falling()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    gameObject.GetComponent<Rigidbody>().isKinematic = false;
    //    gameObject.GetComponent<Rigidbody>().useGravity = true;

    //}
    void PlatformFalling()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
