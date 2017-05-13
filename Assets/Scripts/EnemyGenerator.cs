using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

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
			InvokeRepeating ("Generate", 0, 30);
		}

	void Update () {

		//agent.SetDestination (target.position);
		/*
		Vector3 Apos = PlayerC.transform.position;
		Vector3 Bpos = Gene.transform.position;
		float dis = Vector3.Distance (Apos, Bpos);
		Debug.Log ("Distance : " + dis);
		*/
	}
	void Generate(){
			Instantiate (enemy, transform.position, transform.rotation);
		}
	}

