using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
	public static int scoreValue = 0;
	Text Score;
	void Start () {
		Score = GetComponent<Text>();
	}
	void Update () {
		Score.text = "Score : " + scoreValue;
	}
}
