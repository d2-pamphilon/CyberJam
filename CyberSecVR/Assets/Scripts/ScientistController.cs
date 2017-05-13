using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScientistController : MonoBehaviour {

    [SerializeField]
    List<GameObject> waypoints;
    int currentWaypoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Animator>().SetFloat("Speed", GetComponent<Rigidbody>().velocity.magnitude);
		if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) < 1.0f)
        {
            currentWaypoint = currentWaypoint < waypoints.Count - 1 ? currentWaypoint + 1 : 0;
        }
        GetComponent<NavMeshAgent>().destination = waypoints[currentWaypoint].transform.position;
	}
}
