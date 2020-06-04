using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCheck : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Platform")
        {
            if (this.name.Contains("Left"))
            {
                player.setBlock("left", true);
            }
            else if (this.name.Contains("Right"))
            {
                player.setBlock("right", true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Platform")
        {
            if (this.name.Contains("Left"))
            {
                player.setBlock("left", false);
            }
            else if (this.name.Contains("Right"))
            {
                player.setBlock("right", false);
            }
        }
    }
}
