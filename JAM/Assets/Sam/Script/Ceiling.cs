using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling : MonoBehaviour {

    Collider2D c;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.transform.GetComponent<Flight>() != null)
        {
            c = transform.parent.gameObject.GetComponentInChildren<Wall>().gameObject.GetComponent<Collider2D>();
            c.enabled = false;
        }
    }

    void OnCollisionExit2D()
    {
        c.enabled = true;
    }
}
