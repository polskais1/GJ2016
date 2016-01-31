using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	public Timer timer;
	public Player currentPlayer;
	public GameController gameController;
    public bool side; // whether or not the note is on the right side

    private int startBeat, endBeat, direction;
    private float directionX;

    private static float leftOrigin = -2.38f, rightOrigin = 0.58f;
    private static float startY = -3, endY = 3;
    private static Sprite[] arrowSprites = Resources.LoadAll<Sprite> ("images/arrows");

	void Awake(){
		var camera = GameObject.FindGameObjectWithTag("MainCamera");
		timer = camera.GetComponent<Timer> ();
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ();
	}

	void Start () {
		startBeat = timer.closestBeat ();
		endBeat = startBeat + 4;
		Update ();
	}

	void Update () {
        if (timer.beatStatus(endBeat) == 2)
        {
            if (side)
            {
                gameController.hurtPlayer(2);
                gameObject.AddComponent<FadeAway>();
                Destroy(this);
            }
            else if (gameObject.GetComponent<FadeAway>() == null)
            {
                gameController.createNote(direction, true).AddComponent<FadeIn>();
                gameObject.AddComponent<FadeAway>();
            }
        }

		float fraction = (timer.fractionalBeat () - startBeat)/(endBeat - startBeat);
		gameObject.transform.position = new Vector2(originX() + directionX, startY + (endY - startY)*fraction);
	}

	public void setDirection (int dir) {
		direction = dir;
		directionX = dir/1.6f;
		gameObject.GetComponent<SpriteRenderer> ().sprite = arrowSprites [dir];
	}

    public float originX()
    {
        if (!side) return leftOrigin;
        return rightOrigin;
    }

    public void playTone()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(playerTone(side, direction));
    }

    private static AudioClip playerTone(bool player, int dir)
    {
        string n = "";
        switch (dir)
        {
            case 0: n = "C"; break;
            case 1: n = "D"; break;
            case 2: n = "F"; break;
            case 3: n = "G"; break;
        }
        return Resources.Load<AudioClip>("Audio/P" + (player ? "2_" : "1_") + n);
    }
}
