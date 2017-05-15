using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OPscript : MonoBehaviour {
	Button button;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Button>().onClick.AddListener(OnClick);
	}
	void OnClick(){
		SceneManager.LoadScene("02");
	}
}
