using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackHome : MonoBehaviour, IDataPersistence
{
    public int SceneReturner;
    public bool inStory;
    public float playerXPos;
    public float playerYPos;
    public static BackHome instance;
    public float Offset;
    void Awake()
    {
      DontDestroyOnLoad(this.gameObject);  
    }
    void Start()
    {
        instance = this;
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Scene scene = SceneManager.GetActiveScene();



            if (inStory == true && scene.name != "Hub" && scene.name != "Freeplay" && scene.name != "Freeplay2")
            {
                SceneManager.LoadScene(5);
                if (GameManager.instance.SongNumber == 0)
                {
                    DataManager.instance.SaveGame();
                }
            }
            else
            {
                if (scene.name == "Freeplay" || scene.name == "Freeplay2")
                {
                    
                    DataManager.instance.SaveGame();
                    Application.Quit();
                }
                if (scene.name == "Hub")
                {
                    DataManager.instance.SaveGame();
                }

                if (GameManager.instance.SongNumber == 0)
                {
                    DataManager.instance.SaveGame();
                    SceneManager.LoadScene(6);
                }
                SceneManager.LoadScene(6);
            }
            
            

        }

    }
    public void GetPoos()
    {
        
    }
    public void LoadData(GameData data)
    {

    }
    public void SaveData(ref GameData data)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Calibration")
        {
            data.songOffset = GameManager.instance.AvgOffset;
        }
        data.xPos = playerXPos;
        data.yPos = playerYPos;
        
    }
}
