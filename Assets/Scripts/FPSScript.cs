using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;


public class FPSScript : MonoBehaviour {

	public Camera camera;

	public GameObject redball;
	public GameObject blueball;
	public GameObject redballn;
	public GameObject blueballn;
	public GameObject Shipla;
	public GameObject redballshi;
	public GameObject blueballshi;
	public GameObject selectedGameObject;

	public GameObject spark;

	public GameObject rock;
	public GameObject rock2;

	Slider slider;

	public int countb = 0;

	public bool shingou;

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

		redballshi = GameObject.Find ("redballshi");
		redballshi.SetActive (false);

		blueballshi = GameObject.Find ("blueballshi");
		blueballshi.SetActive (false);

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Shot ();
			search ();
		} 
	}



	public void PlayerDamage(){
		if (PlayerController.keycount == 7) {
			PlayerController.playerHP = 17;
		}
		PlayerController.playerHP--;
		slider.value = PlayerController.playerHP;
	}

	void Shot(){
		int distance = 10;
		Vector3 center = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
		Ray ray = camera.ScreenPointToRay (center);
		RaycastHit hitInfo;

		if (Physics.Raycast (ray, out hitInfo, distance)) {
			Debug.DrawLine (ray.origin, hitInfo.point, Color.blue);
			Debug.Log (hitInfo.collider.name);
			if (hitInfo.collider.tag == "Enemy") {
				hitInfo.collider.SendMessage ("Damage");
				PlayerController.enemycount++;
			}
		}
		if (Physics.Raycast (ray, out hitInfo, distance)) {
			Debug.DrawLine (ray.origin, hitInfo.point, Color.blue);
			Debug.Log (hitInfo.collider.name);
			if (hitInfo.collider.tag == "break") {
				Instantiate (spark, transform.position, Quaternion.identity);
				Destroy (rock);
			}
		}
		if (Physics.Raycast (ray, out hitInfo, distance)) {
			Debug.DrawLine (ray.origin, hitInfo.point, Color.blue);
			Debug.Log (hitInfo.collider.name);
			if (hitInfo.collider.name == "Rockss") {
				if(shingou = true)
				Instantiate (spark, transform.position, Quaternion.identity);
				Destroy (rock2);
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
				countb++;
				break;
			case "blueball":
				blueball.SetActive (false);
				blueballn.SetActive (true);
				countb++;
				break;
			}
		}

		if (Physics.Raycast (ray, out hitInfo, distance)) {
			selectedGameObject = hitInfo.collider.gameObject;
			Debug.DrawLine (ray.origin, hitInfo.point, Color.blue);
			Debug.Log (hitInfo.collider.name);
			if (countb == 2) {
				switch (selectedGameObject.name) {
				case "Shipla":
					redballn.SetActive (false);
					blueballn.SetActive (false);
					redballshi.SetActive (true);
					blueballshi.SetActive (true);
					shingou = true;
					break;

				}
			}
		}
	}
}

