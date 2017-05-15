using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControllersa : MonoBehaviour {

	const float TEXTSpeed = 0.5f;
	const float TEXTSpeedSTRING = 0.05f;
	const float COMPLETELINEDELAY = 0.3f;

	[SerializeField] Text lineText;		// 文字表示Text
	[SerializeField] string[] scenarios;

	float textSpeed = 0;			        // 表示速度
	float completeLineDelay = COMPLETELINEDELAY;	// 表示し終えた後の待ち時間
	int currentLine = 0;			        // 表示している行数
	string currentText = string.Empty;		// 表示している文字
	bool isCompleteLine = false;		

	// Use this for initialization
	void Start () {
		Show ();

		
	}

	void Show(){
		Initialize();
		StartCoroutine(ScenarioCoroutine() );
	}

	void Initialize(){

		isCompleteLine = false;
		lineText.text = "";
		currentText = scenarios[currentLine];

		textSpeed = TEXTSpeed + (currentText.Length * TEXTSpeedSTRING);

		LineUpdate();
	}

	IEnumerator ScenarioCoroutine()
	{
		while(true)
		{
			yield return null;

			// 次の内容へ
			if(isCompleteLine && Input.GetMouseButton(0))
			{
				yield return new WaitForSeconds(completeLineDelay);

				if(currentLine > scenarios.Length - 1)
				{
					ScenarioEnd();
					yield break;
				} 

				Initialize();
			}

			// 表示中にボタンが押されたら全部表示
			else if(!isCompleteLine && Input.GetMouseButton(0)) 
			{
				iTween.Stop();
				TextUpdate(currentText.Length); // 全部表示
				TextEnd();
				yield return new WaitForSeconds(completeLineDelay);
			}
		}
	}

	void LineUpdate()
	{
		iTween.ValueTo(this.gameObject, iTween.Hash(
			"from", 0,
			"to", currentText.Length, 
			"time", textSpeed, 
			"onupdate", "TextUpdate",
			"oncompletetarget", this.gameObject,
			"oncomplete", "TextEnd"
		));
	}

	void TextUpdate(int lineCount)
	{
		lineText.text = currentText.Substring(0, lineCount);
	}

	void TextEnd()
	{
		Debug.Log("表示完了");
		isCompleteLine = true;
		currentLine++;
	}
	void ScenarioEnd()
	{
		Debug.Log("会話終了");
	}


		

	// Update is called once per frame
	void Update () {
		
	}
}

