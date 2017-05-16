using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genemoveScript2 : MonoBehaviour {

	public Transform target;
	UnityEngine.AI.NavMeshAgent agent; 

	int enemyHP = 1;


	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find ("FPSControllers");
		target = player.transform;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> (); 

	}

	// Update is called once per frame
	void Update () {
		agent.SetDestination (target.position);
	}
	void Damage(){
		enemyHP -= 1;
		if(enemyHP == 0){
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider col){
		Debug.Log (GetComponent<Collider>().name);
		if(col.gameObject.tag == "Player"){
			col.gameObject.SendMessage ("PlayerDamage");
			//PlayerController damm = GetComponent<PlayerController>();
			//damm.PlayerDamage ();
			Destroy(this.gameObject);			
		}
	}

}
