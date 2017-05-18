using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolScript: MonoBehaviour {
	
	public GameObject[] points;
	Vector3 destination;
	UnityEngine.AI.NavMeshAgent agent; 
	float timepo = 0.0f;

	int enemyHP = 1;

	public GameObject player;
	//public GameObject enemy;
	public Transform target;

	float dis;

	bool disance = true;


	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> (); 
		points = GameObject.FindGameObjectsWithTag ("point");
		GotoNextPoint();

		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		target = player.transform;
	}



	
	// Update is called once per frame
	void Update () {
		timepo += Time.deltaTime;

		//ここのGoNectPointがPlayerとの距離が近づいた後も呼ばれてしまっている
		//ので①の中に入った後は呼ばれないような処理を追加すればいける
		if (timepo > 20.0f && disance == true) {
				GotoNextPoint ();
				timepo = 0;
			}


		Vector3 Apos = player.transform.position;
		Vector3 Bpos = transform.position;
		float dis = Vector3.Distance (Apos, Bpos);

		if (dis <= 20.0f) {
			//①
			agent.SetDestination (target.position);
			disance = false;
		} else if (dis > 20.0f) {
			disance = true;
		}
	}


	void GotoNextPoint(){
		int index = Random.Range(0,points.Length);
		destination = points[index].transform.position;
		agent.SetDestination(destination);

//		if (dis <= 20.0f) {
//			agent.SetDestination (target.position);
//		}
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