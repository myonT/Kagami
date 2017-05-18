using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public GameObject enemy;
	//public GameObject Gene;  
	//public int keycount;
	//public int diss = 2;
	public Transform target;
	UnityEngine.AI.NavMeshAgent agent; 

	float dis;		
			
	//bool isCalled = false;		


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
	/*
	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "FPSControllers"){
			Debug.Log (GetComponent<Collider>().name);
			InvokeRepeating ("Generate", 0, 5);
		}
	}
	*/
	}

