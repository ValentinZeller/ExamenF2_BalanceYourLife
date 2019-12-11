using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    
    const float duration = 30.0f;

    float t = 0f;
    Color color1, color2;

    void Start()
    {
        color1 = new Color(Random.Range(0.25f, 0.75f), Random.Range(0.25f, 0.75f), Random.Range(0.25f, 0.75f));
        Reset();
    }

    void Update()
    {
        Color color = Color.Lerp(color1, color2, t);
        t += Time.deltaTime / duration;
        Camera.main.backgroundColor = color;

        if (t >= 1)
        {
            Reset();
            t = 0f;
        }
    }

    private void Reset()
    {
        color1 = Camera.main.backgroundColor;
        color2 = new Color(Random.Range(0.25f, 0.75f), Random.Range(0.25f, 0.75f), Random.Range(0.25f, 0.75f));
        Color color = Color.Lerp(color1, color2, t);
    }
}
