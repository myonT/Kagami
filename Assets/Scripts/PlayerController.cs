using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;


public class PlayerController : MonoBehaviour {

	public Camera camera;

	public GameObject itemkey;
	public GameObject itembtnkey;
	public GameObject selectedGameObject;

	public string myItem;

	int playerHP = 10;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		//eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();


		itemkey = GameObject.Find ("key");
		itemkey.SetActive (false);

		itembtnkey = GameObject.Find ("itembtnkey");
		itembtnkey.SetActive (false);

		myItem = "noitem";
		
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
						break;
					case "key":
						itemkey.SetActive (false);
						itembtnkey.SetActive (true);
						myItem = "key";//アイテム持ってるやつの実装する
						break;
			}
		}
	}
}

