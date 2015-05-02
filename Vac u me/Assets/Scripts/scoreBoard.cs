using UnityEngine;
using System.Collections;

public class scoreBoard : MonoBehaviour {

	public GameObject moneyScore;
	public GameObject weightScore;
	public float lineHeight = 1;
	public int scoreIncrementAmount = 10;

	private TextMesh moneyScoreText;
	private bool isMoneyScoreText = false;
	private int incrementedMoneyScore = 0;

	private TextMesh weightScoreText;
	private bool isWeightScoreText = false;
	private int incrementedWeightScore = 0;

	void Awake () {
		showScore ();
	}

	void Update(){
		updateScoreText ();
	}

	public void showScore(){
		showMoneyScore ();
		showWeightScore ();
	}

	void showMoneyScore(){
		GameObject ms = (GameObject) Instantiate(moneyScore, transform.position, transform.rotation);
		ms.transform.parent = transform;
		moneyScoreText = ms.transform.Find("scoreText").gameObject.GetComponent<TextMesh>();
		Messenger.Broadcast ("moneyScore");
		isMoneyScoreText = true;
	}

	void showWeightScore(){
		Vector3 wsPos = transform.position;
		wsPos.y = wsPos.y - lineHeight;
		GameObject ws = (GameObject) Instantiate(weightScore, wsPos, transform.rotation);
		ws.transform.parent = transform;
		weightScoreText = ws.transform.Find("scoreText").gameObject.GetComponent<TextMesh>();
		Messenger.Broadcast ("weightScore");
		isWeightScoreText = true;
	}

	void updateScoreText(){
		if (isMoneyScoreText) {
			incrementedMoneyScore += scoreIncrementAmount;
			moneyScoreText.text = incrementedMoneyScore.ToString();
		}
		
		if (isWeightScoreText) {
			incrementedWeightScore += scoreIncrementAmount;
			weightScoreText.text = incrementedWeightScore.ToString();
		}
	}
	
}
