using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHiding : MonoBehaviour {

	// Use this for initialization
	void Start() {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
            r.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
