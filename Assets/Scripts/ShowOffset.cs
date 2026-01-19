using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowOffset : MonoBehaviour, IDataPersistence
{
    public Text ShowOffser;
    public float statedOffset;
    public static ShowOffset instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        try
        {
            DataManager.instance.LoadGame();
            ShowOffser.text = "Offset = " + statedOffset;
        }
        catch
        {
            statedOffset = BackHome.instance.Offset;
            ShowOffser.text = "Offset = " + BackHome.instance.Offset;
        }
        
        if (statedOffset == 0)
        {
            statedOffset = BackHome.instance.Offset;
            ShowOffser.text = "Offset = " + BackHome.instance.Offset;
        }
        Debug.Log("offset is " + statedOffset);
        
    }
    public void UpdateText()
    {
        ShowOffser.text = "Offset = " + GameManager.instance.AvgOffset;
        BackHome.instance.Offset = GameManager.instance.AvgOffset;
    }
    public void LoadData(GameData data)
    {
        this.statedOffset = data.songOffset;
    }
    public void SaveData(ref GameData data)
    {
        
    }
}
