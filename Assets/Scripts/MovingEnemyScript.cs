using UnityEngine;
using System.Collections;

public class MovingEnemyScript : MonoBehaviour {


	public Transform target;
	UnityEngine.AI.NavMeshAgent agent; 


	public GameObject enemy;
	public GameObject PlayerC;
	GameObject player; //プレイヤー

	int enemyHP = 1;

	float dis;


	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find ("FPSController");
		target = player.transform;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> (); 
		//player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {

		Vector3 Apos = PlayerC.transform.position;
		Vector3 Bpos = enemy.transform.position;
		float dis = Vector3.Distance (Apos, Bpos);
		Debug.Log ("Distance : " + dis);
		// 目的地をプレイヤーに設定する。
		if (dis <= 7.0f) {
			agent.SetDestination (target.position);

		}
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
