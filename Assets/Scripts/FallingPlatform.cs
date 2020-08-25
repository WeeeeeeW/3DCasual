using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Vector3 originPos;
    enum platform { quickSand, quickSandBroken }
    platform typeOfFallingPlatform;
    public bool blockJump;   
    void Start()
    {
        if (this.gameObject.name.Contains("FallingPlatform_2"))
        {
            typeOfFallingPlatform = platform.quickSandBroken;
        }
        else if (this.gameObject.name.Contains("FallingPlatform"))
        {
            typeOfFallingPlatform = platform.quickSand;
        }
        originPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {

            if (typeOfFallingPlatform == platform.quickSandBroken)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                Player._instance.jumping = true;
            }
            else if (typeOfFallingPlatform == platform.quickSand)
            {
                StartCoroutine("Falling");
            }
        }
    }
    private IEnumerator Falling()
    {
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
       
    }
}
