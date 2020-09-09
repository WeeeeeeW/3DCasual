using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3 boucestrength;
    public bool once = true;

    private void Update()
    {
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
    private void OnTriggerEnter(Collider other)
    {
        if (once && other.transform.tag == "Player")
            StartCoroutine(platformbouce());
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Trigger")
        {

            if (transform.childCount > 0)
            {
                gameObject.transform.GetChild(0).GetComponent<Star>().isFalling = true;
                gameObject.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                gameObject.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
            }
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
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
  
}
