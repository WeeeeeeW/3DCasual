using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    private Vector3 desiredPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        desiredPosition = player.transform.position + offset;
        if(desiredPosition.y < transform.position.y)
        {
            transform.position = Vector3.Lerp(transform.position,new Vector3(desiredPosition.x,desiredPosition.y,desiredPosition.x),0.8f * Time.deltaTime);
        }
    }
}
