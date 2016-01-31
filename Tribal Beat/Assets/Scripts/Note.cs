using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	public Timer timer;
	public Player currentPlayer;

	public int startBeat;
	public int endBeat;
	public int direction;
	public float originX;
	public float directionX = 0;
	static float startY = -3, endY = 3;
	static Sprite[] arrowSprites = Resources.LoadAll<Sprite> ("images/arrows");

	void Awake(){
		var camera = GameObject.FindGameObjectWithTag("MainCamera");
		timer = camera.GetComponent<Timer> ();
	}

	void Start () {
		startBeat = timer.currentBeat ();
		endBeat = startBeat + 4;
		gameObject.transform.localScale = new Vector2 (0.5f, 0.5f);
//		setDirection (Random.Range (0, 4));
		Update ();
	}

	void Update () {
		int noteStatus = timer.beatStatus (endBeat);
		if (noteStatus == 2) {
			Destroy (gameObject);
//			currentPlayer.missNote ();
		} else if (noteStatus == 1) {
//			currentPlayer.hitNote ();
		}

		float fraction = (timer.fractionalBeat () - startBeat)/(endBeat - startBeat);
		gameObject.transform.position = new Vector2(originX + directionX, startY + (endY - startY)*fraction);
	}

	public void setDirection (int dir) {
		direction = dir;
		directionX = dir/1.6f;
		gameObject.GetComponent<SpriteRenderer> ().sprite = arrowSprites [dir];
	}
}
