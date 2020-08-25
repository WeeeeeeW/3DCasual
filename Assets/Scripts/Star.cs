using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 0.5f;
    public bool isFalling;
    // Start is called before the first frame update
    void Start()
    {
        pos1 = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        pos2 = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        isFalling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFalling)
        {
            transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 0.5f));
        }
       
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
           // Debug.Log("player");
            gameObject.SetActive(false);
            //Destroy(this);
        }
    }
}
