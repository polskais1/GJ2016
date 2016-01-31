using UnityEngine;
using System.Collections;

public class MotherEarth : MonoBehaviour {

	public Timer timer;

	private float currentBeat;
	private string currentImage;
	static Sprite[] earths = Resources.LoadAll<Sprite> ("images/levels/earth");
	
	void Start () {
		currentBeat = 0;
		currentImage = "gme2-01";
	}

	void Update () {
		if (timer.fractionalBeat () - currentBeat > 0.5f) {
			replaceImage ();
			currentBeat = timer.fractionalBeat ();
		}
	}

	void replaceImage () {
		if (currentImage == "gme2-01") {
			gameObject.GetComponent<SpriteRenderer> ().sprite = earths[4];
			currentImage = "gme2-02";
		} else {
			gameObject.GetComponent<SpriteRenderer> ().sprite = earths[3];
			currentImage = "gme2-01";
		}
	}
}
