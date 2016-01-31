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
				gameController.createNote (3, -2.38f);
			}
			if (Input.GetKeyDown ("right")) {
				gameController.createNote (2, -2.38f);
			}
			if (Input.GetKeyDown ("down")) {
				gameController.createNote (0, -2.38f);
			}
			if (Input.GetKeyDown ("left")) {
				gameController.createNote (1, -2.38f);
			}
		}
	}
}
