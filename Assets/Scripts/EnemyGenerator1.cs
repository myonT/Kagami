using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator1 : MonoBehaviour {

	public GameObject enemy;
	public GameObject PlayerC;
	public Transform target;
	UnityEngine.AI.NavMeshAgent agent; 

	float dis;		

	//ここでboolのflagを作る
	bool isDis5, isDis10;


	//bool isCalled = false;		


	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		//if (dis <= 10.0f) {		
		InvokeRepeating ("Generate", 0, 2);		

	}


	void Update () {

		//ここで距離を測って
		//else ifを使う際は厳しい条件から徐々に緩めていく

		if (dis < 5f /* && isDis5がtrueなら*/) {
			CancelInvoke ();
			//ここでisDis5をfalseに
			//ここでInvoke
		} else if (dis < 10f /* && isDis10がtrueなら*/) { //これはelseをつけないで if(5f <= dis && dis < 10f)と同じ。でも5f との比較を二回書くのはいけてない
			CancelInvoke ();
			//ここでisDis10をfalseに
			//ここでInvoke
		} else {
			CancelInvoke ();
			//isDis5, isDis10 ともにtrueに戻す。
		}


		//agent.SetDestination (target.position);
		if (FPSScript.coinc >= 2) {
			CancelInvoke ();
		}

	}

	void Generate(){
		Instantiate (enemy, transform.position, transform.rotation);
	}
}

