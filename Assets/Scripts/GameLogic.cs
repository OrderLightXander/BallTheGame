using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour 
{
	public Text scoreCounter;
	public Text numberOfTries;
	public static int highScore;
	void Start () {
		numberOfTries = GetComponent<Text>();
		highScore = ScoreCounter.scoreValue;
	}
	void Update () {
		numberOfTries.text = "Highscore : " + ScoreCounter.scoreValue;
		if (ScoreCounter.scoreValue > highScore)
		{
			numberOfTries.text = "" + highScore;
		}
	}
}
