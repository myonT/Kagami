using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public GameObject enemy;
	public Transform target;
	UnityEngine.AI.NavMeshAgent agent; 

	float dis;		
			
	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
			//if (dis <= 10.0f) {		
				InvokeRepeating ("Generate", 0, 30);		
			}


	void Update () {
		//agent.SetDestination (target.position);

	}

	void Generate(){
			Instantiate (enemy, transform.position, transform.rotation);
		}
	}

