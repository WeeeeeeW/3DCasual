﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool grounded;
    [SerializeField] private Vector3[] Target;
    private Rigidbody rigidbody;
    private bool blockedLeft, blockedRight;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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
        rigidbody.useGravity = false;
        switch (direction)
        {
            case "left":
                Target[0] = GameObject.Find("LeftJump").transform.position;
                Target[1] = GameObject.Find("LeftLand").transform.position;
                break;
            case "right":
                Target[0] = GameObject.Find("RightJump").transform.position;
                Target[1] = GameObject.Find("RightLand").transform.position;     
                break;
        }
        while (Vector3.Distance(transform.position, Target[0]) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, Target[0], 0.35f);
            yield return new WaitForSeconds(.01f);
        }
        while (Vector3.Distance(transform.position, Target[1]) > 0.1f)
        {
            rigidbody.useGravity = true;
            transform.position = Vector3.Lerp(transform.position, Target[1], 0.35f);
            yield return new WaitForSeconds(.01f);
        }
        yield return null;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Platform")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Platform")
        {
            grounded = false;
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
