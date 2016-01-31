using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Player player;
	private Player player1;
	private Player player2;
	public Player leadPlayer;
	public Player followPlayer;
	public GameObject note;
	private Stack notesToPlay = new Stack ();

	void Start () {
		player1 = Instantiate (player);
		player2 = Instantiate (player);
		player1.transform.position = new Vector2 (-3.7f, 0);
	}

	void Update () {

	}

	public void createNote (int dir, float originX) {
		GameObject newNote = Instantiate(note, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		newNote.GetComponent<Note> ().setDirection (dir);
		newNote.GetComponent<Note> ().originX = originX;
		if (originX > 0)
			notesToPlay.Push (newNote);
	}

	public void hurtPlayer (int playerNum) {
		if (playerNum == 1) {
			player1.decreaseHealth ();
		} else {
			player2.decreaseHealth ();
		}
	}

	public void popNotesToPlay (GameObject oldNote) {
		notesToPlay.Pop ();
	}

	public GameObject nextNoteToPlay () {
		return notesToPlay.Peek () as GameObject;
	}
}
