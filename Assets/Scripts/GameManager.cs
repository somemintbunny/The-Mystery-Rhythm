using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public AudioSource music;
    public bool playing;
    public BeatScroller bS;
    public static GameManager instance;
    public int score;
    public int noteScoreGood;
    public int noteScoreBad;
    public int noteScorePerfect;
    public int combo;

    public float AvgOffset;
    public int SongNumber;
    public int Notehits;

    

    [SerializeField]
    private GameObject perfect;
    [SerializeField]
    private GameObject good;
    [SerializeField]
    private GameObject bad;
    [SerializeField]
    private GameObject ScorePoint;
    [SerializeField]
    private GameObject miss;

    // Start is called before the first frame update
    
    void Start()
    {
        instance = this;
        combo = 0;
    }

    // Update is called once per frame
    void Update()
    {
       Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "Hub")
        {
            if (!playing)
            {
                if (Input.anyKeyDown)
                {
                    playing = true;
                    bS.hasStarted = true;
                    music.Play();
                }
            }
        }

    }

    public void NoteHitPerfect()
    {

        score += noteScorePerfect;
        combo += 1;
        Notehits++;
        GameObject Perfect = Instantiate(perfect, ScorePoint.transform.position, transform.rotation);
    }
    public void NoteHitGood()
    {

        score += noteScoreGood;
        combo += 1;
        Notehits++;
        GameObject Good = Instantiate(good, ScorePoint.transform.position, transform.rotation);
    }
    public void NoteHitBad()
    {
        Notehits++;
        score += noteScoreBad;
        combo += 1;

        GameObject Bad = Instantiate(bad, ScorePoint.transform.position, transform.rotation);
    }
    public void NoteHit()
    {

        score += noteScoreGood;
    }
    public void NoteMissed()
    {
        combo = combo - combo;

        GameObject Miss = Instantiate(miss, ScorePoint.transform.position, transform.rotation);
    }

}
