using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour {

	public Camera camera;

	public GameObject itemkey;
	public GameObject itemkey2;
	public GameObject itemkey5;
	public GameObject itemkey8;
	public GameObject itembtnkey;
	public GameObject itembtnkey2;
	public GameObject itembtnkey3;
	public GameObject itembtnkey4;
	public GameObject itembtnkey5;
	public GameObject itembtnkey6;
	public GameObject itembtnkey7;
	public GameObject itembtnkey8;
	public GameObject selectedGameObject;


	public int playerHP = 10;

	Slider slider;

	public int keycount = 0;


	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		//eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();


		itemkey = GameObject.Find ("key");
		itemkey.SetActive (false);

		itemkey2 = GameObject.Find ("key2");
		itemkey2.SetActive (false);

		itemkey5 = GameObject.Find ("key5");
		itemkey5.SetActive (true);

		itemkey8 = GameObject.Find ("key8");
		itemkey8.SetActive (false);

		itembtnkey = GameObject.Find ("itembtnkey");
		itembtnkey.SetActive (false);

		itembtnkey2 = GameObject.Find ("222");
		itembtnkey2.SetActive (false);

		itembtnkey3 = GameObject.Find ("333");
		itembtnkey3.SetActive (false);

		itembtnkey4 = GameObject.Find ("itembtnkey4");
		itembtnkey4.SetActive (false);

		itembtnkey5 = GameObject.Find ("itembtnkey5");
		itembtnkey5.SetActive (false);

		itembtnkey6 = GameObject.Find ("Books1");
		itembtnkey6.SetActive (true);

		itembtnkey7 = GameObject.Find ("Books2");
		itembtnkey7.SetActive (false);

		itembtnkey8 = GameObject.Find ("itembtnkey8");
		itembtnkey8.SetActive (false);

		slider = GameObject.Find ("Slider").GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
				Shot ();
				search ();
				Next ();
			} 
		}



	public void PlayerDamage(){
		playerHP--;
		slider.value = playerHP;
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
				case "EnemyN1":
					itembtnkey3.SetActive (true);
					keycount++;
					break;
				case "EnemyN2":
					itembtnkey4.SetActive (true);
					keycount++;
					break;
				default:
					break;
				}
			}
		}

		if (Physics.Raycast (ray, out hitInfo, distance)) {
			if (hitInfo.collider.name == "EnemyN3") {
				Destroy (hitInfo.collider.gameObject);
			}
		}
	}

	void search(){
		//selectedGameObject=null;
		int distance = 20;
		Vector3 center = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
		Ray ray = camera.ScreenPointToRay (center);
		RaycastHit hitInfo;

		if (Physics.Raycast (ray, out hitInfo, distance,1 << 9)){
			selectedGameObject = hitInfo.collider.gameObject;
			Debug.DrawLine (ray.origin, hitInfo.point, Color.blue);
			Debug.Log (hitInfo.collider.gameObject);
			if (hitInfo.collider.tag == "clickable") {
				switch (selectedGameObject.name) {
				case "blueSwitch":
					itemkey.SetActive (true);
					itemkey2.SetActive (true);
					break;
				case "key":
					itemkey.SetActive (false);
					itembtnkey.SetActive (true);
					keycount++;
					break;
				case "key2":
					itemkey2.SetActive (false);
					itembtnkey2.SetActive (true);
					keycount++;
					break;
				case "key5":
					itemkey5.SetActive (false);
					itembtnkey5.SetActive (true);
					keycount++;
					break;
				case "Books1":
					itembtnkey6.SetActive (false);
					itembtnkey7.SetActive (true);
					break;
				case "Books2":
					itembtnkey7.SetActive (false);
					itemkey8.SetActive (true);
					break;
				case "key8":
					itemkey8.SetActive (false);
					itembtnkey8.SetActive (true);
					keycount++;
					break;
				}
			}
		}
	}
	void Next(){
		int distance = 10;
		Vector3 center = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
		Ray ray = camera.ScreenPointToRay (center);
		RaycastHit hitInfo;

		if (Physics.Raycast (ray, out hitInfo, distance)) {
			if(hitInfo.collider.tag == "Next"){
				if(keycount==5){
					SceneManager.LoadScene("06");
				}
			}
		}
	}

	//void OnTriggerEnter(Collider collision){
		//if(collision.gameObject.tag == "Enemy"){
			//other.gameObject.SendMessage ("PlayerDamage");
		//	Destroy(gameObject);			
		}
	