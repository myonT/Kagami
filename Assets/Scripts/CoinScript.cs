using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinScript : MonoBehaviour {

//	public AudioClip audioClip;
//	AudioSource audioSource;

	// Use this for initialization
	void Start () {
//		audioSource = gameObject.GetComponent<AudioSource>();
//		audioSource.clip = audioClip;
	}
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			AudioManager.Instance.PlaySE ("coino");
			Destroy (this.gameObject);	

		}
	}
}
