using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextRGB : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float speed = 1f; // Rainbow transition speed

    private float colorOffset; // Current color offset

    private void Update()
    {
        // Update the color offset based on time
        colorOffset += speed * Time.deltaTime;

        // Calculate the RGB values based on the color offset
        float r = Mathf.Sin(colorOffset * Mathf.PI * 2f) * 0.5f + 0.5f;
        float g = Mathf.Sin((colorOffset + 1f / 3f) * Mathf.PI * 2f) * 0.5f + 0.5f;
        float b = Mathf.Sin((colorOffset + 2f / 3f) * Mathf.PI * 2f) * 0.5f + 0.5f;

        // Set the textMeshPro color
        textMeshPro.color = new Color(r, g, b);
    }
}