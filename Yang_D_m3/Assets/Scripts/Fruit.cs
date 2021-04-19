using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
	private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
    	if (other.gameObject.tag == "Player") {
    		myAnimator.SetBool("isNearFruit", true);
    	}
    }

    private void OnTriggerExit(Collider other) {
    	if (other.gameObject.tag == "Player") {
    		myAnimator.SetBool("isNearFruit", false);
    	}
    }
}
