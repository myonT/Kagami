﻿using UnityEngine;
using System.Collections;

public class MovingEnemyScriptn : MonoBehaviour {


	public Transform target;
	UnityEngine.AI.NavMeshAgent agent; 


	//public GameObject enemy;
	public GameObject PlayerC;
	public float speed;
	GameObject player; //プレイヤー

	int enemyHP = 1;

	float dis;


	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("FPSController");
		Debug.Log (player);
		target = player.transform;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> (); 
	}

	// Update is called once per frame
	void Update () {

		Vector3 Apos = PlayerC.transform.position;
		Vector3 Bpos = transform.position;
		float dis = Vector3.Distance (Apos, Bpos);
		//Debug.Log ("Distance : " + dis);
		// 目的地をプレイヤーに設定する。
		if (dis <= 15.0f) {
			agent.SetDestination (target.position);//15より近づいたら動き始める
		}
		if (dis <= 7.0f) {
			agent.speed = 8;//7より近づいたら早くなる
		}
	}

	void Damage(){
		enemyHP -= 1;
		if(enemyHP == 0){
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.SendMessage ("PlayerDamage");
			//int PlayerHP = PlayerHPManager.Instance.playerHP;
			//PlayerHP--;
			Debug.Log (GetComponent<Collider>().name);
			Destroy(this.gameObject);			
		}
	}
}
