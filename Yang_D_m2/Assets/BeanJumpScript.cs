using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanJumpScript : MonoBehaviour {

	private Rigidbody rb;
	private bool canJump;
	private float jumpForce;

    // Start is called before the first frame update
    void Start() {
    	//canJump = true;
        rb = GetComponent<Rigidbody>();
        jumpForce = Random.Range(50f, 100f);
    }

    private void OnCollisionEnter(Collision otherObj) {
    	if (otherObj.gameObject.tag == "ground") {
    		canJump = true;
    	}
    }

    private void OnCollisionExit(Collision otherObj) {
    	if (otherObj.gameObject.tag == "ground") {
    		canJump = false;
    	}
    }

    // FixedUpdate runs 0 - several times per frame depending on how many physics frames/sec are set in the time settings 
    void FixedUpdate() {
        if (canJump == true) {
        	rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
