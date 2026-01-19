using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ToClick : MonoBehaviour
{
    public Button Accept;
    public int SceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (SceneToLoad == 5)
        {
            BackHome.instance.inStory = true;
        }
        else
        {
            BackHome.instance.inStory = false;
        }
        SceneManager.LoadScene(SceneToLoad);
    }
}
