using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class ChartLoader : MonoBehaviour, IDataPersistence
{
    public TextAsset chartCSV;
    int[,] SoH;
    public float offset;
    public int song; 
//sdshjdsafh
    public GameObject down;
    public GameObject left;
    public GameObject up;
    public GameObject right;
    public GameObject Hold1;
    public GameObject Hold2;
    public GameObject Hold3;
    public GameObject Hold4;
    public GameObject End;


    public float scale;
    public int notes;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "snailtrail")
        {
            scale = 0.5f;
        }
        if (song != 0)
        {
            try
            {
                DataManager.instance.LoadGame();
            }
            catch
            {
                offset = BackHome.instance.Offset;
            }

        }
        else
        {
            offset = 0;
        }
        string[] lines = chartCSV.text.Split('\n'); // cut file in new lines
        int chartSize = lines.Length - 1;

        SoH = new int[chartSize, chartSize];

        for (int i = 0; i < chartSize; i++)
        {
            string[] mapRow = lines[i].Split(',');

            for (int j = 0; j < notes; j++)
            {
                if (!int.TryParse(mapRow[j], out SoH[i, j]))
                {
                    SoH[i, j] = 0;
                    Debug.Log("tast");
                }
            }

        }

        for (int row = 0; row < chartSize; row++)
        {
            for (int col = 0; col < chartSize; col++)
            {
                if (SoH[row, col] == 1)
                {
                    GameObject clone = Instantiate(left,

                        new Vector2(SoH[row, col], (row * scale) + offset),
                        Quaternion.identity);
                    clone.transform.parent = GameObject.Find("NotesHandler").transform;
                    clone.transform.localScale = new Vector2(1, 1);
                }
                if (SoH[row, col] == 2)
                {
                    GameObject clone = Instantiate(up,
                        new Vector2(SoH[row, col], (row * scale) + offset),
                        Quaternion.identity);
                    clone.transform.parent = GameObject.Find("NotesHandler").transform;
                    clone.transform.localScale = new Vector2(1, 1);
                }
                if (SoH[row, col] == 3)
                {
                    GameObject clone = Instantiate(down,
                        new Vector2(SoH[row, col], (row * scale) + offset),
                        Quaternion.identity);
                    clone.transform.parent = GameObject.Find("NotesHandler").transform;
                    clone.transform.localScale = new Vector2(1, 1);
                }
                if (SoH[row, col] == 4)
                {
                    GameObject clone = Instantiate(right,
                        new Vector2(SoH[row, col], (row * scale) + offset),
                        Quaternion.identity);
                    clone.transform.parent = GameObject.Find("NotesHandler").transform;
                    clone.transform.localScale = new Vector2(1, 1);
                }
                if (SoH[row, col] == 5)
                {
                    GameObject clone = Instantiate(Hold1,
                        new Vector2(col + 1, (row * scale) + offset),
                        Quaternion.identity);
                    clone.transform.parent = GameObject.Find("NotesHandler").transform;
                    clone.transform.localScale = new Vector2(1, 1);
                }
                if (SoH[row, col] == 6)
                {
                    GameObject clone = Instantiate(Hold2,
                        new Vector2(col + 1, (row * scale) + offset),
                        Quaternion.identity);
                    clone.transform.parent = GameObject.Find("NotesHandler").transform;
                    clone.transform.localScale = new Vector2(1, 1);
                }
                if (SoH[row, col] == 7)
                {
                    GameObject clone = Instantiate(Hold3,
                        new Vector2(col + 1, (row * scale) + offset),
                        Quaternion.identity);
                    clone.transform.parent = GameObject.Find("NotesHandler").transform;
                    clone.transform.localScale = new Vector2(1, 1);
                }
                if (SoH[row, col] == 8)
                {
                    GameObject clone = Instantiate(Hold4,
                        new Vector2(col + 1, (row * scale) + offset),
                        Quaternion.identity);
                    clone.transform.parent = GameObject.Find("NotesHandler").transform;
                    clone.transform.localScale = new Vector2(1, 1);
                }
                if (SoH[row, col] == 9)
                {
                    GameObject clone = Instantiate(End,
                        new Vector2(col + 1, (row * scale) + offset),
                        Quaternion.identity);
                    clone.transform.parent = GameObject.Find("NotesHandler").transform;
                    clone.transform.localScale = new Vector2(1, 1);
                }
            }
        }
    }
    public void LoadData(GameData data)
    {
        this.offset = data.songOffset;
    }
    public void SaveData(ref GameData data)
    {

    }
}
