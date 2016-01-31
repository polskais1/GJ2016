using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	public Timer timer;
	public Player currentPlayer;
	public GameController gameController;

    private int startBeat, endBeat, direction;
    private float directionX, originX;

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
            if (originX > 0)
            {
                gameController.hurtPlayer(2);
                gameObject.AddComponent<FadeAway>();
                Destroy(this);
            }
            else if (gameObject.GetComponent<FadeAway>() == null)
            {
                if (originX < 0)
                    gameController.createNote(direction, true).AddComponent<FadeIn>();
                gameObject.AddComponent<FadeAway>();
            }
        }

		float fraction = (timer.fractionalBeat () - startBeat)/(endBeat - startBeat);
		gameObject.transform.position = new Vector2(originX + directionX, startY + (endY - startY)*fraction);
	}

	public void setDirection (int dir) {
		direction = dir;
		directionX = dir/1.6f;
		gameObject.GetComponent<SpriteRenderer> ().sprite = arrowSprites [dir];
	}

    public void setSide(bool side)
    {
        if (!side) originX = leftOrigin;
        else originX = rightOrigin;
    }
}
