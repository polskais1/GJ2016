using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public GameController gameController;

	public float tempo;
	public float tolerance; //how long a player has to hit a beat, in fraction of a beat
	
	private float startTime;
	private float beatLength;
	private int lastBeat;

	void Start () {
		startTime = Time.time;
		beatLength = 60 / tempo;
		lastBeat = 0;
	}

	void Update () {
		lastBeat = currentBeat ();
	}

	public int currentBeat () {
		return (int)(Mathf.Floor((Time.time - startTime) / beatLength));
	}

	public float fractionalBeat () {
		return (Time.time - startTime) / beatLength;
	}

	public bool inBeatWindow () {
		return true;
		float beatFraction = fractionalBeat () - Mathf.Floor (fractionalBeat ());
		return (beatFraction < 0.5 + tolerance && beatFraction > 0.5 - tolerance);
	}

	public int beatStatus (int beat) {
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
