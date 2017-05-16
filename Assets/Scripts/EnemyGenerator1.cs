using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator1 : MonoBehaviour {

	public GameObject enemy;
	//public GameObject Gene;   //時間があったら近づいてスポーン実装する
	public GameObject PlayerC;
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
		InvokeRepeating ("Generate", 0, 2);		

	}


	void Update () {
		//agent.SetDestination (target.position);
		if (FPSScript.coinc >= 2) {
			CancelInvoke ();
		}

	}

	void Generate(){
		Instantiate (enemy, transform.position, transform.rotation);
	}


	/*
	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "FPSControllers"){
			Debug.Log (GetComponent<Collider>().name);
			//Generate ();
			//InvokeRepeating ("Generate", 0, 10);			
		}
	}
	*/
}

