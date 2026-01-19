using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer sRenderer;
    public Sprite defaultImage;
    public Sprite imagePress;

    public KeyCode keyToPress;
    public int MidiKeyToPress;

    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyToPress))
        {
            sRenderer.sprite = imagePress;
        }
        else
        {
            sRenderer.sprite = defaultImage;
        }

    }
}
