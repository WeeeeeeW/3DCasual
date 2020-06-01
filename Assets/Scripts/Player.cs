using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {


           // StartCoroutine(Jump("left"));

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), 5);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {

           // StartCoroutine(Jump("right"));

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 2), 5);

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

    //IEnumerator Jump(string direction)
    //{
    //    Vector3 desiredPos;
    //    switch (direction)
    //    {
    //        case "left":
    //            desiredPos = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
    //            while (Mathf.Abs(transform.position.x - desiredPos.x) > .1f)
    //            {
    //                transform.position = Vector3.Lerp(transform.position, desiredPos, 0.2f);
    //                yield return new WaitForSeconds(.01f);
    //            }
    //            break;
    //        case "right":
    //            desiredPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
    //            while (Mathf.Abs(transform.position.z - desiredPos.z) > .1f)
    //            {
    //                transform.position = Vector3.Lerp(transform.position, desiredPos, 0.2f);
    //                yield return new WaitForSeconds(.01f);
    //            }
    //            break;
    //    }
       
    //    yield return null;
    //}

}
