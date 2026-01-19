using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class depthManager : MonoBehaviour
{
    public int TouchOrder;
    public int NoTouchOrder;
    private SpriteRenderer sRenderer;

    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.sRenderer.sortingOrder = TouchOrder;
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.sRenderer.sortingOrder = NoTouchOrder;
        }

    }
    
}
