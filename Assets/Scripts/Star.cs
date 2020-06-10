using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        pos1 = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        pos2 = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 0.5f));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
