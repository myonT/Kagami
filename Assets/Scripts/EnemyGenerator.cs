using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public GameObject enemy;
	public Transform target;
	UnityEngine.AI.NavMeshAgent agent; 

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find ("FPSControllers");
		target = player.transform;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	void Update () {
		agent.SetDestination (target.position);

	}

	void Generate(){
			Instantiate (enemy, transform.position, transform.rotation);
		}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "FPSControllers"){
			Debug.Log (GetComponent<Collider>().name);
			InvokeRepeating ("Generate", 0, 5);
		}
	}
	}

