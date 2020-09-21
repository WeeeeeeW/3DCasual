using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform_2 : MonoBehaviour
{
    Player player;
    Vector3 originPos;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameObject.transform.GetComponent<Platform>().once = false;
    }
    void Update()
    {
        if ((originPos.y - transform.position.y) > 3 )
        {
           // player.transform.SendMessage("Dead");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            player.isJumping = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;           
           // collision.transform.SendMessage("Dead");
            //StartCoroutine("Dead");
        }
    }
    private IEnumerator Dead()
    {
        yield return new WaitForSeconds(2f);
       
    }
}
