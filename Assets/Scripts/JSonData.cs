using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSonData : MonoBehaviour
{
    public static JSonData _instance { get; private set; }
    string filename = "data.json";
    string path;
    public bool saved = false;
   // public UnityEngine.UI.Text debugText;
    public GameData gameData;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        path = Application.persistentDataPath + "/" + filename;
        Debug.Log(path);
      
    }
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveData()
    {
       // Debug.LogError("Save");
        gameData.score = Manager.instance.score;
        gameData.bestScore = Manager.instance.bestScore;
        gameData.starQuantity = Manager.instance.starQuantity;

        string contents = JsonUtility.ToJson(gameData, true);      
        //  Debug.Log(contents);
        System.IO.File.WriteAllText(path, contents);
    }
    public void LoadData()
    {
        if (System.IO.File.Exists(path))
        {          
            string contents = System.IO.File.ReadAllText(path);
            // Debug.Log(contents);
            gameData = JsonUtility.FromJson<GameData>(contents);         
            Manager.instance.bestScore = gameData.bestScore;
            Manager.instance.starQuantity = gameData.starQuantity;          
        }
        else
        {
            gameData = new GameData();           
        }
    }
}
