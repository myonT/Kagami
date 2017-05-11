using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public GameObject enemy;
	public GameObject Gene;   //時間があったら近づいてスポーン実装する
	public GameObject PlayerC;

	//public int diss = 2;

	float dis;

	//bool isCalled = false;


	// Use this for initialization
	void Start () {
		if (dis <= 15.0f) {
			InvokeRepeating ("Generate", 0, 30);
		}
		}
		/*
		switch(diss){
		case 1:
			Invoke ("Generate", 0, 7);
			break;
		case 2:
			CancelInvoke();
			break;
		}
		*/

	void Update () {

		Vector3 Apos = PlayerC.transform.position;
		Vector3 Bpos = Gene.transform.position;
		float dis = Vector3.Distance (Apos, Bpos);
		Debug.Log ("Distance : " + dis);
		/*
		if (dis <= 10.0f) {
			if(isCalled = false){
				if (isCalled = true) {
					InvokeRepeating ("Generate", 0, 7);
				}
			}
		}
		*/
	}

	/*
	void draw(){
		switch(diss){
		case 1:
			InvokeRepeating ("Generate", 0, 7);
			break;
		case 2:
			CancelInvoke();
			break;
		}
	}
	*/
		
	void Generate(){
			
			Instantiate (enemy, transform.position, transform.rotation);
		}
	}



	/*
	void OnTriggerStay(Collider other){
		if (other.gameObject.name == "FPScontroller") {
			other.gameObject.SendMessage ("Generate");
		}
		
	}

*/