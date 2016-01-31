using UnityEngine;
using System.Collections;

public class FollowInput : MonoBehaviour {

	public Timer timer;
	
	void Start () {
	
	}

	void Update () {
		if (timer.inBeatWindow ()) {
		}
	}
}
