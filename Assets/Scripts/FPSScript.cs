using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;


public class FPSScript : MonoBehaviour {

	public Camera camera;

	public GameObject redball;
	public GameObject blueball;
	public GameObject redballn;
	public GameObject blueballn;
	public GameObject selectedGameObject;

	public int playerHP = 10;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		//eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

		redball = GameObject.Find ("redball");
		redball.SetActive (true);

		blueball = GameObject.Find ("blueball");
		blueball.SetActive (true);

		redballn = GameObject.Find ("redballn");
		redballn.SetActive (false);

		blueballn = GameObject.Find ("blueballn");
		blueballn.SetActive (false);

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Shot ();
			search ();
		} 
	}



	void PlayerDamage(){
		playerHP -= 1;
	}

	void Shot(){
		int distance = 10;
		Vector3 center = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
		Ray ray = camera.ScreenPointToRay (center);
		RaycastHit hitInfo;

		if (Physics.Raycast (ray, out hitInfo, distance)) {
			Debug.DrawLine (ray.origin, hitInfo.point, Color.blue);
			Debug.Log (hitInfo.collider.name);
			if(hitInfo.collider.tag == "Enemy"){
				hitInfo.collider.SendMessage ("Damage");
			}
		}
	}
	void search(){
		int distance = 10;
		Vector3 center = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
		Ray ray = camera.ScreenPointToRay (center);
		RaycastHit hitInfo;

		if (Physics.Raycast (ray, out hitInfo, distance, 1 << 8)) {
			selectedGameObject = hitInfo.collider.gameObject;
			Debug.DrawLine (ray.origin, hitInfo.point, Color.blue);
			Debug.Log (hitInfo.collider.gameObject);
			switch (selectedGameObject.name) {
			case "redball":
				redball.SetActive (false);
				redballn.SetActive (true);
				break;
			case "blueball":
				blueball.SetActive (false);
				blueballn.SetActive (true);
				break;
			}
		}
	}
}

