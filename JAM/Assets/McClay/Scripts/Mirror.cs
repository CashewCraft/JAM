using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {

    public GameObject subject;

    Quaternion store;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        store = subject.transform.rotation;
        store.x = -store.x;

        transform.rotation = store;
	}
}
