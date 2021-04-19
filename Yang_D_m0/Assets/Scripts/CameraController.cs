using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	private Vector3 offset;

    // Start is called before the first frame update
    void Start() {
        offset = transform.position - player.transform.position;
    }

    // Update runs every frame after everything is run after update
    void LateUpdate() {
    	// camera is moved into new position aligned with object
        transform.position = player.transform.position + offset;
    }
}
