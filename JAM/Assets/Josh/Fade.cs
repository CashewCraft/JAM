using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public float Rate = 0.05f;

    void Update()
    {
        Color a = transform.GetComponent<SpriteRenderer>().color;
        a.a -= Rate;
        transform.GetComponent<SpriteRenderer>().color = a;
        if (a.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
