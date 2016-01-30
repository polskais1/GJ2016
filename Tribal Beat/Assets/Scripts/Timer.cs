using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public GameController gameController;

	public float tempo;
	public float tolerance; //how long a player has to hit a beat
	
	private float startTime;
	private float beatLength;
	private int lastBeat;

	void Start () {
		startTime = Time.time;
		beatLength = 60 / tempo;
		lastBeat = 0;
	}

	void Update () {
		if (lastBeat != currentBeat ()) {
			gameController.createNote ();
		}
		lastBeat = currentBeat ();
	}

	public int currentBeat () {
		return (int)(Mathf.Floor((Time.time - startTime) / beatLength));
	}

	public int inBeatWindow (int beat) {
		if (currentBeat () == beat) {
			//on the beat
			return 2;
		} else if (currentBeat () > beat) {
			//missed the beat
			return 1;
		} else {
			//beat has yet to happen
			return 0;
		}
	}
}
