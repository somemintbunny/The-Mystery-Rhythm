using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int SongOneTopScore;
    public int SongOneFailCount;
    public bool storyMode;
    public float songOffset;
    public float xPos;
    public float yPos;
    //defaults

    public GameData()
    {
        this.SongOneTopScore = 0;
        this.SongOneFailCount = 0;
        this.songOffset = 0f;
        this.storyMode = false;
    }
}
