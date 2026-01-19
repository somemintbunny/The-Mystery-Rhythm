using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TheScriptOfHold : MonoBehaviour
{

    public bool canBePressed;

    public KeyCode keyToPress;
    public int MidiKeyToPress;
    public float scorePotential;
    [SerializeField]
    public bool hasHit;


    // Start is called before the first frame update
    void Start()
    {
        hasHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyToPress))
        {
            if (canBePressed)
            {

                hasHit = true;
                GameManager.instance.NoteHit();
                gameObject.SetActive(false);


            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
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
