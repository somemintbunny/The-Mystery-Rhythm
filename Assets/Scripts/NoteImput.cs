using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NoteImput : MonoBehaviour
{

    public bool canBePressed;

    public KeyCode keyToPress;
    public int MidiKeyToPress;
    public float scorePotential;
    [SerializeField]
    public bool hasHit;
    public GameObject Activator;
    public float dist;
    // Start is called before the first frame update
    void Start()
    {
        hasHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {

                hasHit = true;
                dist = transform.position.y -1.2f - Activator.transform.position.y;

                //    if (Activator.transform.position.y > this.transform.position.y)
                //    {
                //        dist *= -1f;
                //    }
            
                Debug.Log("dist = " + dist);
                if (dist < 0.15f && dist > -0.15f)
                {
                    GameManager.instance.NoteHitPerfect();
                }
                else if (dist < 0.3f && dist > -0.3f)
                {
                    GameManager.instance.NoteHitGood();
                }
                else if (dist < 0.5f && dist > -0.5f)
                {
                    GameManager.instance.NoteHitBad();
                }
                else
                {
                    GameManager.instance.NoteMissed();
                }
                    GameManager.instance.AvgOffset += dist;
                    gameObject.SetActive(false);


            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            if (hasHit == false)
            {
                canBePressed = false;
                gameObject.SetActive(false);
                GameManager.instance.NoteMissed();
            }

        }
    }

    
}
