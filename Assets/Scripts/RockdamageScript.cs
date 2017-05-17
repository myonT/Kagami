using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockdamageScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.name == "FPSControllers"){
			col.gameObject.SendMessage ("PlayerDamage");
			Debug.Log (GetComponent<Collider>().name);
			//Destroy(this.gameObject);			
		}
	}
}
