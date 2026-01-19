using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class InteractibleEntity : MonoBehaviour
{
    public bool hasDialogue;
    public GameObject TheDialogue;
    // Start is called before the first frame update
    public GameObject Player;
    float dist;
    bool selected;
        public GameObject activeObject;
        public string Searcher;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        activeObject = GameObject.Find("ObjectYouAreCheckingFor");
    }
    // Update is called once per frame
    void Update()
    {
        if (selected == true && Input.GetKeyDown(KeyCode.E))
        {
            if (GameObject.Find(Searcher))
            {
                Debug.Log("Exists");
            }
            else
            {
                GameObject clone = Instantiate(TheDialogue);
            }
            
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dist = transform.position.y - Player.transform.position.y;
            if (dist < 1)
            {
                selected = true;
            
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            selected = false;
        }

    }
    
}
