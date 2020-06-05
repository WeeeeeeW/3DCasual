using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public List<GameObject> ListPlatforms;
    public GameObject normalPlatform;
    public GameObject treePlatform;
    public GameObject lavaPlatform;
    public GameObject land_1;
    public GameObject land_2;
    public GameObject land_3;
    public GameObject land_4;
    public int count = 0;
    public int countFalling = 0;
    void Start()
    {
      // AddToList();
       InvokeRepeating("SpawnLand", 1, 0.6f);
    }
    void Update()
    {

       // PlatformMovement();
       
    }
    //void AddToList()
    //{
    //    GameObject[] Platforms = GameObject.FindGameObjectsWithTag("Platform");
    //    foreach (GameObject platform in Platforms)
    //    {
    //        ListPlatforms.Add(platform);
    //    }
    //}
    //void PlatformMovement()
    //{     
    //    foreach (GameObject platform in ListPlatforms)
    //    {
    //        platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(platform.transform.position.x, platform.transform.position.y + 2, platform.transform.position.z), 0.02f);

    //    }      
    //}
    //void SpawnPlatform()
    //{     
    //    if (count % 2 == 0)
    //    {
    //        GameObject objToSpawn1 = RandomSpawn(6);
    //        GameObject objToSpawn2 = RandomSpawn(7);
    //        GameObject objToSpawn3 = RandomSpawn(8);
    //        GameObject objToSpawn4 = RandomSpawn(9);
    //        ListPlatforms.Add(objToSpawn1); ListPlatforms.Add(objToSpawn2); ListPlatforms.Add(objToSpawn3); ListPlatforms.Add(objToSpawn4);
    //        count++;
    //    }
    //    else
    //    {
    //        GameObject objToSpawn1 = RandomSpawn(5);
    //        GameObject objToSpawn2 = RandomSpawn(6);
    //        GameObject objToSpawn3 = RandomSpawn(7);
    //        GameObject objToSpawn4 = RandomSpawn(8);
    //        GameObject objToSpawn5 = RandomSpawn(9);
    //        ListPlatforms.Add(objToSpawn1); ListPlatforms.Add(objToSpawn2); ListPlatforms.Add(objToSpawn3); ListPlatforms.Add(objToSpawn4);ListPlatforms.Add(objToSpawn5);
    //        count++;
    //    }
    //}
    //GameObject RandomSpawn(int i) 
    //{
    //    GameObject go;
    //    int random = Random.Range(0, 100);
    //    if (random <14)
    //    {
    //        go = Instantiate(treePlatform, new Vector3(ListPlatforms[ListPlatforms.Count - i].transform.position.x - 2, ListPlatforms[ListPlatforms.Count - i].transform.position.y - 4, ListPlatforms[ListPlatforms.Count - i].transform.position.z - 2), Quaternion.identity);
    //    }
    //    else if(random >= 15 && random <25)
    //    {
    //        go = Instantiate(lavaPlatform, new Vector3(ListPlatforms[ListPlatforms.Count - i].transform.position.x - 2, ListPlatforms[ListPlatforms.Count - i].transform.position.y - 4, ListPlatforms[ListPlatforms.Count - i].transform.position.z - 2), Quaternion.identity);
    //    }
    //    else
    //    {
    //        go = Instantiate(normalPlatform, new Vector3(ListPlatforms[ListPlatforms.Count - i].transform.position.x - 2, ListPlatforms[ListPlatforms.Count - i].transform.position.y - 4, ListPlatforms[ListPlatforms.Count - i].transform.position.z - 2), Quaternion.identity);
    //    }
    //    return go;
    //}
    //void PlatformFalling()
    //{
    //    if (countFalling %2==0)
    //    {
    //        for (int i = 0; i < 5; i++)
    //        {                
    //            ListPlatforms[i].GetComponent<Rigidbody>().useGravity = true;
    //            ListPlatforms.Remove(ListPlatforms[i]);
    //        }
    //    }
    //    else
    //    {
    //        for (int i = 0; i < 4; i++)
    //        {
    //            ListPlatforms[i].GetComponent<Rigidbody>().useGravity = true;
    //            ListPlatforms.Remove(ListPlatforms[i]);
    //        }
    //    }
    //}
    void RandomLand(int i)
    {                             
        int random = Random.Range(0, 100);
        if (random < 34)
        {
            Instantiate(land_1, new Vector3(-4, -8, -4) + new Vector3(i*(-4), i * (-8), i * (-4)), Quaternion.Euler(0, -180, 0));
        }
        else if (random >= 35 && random < 70)
        {
            Instantiate(land_2, new Vector3(-4, -8, -4) + new Vector3(i * (-4), i * (-8), i * (-4)), Quaternion.Euler(0, -180, 0));
        }
        else
        {
            Instantiate(land_3, new Vector3(-4, -8, -4) + new Vector3(i * (-4), i * (-8), i * (-4)), Quaternion.Euler(0, -180, 0));
        }

    }
    void SpawnLand()
    {
        if (count  == 0)
        {
            Instantiate(land_1, new Vector3(0,0,0), Quaternion.Euler(0, -180, 0));

            count++;
        }
        else
        {
            RandomLand(count - 1);
            count++;
        }
    }
}
