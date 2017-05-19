using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScriptff : MonoBehaviour {
	
		public GameObject player;
		public GameObject OnPanel,OnUnPanel;
		public GameObject C1;
		public Text Enemyp,HPp,Timep,Itemp;
		private bool pauseGame = false;



		// Use this for initialization
		void Start () {

			OnPause ();


		}

		// Update is called once per frame
		void Update () {
			if(Input.GetKeyDown(KeyCode.M)){

				pauseGame = !pauseGame;

				if (pauseGame == true) {
					OnPause ();
				} else {
					OnUnPause ();
				}
			}
		}
		public void OnPause()
		{
			OnPanel.SetActive(true);        // PanelMenuをtrueにする
			OnUnPanel.SetActive(false);     // PanelEscをfalseにする
			Time.timeScale = 0;
			pauseGame = true;
			C1.SetActive (false);

			Enemyp.text = "Enemy :" + PlayerController.enemycount.ToString ();
			HPp.text = "HP :" + Data.Instance.HP.ToString ();
			Timep.text = "Time :" + TimeScript.timeLimit.ToString ("f1");
			Itemp.text = "Item :" + (FPSScript.countb + PlayerController.keycount).ToString();
		}

		public void OnUnPause()
		{
			OnPanel.SetActive(false);       // PanelMenuをfalseにする
			OnUnPanel.SetActive(true);      // PanelEscをtrueにする
			Time.timeScale = 1;
			pauseGame = false;
			C1.SetActive (true);
		}
	}


