using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFPS : MonoBehaviour
{
    public float fps;
    public TMPro.TMP_Text fpsText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("ShowFPS") == 1)
        {
            fps = 1.0f / Time.deltaTime;
            fpsText.text = "FPS: " + (int)fps;
        }
        if (PlayerPrefs.GetInt("ShowFPS") == 0)
        {
            fpsText.text = "";
        }
    }

}
