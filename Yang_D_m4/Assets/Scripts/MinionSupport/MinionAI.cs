using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class MinionAI : MonoBehaviour
{
    public GameObject[] waypoints;
    private NavMeshAgent myNavMeshAgent;
    private Animator anim;
    public int currWaypoint;
    public AIState aiState;
    public GameObject movingWaypoint;
    private VelocityReporter velocity;
    private Vector3 futureTarget;

    public enum AIState {
      Moving,
      Chasing
    }

    private void setNextWaypoint() {
      if (waypoints.Length == 0) {
        Debug.LogError("ERROR: Array is of zero length.");
      }
      currWaypoint++;
      if (currWaypoint < waypoints.Length) { 
      	myNavMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
      }
    }

    // Start is called before the first frame update
    void Start()
    {
      myNavMeshAgent = this.GetComponent<NavMeshAgent>();
      myNavMeshAgent.speed = 5.0f;
      anim = this.GetComponent<Animator>();
      velocity = movingWaypoint.GetComponent<VelocityReporter>();
      aiState = AIState.Moving;
      currWaypoint = -1;
      setNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
    switch (aiState) {
      case AIState.Moving:
        anim.SetFloat("vely", myNavMeshAgent.velocity.magnitude / myNavMeshAgent.speed);
        if (myNavMeshAgent.pathPending != true && myNavMeshAgent.remainingDistance < 0.001) {
          setNextWaypoint();
        }
        // if you're close enough go to other state
        if (currWaypoint == waypoints.Length) {
      		aiState = AIState.Chasing;
      	}	
      break;

      case AIState.Chasing:
        // put the chasing/prediction part
        // Once you're done and want to go back:
      	// aiState = AIState.Moving;
        anim.SetFloat("vely", myNavMeshAgent.velocity.magnitude / myNavMeshAgent.speed);
      	Vector3 targetPosition = GameObject.Find("movingWaypoint").transform.position;
        float dist = Vector3.Distance(movingWaypoint.transform.position, myNavMeshAgent.transform.position);
        float lookAheadT = dist / myNavMeshAgent.speed;
        futureTarget = targetPosition + (lookAheadT * velocity.velocity);
      	myNavMeshAgent.SetDestination(futureTarget);
      	if (myNavMeshAgent.pathPending != true && myNavMeshAgent.remainingDistance < 1.2) {
      	  currWaypoint = -1;
          aiState = AIState.Moving;
        }

      break;
    }
  }
}
