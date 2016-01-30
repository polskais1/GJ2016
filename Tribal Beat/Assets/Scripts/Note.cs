using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	public Timer timer;
	public Player currentPlayer;

	public int startBeat;
	public int endBeat;

	void Awake(){
		var camera = GameObject.FindGameObjectWithTag("MainCamera");
		timer = camera.GetComponent<Timer> ();
	}

	void Start () {
		startBeat = timer.currentBeat ();
	}

	void Update () {
		int noteStatus = timer.inBeatWindow (endBeat);
		if (noteStatus == 2) {
//			currentPlayer.missNote ();
		} else if (noteStatus == 1) {
//			currentPlayer.hitNote ();
		}
	}
}
