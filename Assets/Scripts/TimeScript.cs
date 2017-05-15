using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour {
	public Text time;
	public static float timeLimit = 180.0f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		timeLimit -= Time.deltaTime;
		time.text = "Time : " + timeLimit.ToString ("f2");
		//if (timeLimit < 0.02f) {
			//SceneManager.LoadScene ("Gameover");
		}
	}
