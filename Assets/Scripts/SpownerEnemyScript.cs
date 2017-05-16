using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownerEnemyScript : MonoBehaviour {

	public Transform target;
	UnityEngine.AI.NavMeshAgent agent; 

	GameObject player; //プレイヤー

	int enemyHP = 1;

	float dis;


	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find ("FPSController");
		target = player.transform;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> (); 
		}
		//player = GameObject.FindGameObjectWithTag ("Player");

	// Update is called once per frame
	void Update () {

	}

	void Damage(){
		enemyHP -= 1;
		if(enemyHP == 0){
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "FPScontroller"){
			other.gameObject.SendMessage ("PlayerDamage");
			Destroy(this.gameObject);			
		}
	}
}
