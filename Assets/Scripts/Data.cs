using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour {

	public readonly static Data Instance = new Data();

	public int HP = 25;
	public float time = 180.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (HP <= 0) {
			SceneManager.LoadScene ("Over");
		}
		
	}
}
