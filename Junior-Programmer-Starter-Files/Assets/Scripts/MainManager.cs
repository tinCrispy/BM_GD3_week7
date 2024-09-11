using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



    public class MainManager : MonoBehaviour
{
    public static MainManager instance;

    public Color TeamColor;
    // Start is called before the first frame update

    private void Awake()
    {
        //makes sure that there is always one game manager
        if (instance != null)
        {
            Destroy(gameObject);
        }

        //setting ourselves as the instance
        instance = this;

        //makes sure that the current game object is not destroyed when you load another scene
        DontDestroyOnLoad(gameObject);

        //Debug.Log(Application.persistentDataPath + "/savefile.json");

        LoadColor();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //creates a new class which declares a TeamColor variable;
    //serializable means the data can be turned in to bytes to be saved in your file directory (outside of the game window) 

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }
}
