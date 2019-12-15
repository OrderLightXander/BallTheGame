using UnityEngine;

public class Manager : MonoBehaviour {

	public void ChangeToScene () {
		ScoreCounter.scoreValue = 0;
		Application.LoadLevel("Main");
	}


}
