using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject gameOver;

	public bool gameIsOver;

	public void ShowGameOver() {
		if (gameOver && !gameIsOver) {
			gameOver.SetActive (true);
			gameIsOver = true;
		}
	}


	public void ReloadLevel() {
		Application.LoadLevel(Application.loadedLevel);
	}


}
