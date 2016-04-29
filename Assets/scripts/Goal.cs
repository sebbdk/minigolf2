using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {


	void OnTriggerEnter(Collider collider) {
		
		if (collider.tag == "Ball") {
			Debug.Log ("ENTER!!!");
			GameObject.Find ("GameController").GetComponent<GameController> ().ShowGameOver ();
		}
	}


}
