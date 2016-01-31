using UnityEngine;
using System.Collections;

public class LeadInput : MonoBehaviour {

	public GameController gameController;
	
	void Start () {
	
	}

	void Update () {
		if (Input.GetKeyDown ("up")) {
			gameController.createNote (3);
		}
		if (Input.GetKeyDown ("right")) {
			gameController.createNote (2);
		}
		if (Input.GetKeyDown ("down")) {
			gameController.createNote (0);
		}
		if (Input.GetKeyDown ("left")) {
			gameController.createNote (1);
		}
	}
}
