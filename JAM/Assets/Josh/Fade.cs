using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public float Rate = 0.05f;
    public bool Fading = true;

    public void Reset()
    {
        transform.localScale = new Vector3(0.1f, 0.1f, 0);
        Fading = true;
    }

    void Update()
    {
        if (Fading)
        {
            Color a = transform.GetComponent<SpriteRenderer>().color;
            a.a -= Rate;
            transform.GetComponent<SpriteRenderer>().color = a;
            if (a.a <= 0.1)
            {
                transform.GetComponent<SpriteRenderer>().color = Color.white;
                transform.localScale = new Vector3(0, 0, 0);
                Fading = false;
            }
        }
    }
}
