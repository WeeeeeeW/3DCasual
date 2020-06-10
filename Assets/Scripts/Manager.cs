using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance { get; private set; }

    public List<GameObject> ListPlatforms;
    public List<int> ListNumber;

    public int count = 0;
    public int preRandom1 = 1;
    public int preRandom2 = 2;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        AddNumber();
        SpawnLand();
    }
    void Update()
    {
        
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
        //int random = Random.Range(0, 6);
        int random = RandomNumber();
        if (random == 0)
        {
          //  Instantiate(land_1, new Vector3(-4, -8, -4) + new Vector3(i*(-4), i * (-8), i * (-4)), Quaternion.Euler(0, -180, 0));
            GameObject instance = Instantiate(Resources.Load("Land(1)", typeof(GameObject)), new Vector3(-6, -12, -6) + new Vector3(i * (-6), i * (-12), i * (-6)), Quaternion.Euler(0, -180, 0)) as GameObject;
        }
        else if (random == 1)
        {
            GameObject instance = Instantiate(Resources.Load("Land(2)", typeof(GameObject)), new Vector3(-6, -12, -6) + new Vector3(i * (-6), i * (-12), i * (-6)), Quaternion.Euler(0, -180, 0)) as GameObject;

        }
        else if (random == 2)
        {
            GameObject instance = Instantiate(Resources.Load("Land(3)", typeof(GameObject)), new Vector3(-6, -12, -6) + new Vector3(i * (-6), i * (-12), i * (-6)), Quaternion.Euler(0, -180, 0)) as GameObject;

        }
        else if (random == 3)
        {
            GameObject instance = Instantiate(Resources.Load("Land(4)", typeof(GameObject)), new Vector3(-6, -12, -6) + new Vector3(i * (-6), i * (-12), i * (-6)), Quaternion.Euler(0, -180, 0)) as GameObject;

        }
        else if (random == 4)
        {
            GameObject instance = Instantiate(Resources.Load("Land(5)", typeof(GameObject)), new Vector3(-6, -12, -6) + new Vector3(i * (-6), i * (-12), i * (-6)), Quaternion.Euler(0, -180, 0)) as GameObject;

        } 
        else if (random == 5)
        {
            GameObject instance = Instantiate(Resources.Load("Land(6)", typeof(GameObject)), new Vector3(-6, -12, -6) + new Vector3(i * (-6), i * (-12), i * (-6)), Quaternion.Euler(0, -180, 0)) as GameObject;

        }
        else if (random == 6)
        {
            GameObject instance = Instantiate(Resources.Load("Land(7)", typeof(GameObject)), new Vector3(-6, -12, -6) + new Vector3(i * (-6), i * (-12), i * (-6)), Quaternion.Euler(0, -180, 0)) as GameObject;

        }
        else if (random == 7)
        {
            GameObject instance = Instantiate(Resources.Load("Land(8)", typeof(GameObject)), new Vector3(-6, -12, -6) + new Vector3(i * (-6), i * (-12), i * (-6)), Quaternion.Euler(0, -180, 0)) as GameObject;

        }

    }
    public void SpawnLand()
    {
        if (count  == 0)
        {           
            GameObject instance = Instantiate(Resources.Load("Land(0)", typeof(GameObject)), new Vector3(0, 0, 0), Quaternion.Euler(0, -180, 0)) as GameObject;
            count++;
        }
        else
        {
            RandomLand(count - 1);
            count++;
        }
    }
    int  RandomNumber()
    {
        int random = new int();
        if (ListNumber.Count == 0 )
        {
            AddNumber();
            random = Random.Range(0, 8);
            if (ListNumber.Contains(random))
            {
              //  Debug.Log(" " + random);
                ListNumber.Remove(random);
                //for (int i = 0; i < ListNumber.Count; i++)
                //{
                //    Debug.Log(" listNumber : " + ListNumber[i]);
                //}
            }
            else
            {
                RandomNumber();
            }
        }
        else
        {
            random = Random.Range(0, 8);
            if (ListNumber.Contains(random))
            {
               // Debug.Log(" " + random);
                ListNumber.Remove(random);
                //for (int i = 0; i < ListNumber.Count; i++)
                //{
                //    Debug.Log(" listNumber : " + ListNumber[i]);
                //}
            }
            else
            {
                RandomNumber();
            }
        }
        return random;
    }
    void AddNumber()
    {
        for (int i = 0; i < 8; i++)
        {
            ListNumber.Add(i);
        }
    }
}
