using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3 boucestrength;
    public bool once = true;
    Vector3 currentPos;
    Vector3 targetPos;
    private void Start()
    {
        currentPos = transform.position;  
        targetPos = transform.position + new Vector3(0,-4,0);      
    }
    private void Update()
    {    
        if (gameObject.GetComponent<Rigidbody>().useGravity&& transform.position.y <= targetPos.y)
        {
            Destroy(gameObject);
        }
        //if (gameObject.transform.position.y == (12 - 2 * (Manager.instance.score - 2)) || gameObject.transform.position.y >= (12 - 2 * (Manager.instance.score - 2) - 0.2))
        //{
        //    if (transform.childCount > 0)
        //    {
        //        gameObject.transform.GetChild(0).GetComponent<Star>().isFalling = true;
        //        gameObject.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        //        gameObject.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
        //    }
        //    gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //    gameObject.GetComponent<Rigidbody>().useGravity = true;           
        //}      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {                   
           Invoke("PlatformFalling", 0.8f); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (once && other.transform.tag == "Player")
            StartCoroutine(platformbouce());
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Trigger")
    //    {

    //        if (transform.childCount > 0)
    //        {
    //            gameObject.transform.GetChild(0).GetComponent<Star>().isFalling = true;
    //            gameObject.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
    //            gameObject.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
    //        }
    //        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    //        gameObject.GetComponent<Rigidbody>().useGravity = true;
    //    }
    //}
    IEnumerator platformbouce()
    {
        once = false;
        Vector3 _desiredBouncePos = transform.position - boucestrength;
        Vector3 _originalPos = transform.position;
        while (transform.position.y - _desiredBouncePos.y > .01f)
        {
            transform.position = Vector3.Lerp(transform.position, _desiredBouncePos, .7f);
            yield return new WaitForSeconds(.01f);
        }
        while (_originalPos.y - transform.position.y > .01f)
        {
            transform.position = Vector3.Lerp(transform.position, _originalPos, .7f);
            yield return new WaitForSeconds(.01f);
        }
    }
     
    void PlatformFalling()
    {
        if (gameObject.transform.childCount > 0)
        {
            gameObject.transform.GetChild(0).GetComponent<Star>().isFalling = true;
            gameObject.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            gameObject.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
        }
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        GameObject[] Objects = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject go in Objects)
        {
            if (go.transform.position.y == currentPos.y)
            {
                if (go.gameObject.transform.childCount > 0)
                {
                    go.gameObject.transform.GetChild(0).GetComponent<Star>().isFalling = true;
                    go.gameObject.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                    go.gameObject.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
                }
                go.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                go.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }        
        }
        
    }
}
