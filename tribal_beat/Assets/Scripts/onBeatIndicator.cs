using UnityEngine;
using System.Collections;

public class onBeatIndicator : MonoBehaviour {
    public Timer timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.localScale = new Vector2(1, timer.inBeatWindow() ? 1 : 0);
	}
}
