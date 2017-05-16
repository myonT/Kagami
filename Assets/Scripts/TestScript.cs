using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestScript: MonoBehaviour {

	public Text textpo;


	// Use this for initialization
	void Start () {
	}
		
	void Update(){
		Time.timeScale = 0;
		textpo.text = "合計点数 : "+(TimeScript.timeLimit + FPSScript.coinc * 10 + FPSScript.countb * 10 + PlayerController.keycount * 10).ToString () + "点";
	}
	}
	
	// Update is called once per frame
	

