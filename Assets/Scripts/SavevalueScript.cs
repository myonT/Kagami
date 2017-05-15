using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavevalueScript : MonoBehaviour {
	public Slider sliderHP;
	public static float valueHP;

	// Use this for initialization
	void Start () {
//		valueHP = GameObject.Find ("SHP").GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {

		valueHP = sliderHP.value;
	}
}
