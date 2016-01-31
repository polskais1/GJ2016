using UnityEngine;
using System.Collections;

public class LeadInput : MonoBehaviour {

	public GameController gameController;
	public Timer timer;

	private static string[] leftInput = {"up", "right", "down", "left"};
	private static string[] rightInput = {"w", "d", "s", "a"};
	
	void Start () {
	
	}

	void Update () {
		string[] currentInput = (timer.hasSwitched () ? rightInput : leftInput);
		if (timer.inBeatWindow ()) {
			if (Input.GetKeyDown (currentInput[0])) {
				gameController.createNote (3, false, timer.hasSwitched());
			}
			if (Input.GetKeyDown (currentInput[1])) {
				gameController.createNote (2, false, timer.hasSwitched());
			}
			if (Input.GetKeyDown (currentInput[2])) {
				gameController.createNote (0, false, timer.hasSwitched());
			}
			if (Input.GetKeyDown (currentInput[3])) {
				gameController.createNote (1, false, timer.hasSwitched());
			}
		}
	}
}
