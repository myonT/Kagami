using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointsScript : MonoBehaviour {
	
	public static Text textpo;

	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void Point(){

		Time.timeScale = 0;
		textpo.text = (TimeScript.timeLimit + FPSScript.coinc * 10 + FPSScript.countb * 10 + PlayerController.keycount * 10).ToString ();

	}
}
