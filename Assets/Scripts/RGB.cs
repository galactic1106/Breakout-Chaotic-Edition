using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGB : MonoBehaviour
{
    public GameObject[] gos;
    private float lastColorChange;
    public float colorChageSpeed = 0.1f;
    private Color compressedColor;
    // Start is called before the first frame update
    void Start()
    {
        lastColorChange = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time - lastColorChange > colorChageSpeed)
        {
            RGBLoop();
            compressedColor=new Color(Compress(r), Compress(g), Compress(b));
            foreach (GameObject go in gos) 
            {
                if(go.GetComponent<SpriteRenderer>()!=null)
                {
                    go.GetComponent<SpriteRenderer>().material.color=compressedColor;
                    go.GetComponent<SpriteRenderer>().material.SetColor("_EmissionColor", compressedColor);
                }
                else if(go.GetComponent<Image>()!=null)
                    go.GetComponent<Image>().color = compressedColor;
            }
        }

    }

    private int r = 255, g = 0, b = 0;
    public int offset = 100;
    enum Stati { s1, s2, s3, s4, s5, s6 }
    Stati stato = Stati.s1;
    void RGBLoop()
    {
        switch (stato)
        {
            case Stati.s1:
                if (r == 255 && g == 255) stato = Stati.s2;
                else
                {
                    g += offset;
                    if (g > 255) g = 255;
                }
                break;

            case Stati.s2:
                if (r == 0 && g == 255) stato = Stati.s3;
                else
                {
                    r -= offset;
                    if (r < 0) r = 0;
                }
                break;

            case Stati.s3:
                if (g == 255 && b == 255) stato = Stati.s4;
                else
                {
                    b += offset;
                    if (b > 255) b = 255;
                }
                break;

            case Stati.s4:
                if (b == 255 && g == 0) stato = Stati.s5;
                else
                {
                    g -= offset;
                    if (g < 0) g = 0;
                }
                break;

            case Stati.s5:
                if (b == 255 && r == 255) stato = Stati.s6;
                else
                {
                    r += offset;
                    if (r > 255) r = 255;
                }
                break;

            case Stati.s6:
                if (r == 255 && b == 0) stato = Stati.s1;
                else
                {
                    b -= offset;
                    if (b < 0) b = 0;
                }
                break;
        }
    }

    private float Compress(int n)
    {
        //1:255=x:n   x=n/255
        return (float)n / 255.0f;
    }
}
