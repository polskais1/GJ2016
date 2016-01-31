using UnityEngine;
using System.Collections;

public class LeadInput : MonoBehaviour {

	public GameController gameController;
	public Timer timer;
	
	void Start () {
	
	}

	void Update () {
		if (timer.inBeatWindow ()) {
			if (Input.GetKeyDown ("up")) {
				gameController.createNote (3, false);
			}
			if (Input.GetKeyDown ("right")) {
				gameController.createNote (2, false);
			}
			if (Input.GetKeyDown ("down")) {
				gameController.createNote (0, false);
			}
			if (Input.GetKeyDown ("left")) {
				gameController.createNote (1, false);
			}
		}
	}
}
