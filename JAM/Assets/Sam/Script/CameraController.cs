using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float cameraSpeed = 5f;

    GameObject player;

	// Use this for initialization
	void Awake () {
        player = FindObjectOfType<Bat>().gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 pos = Vector2.Lerp(transform.position, player.transform.position, Time.deltaTime * cameraSpeed);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
	}
}
