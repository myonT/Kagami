using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript: MonoBehaviour {

	Transform[] points;
	Vector3 destination;
	UnityEngine.AI.NavMeshAgent agent; 


	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> (); 
		points = GameObject.FindWithTag ("point").transform.position;
		GotoNextPoint();
	}



	
	// Update is called once per frame
	void Update () {
		Vector3 points = GameObject.FindWithTag ("point").transform.position;
		//GameObject.FindWithTag ("point").transform.position = points; 
		//agent.SetDestination(destination);
		GotoNextPoint();
	}

	void GotoNextPoint(){
		int index = Random.Range(0,points.Length);
		destination = points[index];
		//agent.destination = points[destination].position;
		agent.SetDestination(destination);



	}
}