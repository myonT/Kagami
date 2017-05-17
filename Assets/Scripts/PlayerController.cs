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
	public GameObject itemkey9;
	public GameObject itembtnkey;
	public GameObject itembtnkey2;
	public GameObject itembtnkey3;
	public GameObject itembtnkey4;
	public GameObject itembtnkey5;
	public GameObject Books1;
	public GameObject Books2;
	public GameObject itembtnkey8;
	public GameObject itembtnkey9;
	public GameObject selectedGameObject;


	//public static PlayerController Instance = new PlayerController();
	//public static int HP = 10;
	public static float keycount = 0;
	public static int enemycount = 0;

	public Text HPtext;
	public Text time;

//	int PlayerHP = PlayerHP Manager.Instance.playerHP;

	Slider sliders;

	void Awake(){
		Data.Instance.HP = 25;
		Data.Instance.time = 180;
		//HPtext.text = Data.Instance.HP.ToString ();
		sliders = GameObject.Find ("Sliders").GetComponent<Slider> ();
		sliders.value = Data.Instance.HP;
	}



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

		itemkey9 = GameObject.Find ("key9");
		itemkey9.SetActive (true);

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

		Books1 = GameObject.Find ("Books1");
		Books1.SetActive (true);

		Books2 = GameObject.Find ("Books2");
		Books2.SetActive (false);

		itembtnkey8 = GameObject.Find ("itembtnkey8");
		itembtnkey8.SetActive (false);

		itembtnkey9 = GameObject.Find ("itembtnkey9");
		itembtnkey9.SetActive (false);

		//sliders = GameObject.Find ("Sliders").GetComponent<Slider> ();
		//sliders.value = Data.Instance.HP;

		//SceneManager.LoadScene("Test");


	}
	
	// Update is called once per frame
	void Update () {
		//int PlayerHP = PlayerHPManager.Instance.playerHP;
		if (Input.GetMouseButtonDown (0)) {
				Shot ();
				search ();
				Next ();
			} 

		}


	void PlayerDamage(){
		//int PlayerHP = PlayerHPManager.Instance.playerHP;
		//PlayerHP--;
		Data.Instance.HP--;//managerはエラー
		HPtext.text = Data.Instance.HP.ToString ();
		Debug.Log ("give");
		Debug.Log (Data.Instance.HP);
		sliders.value = Data.Instance.HP;
		if (Data.Instance.HP <= 0) {
			SceneManager.LoadScene ("Over");
		}
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
				enemycount++;
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
					Books1.SetActive (false);
					Books2.SetActive (true);
					break;
				case "Books2":
					Books2.SetActive (false);
					itemkey8.SetActive (true);
					break;
				case "key8":
					itemkey8.SetActive (false);
					itembtnkey8.SetActive (true);
					keycount++;
					break;
				case "key9":
					itemkey9.SetActive (false);
					itembtnkey9.SetActive (true);
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
				//if(keycount>=5){
					SceneManager.LoadScene("06");
				//}
			}
		}
	}

	//void OnTriggerEnter(Collider collision){
		//if(collision.gameObject.tag == "Enemy"){
			//other.gameObject.SendMessage ("PlayerDamage");
		//	Destroy(gameObject);			
		}
	