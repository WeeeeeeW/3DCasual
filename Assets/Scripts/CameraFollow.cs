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
        speed = 2f;
        Debug.Log(Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && Player._instance.startgame == true)
        {
            transform.Translate(-transform.up * Time.deltaTime * speed, Space.World);
            Vector3 tmpPos = Camera.main.WorldToScreenPoint(player.transform.position);
            // Debug.Log(tmpPos.y);
            if (tmpPos.y < Screen.height / 2)
            {
                // Debug.Log("a");  
                desiredPosition = player.transform.position + offset;
                if (desiredPosition.y < transform.position.y)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(desiredPosition.x, desiredPosition.y, desiredPosition.x), 2f * Time.deltaTime);
                }
            }        
        }
    }
}
