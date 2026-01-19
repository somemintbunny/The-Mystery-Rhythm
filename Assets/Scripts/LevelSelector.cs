using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour, IDataPersistence
{
    private bool selected;
    private SpriteRenderer sRenderer;
    public Sprite deselectedImage;
    public Sprite selectedImage;
    public int SceneToGoTo;
    private bool sMode = true;
    public float dist;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selected == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                BackHome.instance.playerXPos = TopDownEdition.instance.xPos;
                BackHome.instance.playerYPos = TopDownEdition.instance.yPos;
                SceneManager.LoadScene(SceneToGoTo);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            
            sRenderer.sprite = selectedImage;
            selected = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sRenderer.sprite = deselectedImage;
            selected = false;
        }

    }
    public void LoadData(GameData data)
    {
        sMode = data.storyMode;
    }
    public void SaveData(ref GameData data)
    {
        data.storyMode = sMode;
    }
}
