using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour
{
    public float speed = .1f;
    public float alphaDisplay = -1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            
            Color c = gameObject.GetComponent<Renderer>().material.color;
            alphaDisplay = c.a;
            float alpha = c.a;
            alpha -= speed * Time.deltaTime;
            alpha = System.Math.Max(alpha, 0);
            c.a = alpha;
            gameObject.GetComponent<Renderer>().material.color = c;
            if (alpha == 0) { fadeIn = false; }
            return;
        }
        if (fadeOut)
        {
            Color c = gameObject.GetComponent<Renderer>().material.color;
            alphaDisplay = c.a;
            float alpha = c.a;
            alpha += speed * Time.deltaTime;
            alpha = System.Math.Min(alpha, 1);
            c.a = alpha;
            gameObject.GetComponent<Renderer>().material.color = c;
            if (alpha == 1) { fadeOut = false; }
            return;
        }

    }
    private bool fadeIn = false;
    private void FadeIn()
    {
        fadeIn = true;
    }
    public bool fadeOut = false;
    public void FadeOut()
    {
        fadeOut = true;
    }
}
