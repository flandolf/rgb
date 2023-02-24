using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateFPS : MonoBehaviour
{
    private TextMeshProUGUI text;
    public bool showFPS = true;

    private float fps;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            showFPS = !showFPS;
        }
        
        fps = 1f / Time.deltaTime;
        if (showFPS)
        {
            text.text = "FPS: " + Mathf.Round(fps);
        }
        else
        {
            text.text = "";
        }
        
        // delay
        new WaitForSeconds(0.5f);
    }
}
