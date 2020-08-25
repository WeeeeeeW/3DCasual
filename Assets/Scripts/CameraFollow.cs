using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    private Vector3 desiredPosition;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && Player._instance.startgame == true)
        {
            transform.Translate(-transform.up * Time.deltaTime * speed, Space.World);
            if (Player._instance.jumping == true)
            {
                desiredPosition = player.transform.position + offset;
                if (desiredPosition.y < transform.position.y)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(desiredPosition.x, desiredPosition.y, desiredPosition.x), 1f * Time.deltaTime);
                }

            }
        }      
       
    }
}
