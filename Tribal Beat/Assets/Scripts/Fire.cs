using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	public Timer timer;
	
	private float currentBeat;
	private string currentImage;
	static Sprite[] earths = Resources.LoadAll<Sprite> ("images/fire");
	
	void Start () {
		currentBeat = 0;
		currentImage = "fire-01";
	}

	void Update () {
		if (timer.currentBeat () - currentBeat >= 1) {
			replaceImage ();
			currentBeat = timer.currentBeat ();
		}
	}

	void replaceImage () {
		if (currentImage == "fire-01") {
			gameObject.GetComponent<SpriteRenderer> ().sprite = earths[1];
			currentImage = "fire-02";
		} else {
			gameObject.GetComponent<SpriteRenderer> ().sprite = earths[0];
			currentImage = "fire-01";
		}
	}
}
