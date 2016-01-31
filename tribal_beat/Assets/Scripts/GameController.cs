using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Player player1;
	public Player player2;
	public Player leadPlayer;
	public Player followPlayer;
	public GameObject note; 

	void Start () {
		leadPlayer = player1;
		followPlayer = player2;
	}

	void Update () {

	}

	public void createNote (int dir) {
		//GameObject.Instantiate (new Note (), new Vector2.zero, new Quaternion.identity);
		GameObject newNote = Instantiate(note, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		newNote.GetComponent<Note> ().setDirection (dir); 
	}
}
