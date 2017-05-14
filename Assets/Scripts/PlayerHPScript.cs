using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPScript : MonoBehaviour {

	public static PlayerHPScript Instance =null;
	public int playerHP = 10;

	//public static float PlayerHP() {
		//return playerHP;
	//}

	void Awake(){
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}
}
/*
	Slider playerHP;

	// Use this for initialization
	void Start () {
		playerHP = GameObject.Find ("SHP").GetComponent<Slider> ();
		playerHP.value = SavevalueScript.valueHP;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PlayerDamage(){
		hp--;
		playerHP.value = hp;
	}
}
*/
