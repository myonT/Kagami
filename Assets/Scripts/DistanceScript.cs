using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceScript : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Generate",0,7);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.name == "FPScontroller") {
			other.gameObject.SendMessage ("Generate");
		}
}
}
