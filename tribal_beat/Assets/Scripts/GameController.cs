using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Player player;
	public Player player1;
	public Player player2;
	public Player leadPlayer;
	public Player followPlayer;
	public GameObject note;
	private Stack notesToPlay = new Stack ();

	void Start () {
		player1 = Instantiate (player);
		player2 = Instantiate (player);
		leadPlayer = player1;
		player1.transform.position = new Vector2 (-3.7f, 0);
	}

	void Update () {
	}

	public GameObject createNote (int dir, bool rightSide, bool startSide) {
		GameObject newNote = Instantiate(note, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        Note myNote = newNote.GetComponent<Note>();
		myNote.setDirection (dir);
        myNote.side = rightSide;
		myNote.startSide = startSide;
       
		if (rightSide)
			notesToPlay.Push (newNote);
        return newNote;
	}

	// playerNum: whether or not to hurt the 2nd player
	public void hurtPlayer (bool playerNum) {
		if (!playerNum)
			player1.decreaseHealth ();
		else
			player2.decreaseHealth ();
	}

	public void popNotesToPlay (GameObject oldNote) {
		notesToPlay.Pop ();
	}

	public GameObject nextNoteToPlay () {
		return notesToPlay.Peek () as GameObject;
	}

	public void endRound () {
		print ("round ending");
	}

	public 	void switchLeaders () {
		print ("switching players");
		if (leadPlayer == player1) {
			leadPlayer = player2;
			followPlayer = player1;
		} else {
			leadPlayer = player1;
			followPlayer = player2;
		}
	}

	public void declareWinner () {
		if (leadPlayer == player1) {
			print ("player 1 wins!");
		} else {
			print ("player 2 wins!");
		}
	}
}
