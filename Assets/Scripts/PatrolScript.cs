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


	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> (); 
		points = GameObject.FindGameObjectsWithTag ("point");
		GotoNextPoint();
	}



	
	// Update is called once per frame
	void Update () {
		timepo += Time.deltaTime;

		if (timepo > 20.0f) {
			GotoNextPoint ();
			timepo = 0;
		}
	}

	void GotoNextPoint(){
		int index = Random.Range(0,points.Length);
		destination = points[index].transform.position;
		//agent.destination = points[destination].position;
		agent.SetDestination(destination);



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