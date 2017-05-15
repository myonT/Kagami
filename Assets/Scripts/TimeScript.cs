using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {
	public Text Time;

	void Awake(){
		Data.Instance.time = 180.0f;
		//HPtext.text = Data.Instance.HP.ToString ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Data.Instance.time -= Time.deltaTime;
		Time.text = "Time :" + Data.Instance.time.ToString ("f2");
		
	}
}
