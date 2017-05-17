using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestScript: MonoBehaviour {

	public Text textpo;
	public float ppp;


	// Use this for initialization
	void Start () {
	}
		
	void Update(){
		ppp = TimeScript.timeLimit + FPSScript.coinc + FPSScript.countb + PlayerController.keycount + PlayerController.enemycount;
		Debug.Log (ppp);
		Time.timeScale = 0;
		textpo.text = "合計点数 :" + ppp.ToString ("f0");
	}
	}
	
	// Update is called once per frame
	

