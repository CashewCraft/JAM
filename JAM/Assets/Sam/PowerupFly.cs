using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupFly : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        Flight f = col.gameObject.GetComponent<Flight>();
        if (f != null)
        {
            f.canFly = true;
            Destroy(gameObject);
        }

    }
}
