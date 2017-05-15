using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {
	public Text time;
	public static float timeLimit = 60.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeLimit -= Time.deltaTime;
		time.text = "Time :" + timeLimit.ToString ("f2");
		
	}
}
