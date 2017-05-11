using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;


public class PlayerController : MonoBehaviour {

	public Camera camera;

	public GameObject itemkey;
	public GameObject itemkey2;
	public GameObject itembtnkey;
	public GameObject itembtnkey2;
	public GameObject itembtnkey3;
	public GameObject itembtnkey4;
	public GameObject selectedGameObject;


	int playerHP = 10;

	int keycount = 0;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		//eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();


		itemkey = GameObject.Find ("key");
		itemkey.SetActive (false);

		itemkey2 = GameObject.Find ("key2");
		itemkey2.SetActive (false);

		itembtnkey = GameObject.Find ("itembtnkey");
		itembtnkey.SetActive (false);

		itembtnkey2 = GameObject.Find ("itembtnkey2");
		itembtnkey2.SetActive (false);

		itembtnkey3 = GameObject.Find ("itembtnkey3");
		itembtnkey3.SetActive (false);

		itembtnkey4 = GameObject.Find ("itembtnkey4");
		itembtnkey4.SetActive (false);

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
				selectedGameObject = hitInfo.collider.gameObject;
				switch (selectedGameObject.name) {
				case "EnemyN 1":
					itembtnkey3.SetActive (true);
					break;
				case "EnemyN 1 (1)":
					itembtnkey4.SetActive (true);
					break;
				}
			}
		}
	}

	void search(){
		//selectedGameObject=null;
		int distance = 10;
		Vector3 center = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
		Ray ray = camera.ScreenPointToRay (center);
		RaycastHit hitInfo;

		if (Physics.Raycast (ray, out hitInfo, distance,1 << 8)){
			selectedGameObject = hitInfo.collider.gameObject;
			Debug.DrawLine (ray.origin, hitInfo.point, Color.blue);
			Debug.Log (hitInfo.collider.gameObject);
			//if(hitInfo.collider.tag == "clickable"){
				switch(selectedGameObject.name){
					case "blueSwitch":
						itemkey.SetActive (true);
						itemkey2.SetActive (true);
						break;
					case "key":
						itemkey.SetActive (false);
						itembtnkey.SetActive (true);
						//keycount++;
						break;
					case "key2":
						itemkey2.SetActive (false);
						itembtnkey2.SetActive (true);
						//keycount++;
						break;
			}
		}
	}
}

