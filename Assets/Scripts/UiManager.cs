using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public Text scoreHolder;
    public Text comboHolder;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreHolder.text = "score: " + GameManager.instance.score;
        comboHolder.text = "Combo: " + GameManager.instance.combo;
    }
}
