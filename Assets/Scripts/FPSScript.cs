using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

	public Text HPtext;
	public Text coin;
	//public static int PlayerController;

	//public InputField inputField;

	Slider sliders;

	public static float countb = 0;

	public static float coinc;

	public float timer;
	//int PlayerHP = PlayerHPManager.Instance.playerHP;

	public bool shingou;

	private IEnumerator speed(){
		iTween.PunchPosition(this.gameObject, iTween.Hash(
			"y", 2,
			"x", 2,
			"time", 1.0f)
		);
		yield return new WaitForSeconds (2.0f);//コルーチン必要だったかは不明
	}

	// Use this for initialization
	void Start () {
		//int PlayerHP = PlayerHPManager.Instance.playerHP;
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

		//inputField = GameObject.Find ("Canvas/InputField").GetComponent<InputField> ();
		//inputField.enabled = false;

		sliders = GameObject.Find ("Sliderf").GetComponent<Slider> ();
		sliders.value = Data.Instance.HP;

		coinc = 1;
		coin.text = "0";

		shingou = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Shot ();
			search ();
			goal ();
		} 
	}

	void PlayerDamage(){
		Data.Instance.HP--;
		HPtext.text = Data.Instance.HP.ToString ();
		Debug.Log ("give");
		Debug.Log (Data.Instance.HP);
		sliders.value = Data.Instance.HP;
		StartCoroutine ("speed");  
		speed ();

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
				if (countb == 2) {
					if (shingou = true)
						Instantiate (spark, transform.position, Quaternion.identity);
					Destroy (rock2);
				}
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

	void goal(){
		int distance = 10;
		Vector3 center = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
		Ray ray = camera.ScreenPointToRay (center);
		RaycastHit hitInfo;

		if (Physics.Raycast (ray, out hitInfo, distance)) {
			Debug.DrawLine (ray.origin, hitInfo.point, Color.blue);
			Debug.Log (hitInfo.collider.name);
			if(hitInfo.collider.tag == "Next"){
				SceneManager.LoadScene("07");	
		}
	}
		if (Physics.Raycast (ray, out hitInfo, distance)) {
			Debug.DrawLine (ray.origin, hitInfo.point, Color.blue);
			Debug.Log (hitInfo.collider.name);
			if(hitInfo.collider.name == "Goalb"){
				SceneManager.LoadScene("Over");	
			}
		}
}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "coin"){
			Debug.Log (coinc);
			coin.text = coinc.ToString ();
			coinc = coinc + 1;	
		}
	}
}

