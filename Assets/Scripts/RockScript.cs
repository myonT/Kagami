using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour {

	public GameObject rock;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Generate(){
		Instantiate (rock, transform.position, transform.rotation);
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "FPSControllers"){
			Debug.Log (GetComponent<Collider>().name);
			AudioManager.Instance.PlaySE ("rock");
			Generate ();
		}
}
}
