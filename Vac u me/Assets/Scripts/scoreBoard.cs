using UnityEngine;
using System.Collections;

public class scoreBoard : MonoBehaviour {

	public GameObject moneyScorePrefab;
	public GameObject weightScorePrefab;
	public GameObject textBoxPefab;
	public float lineHeight = 1;
	public int scoreIncrementAmount = 10;

	public int moneyScore = 0;
	public int weightScore = 0;

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
		GameObject ms = (GameObject) Instantiate(moneyScorePrefab, transform.position, transform.rotation);
		ms.transform.parent = transform;
		createTextBox ("moneyScore", "Money", ms.transform);
		moneyScoreText = ms.transform.Find("scoreText").gameObject.GetComponent<TextMesh>();
		isMoneyScoreText = true;
	}

	void showWeightScore(){
		Vector3 wsPos = transform.position;
		wsPos.y = wsPos.y - lineHeight;
		GameObject ws = (GameObject) Instantiate(weightScorePrefab, wsPos, transform.rotation);
		ws.transform.parent = transform;
		createTextBox ("weightScore", "Weight", ws.transform);
		weightScoreText = ws.transform.Find("scoreText").gameObject.GetComponent<TextMesh>();
		isWeightScoreText = true;
	}

	void createTextBox(string evtName, string textValue, Transform parent){
		GameObject tb = (GameObject) Instantiate(textBoxPefab, transform.position, transform.rotation);
		textBox tbTextBox = tb.GetComponent<textBox> ();
		tbTextBox.eventName = evtName;
		tbTextBox.text.Add (textValue);
		tb.transform.parent = parent;	
		tb.transform.localPosition = new Vector3 (0, 0, 0);

		tbTextBox.displayText ();
	}

	void updateScoreText(){
		if (isMoneyScoreText && incrementedMoneyScore < moneyScore) {
			incrementedMoneyScore += scoreIncrementAmount;
			moneyScoreText.text = incrementedMoneyScore.ToString();
		}
		
		if (isWeightScoreText && incrementedMoneyScore < weightScore) {
			incrementedWeightScore += scoreIncrementAmount;
			weightScoreText.text = incrementedWeightScore.ToString();
		}
	}
	
}
