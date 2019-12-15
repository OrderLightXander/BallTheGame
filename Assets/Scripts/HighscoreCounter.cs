using UnityEngine;
using UnityEngine.UI;

public class HighscoreCounter : MonoBehaviour {

	Text Tries;
	public static int highScore;
	void Awake()
	{
		Tries = GetComponent<Text>();
		highScore = PlayerPrefs.GetInt("highscore", 0);
		Tries.text = highScore.ToString();
	}
	void Update()
	{
		Tries.text = "Highscore : " + highScore;
		if (ScoreCounter.scoreValue > highScore)
		{
			highScore = ScoreCounter.scoreValue;
			Tries.text = "" + highScore;

			PlayerPrefs.SetInt("highscore", highScore);
		}

	}
}
