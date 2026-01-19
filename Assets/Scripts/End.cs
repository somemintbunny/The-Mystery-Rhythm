using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour, IDataPersistence
{

    public float songOffset;
    // Start is called before the first frame update

    private void Start()
    {
        
        DataManager.instance.LoadGame();
        if (GameManager.instance.SongNumber == 0)
        {
            GameManager.instance.AvgOffset = 0;
        }
        else
        {
            GameManager.instance.AvgOffset = songOffset;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance.SongNumber == 0)
        {
            
            songOffset = GameManager.instance.AvgOffset /= GameManager.instance.Notehits;
            GameManager.instance.AvgOffset = songOffset;
            ShowOffset.instance.UpdateText();
            DataManager.instance.SaveGame();
        }
        else
        {
            if (other.tag == "Activator")
            {
                if (BackHome.instance.inStory == false)
                {
                    SceneManager.LoadScene(6);
                }
                else
                {
                    SceneManager.LoadScene(5);
                }
                
            }
        }

    }
    public void LoadData(GameData data)
    {
        
    }
    public void SaveData(ref GameData data)
    {
        data.songOffset = songOffset;
    }
}
