using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollisionReporter : MonoBehaviour
{
    void OnCollisionEnter(Collision c) {
		foreach (ContactPoint contact in c.contacts) {		
			EventManager.TriggerEvent<BombBounceEvent, Vector3> (contact.point);
		}
    }
}