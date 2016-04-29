using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ball : MonoBehaviour {


	private bool isDown;

	public float maxForce = 10;
	public float maxPullDistance = 10;

	private int score;

	void Start() {
		GameObject.Find ("Score").GetComponent<Text> ().text = "Score: " + score.ToString();
	}

	void OnMouseDown() {
		isDown = true;
	}

	void Update() {

		if (isDown) {

			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if (Physics.Raycast (ray, out hit, 100.0f)) {
				GetComponent<LineRenderer> ().SetVertexCount (2);
				LineRenderer render = GetComponent<LineRenderer> ();
				Vector3 to = new Vector3 (hit.point.x, transform.position.y, hit.point.z);

				to = Vector3.ClampMagnitude(to - transform.position, maxPullDistance) + transform.position;

				render.SetPositions (new Vector3[] {
					transform.position,
					to
				});
			}

		}


		if (transform.position.y < -3f) {
			GameObject.Find ("GameController").GetComponent<GameController> ().ShowGameOver ();
		}

		Camera.main.gameObject.transform.LookAt (transform.position);


		if (Input.GetMouseButtonUp (0) && isDown) {
			GetComponent<LineRenderer> ().SetVertexCount (0);
			isDown = false;

			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = Mathf.Infinity;


			score++;
			GameObject.Find ("Score").GetComponent<Text> ().text = "Score: " + score.ToString();

			//RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition ,Vector2.zero,Mathf.Infinity); //Hit object that contains gameobject Information

		//	bool hit = Physics.Raycast(mousePosition, mousePosition - Camera.main.ScreenToWorldPoint(mousePosition),Mathf.Infinity);

			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if ( Physics.Raycast (ray,out hit,100.0f)) {

				Vector3 from = new Vector3 (transform.position.x, 1, transform.position.z);
				Vector3 to = new Vector3(hit.point.x, 1, hit.point.z);
				Vector3 direction = to - from;
				Vector3 normalizedDirection = direction.normalized;

				//Debug.DrawRay(from, direction, Color.red,1000);

				float magnitude = direction.magnitude > maxPullDistance ? maxPullDistance : direction.magnitude;

				float force = (magnitude / maxPullDistance) * maxForce;

				GetComponent<Rigidbody> ().AddForce (-normalizedDirection * force);
			}



			Debug.Log ("Do the thing!");
		}
	}


}
