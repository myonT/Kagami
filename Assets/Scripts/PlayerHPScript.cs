using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPScript : MonoBehaviour {

	public static float hp = 10.0f;
	//public static float PlayerHP() {
		//return playerHP;
	//}

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
