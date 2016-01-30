using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Player player1;
	public Player player2;
	public Player leadPlayer;
	public GameObject note; 

	void Start () {
		//instantiate 2 players with lead player being set randomly
		leadPlayer = player1;
	}

	void Update () {

	}

	public void createNote () {
		//GameObject.Instantiate (new Note (), new Vector2.zero, new Quaternion.identity);
		Instantiate(note, new Vector3(0, 0, 0), Quaternion.identity);
	}
}
