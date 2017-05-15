using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript: MonoBehaviour {

	Transform[] points;
	//Vector3[] points;
	//public Vector3[] ;
	Vector3 destination;
	UnityEngine.AI.NavMeshAgent agent; 


	// Use this for initialization
	void Start () {
		
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> (); 
		GotoNextPoint();
	
	}
	
	// Update is called once per frame
	void Update () {
		points = GameObject.FindWithTag ("point").transform.position;
		GameObject.FindWithTag ("point").transform.position = points; 
		//if (agent.remainingDistance < 20.0f)
		//agent.SetDestination(destination);
		GotoNextPoint();
	}
		
	void GotoNextPoint(){
		int index = Random.Range(0,points.Length);
		destination = points[index];
		agent.SetDestination(destination);
	}

}