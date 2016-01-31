using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {
	
	public int healthBarHeight;
	public int maxHeight; 
	public int healthBarWidth; 
	public GameObject redBar;
	public GameObject greenBar;
	public Vector3 position; 
	public bool isHealthLow; 
	
	
	[SerializeField]
	private int maxHealth;
	[SerializeField]
	public int currentHealth; 
	private GameObject healthBar; 
	
	private Animator animator;

	static Sprite[] healthBars = Resources.LoadAll<Sprite> ("images/health");
	
	void Start () {
		currentHealth = 5;
	}
	
	
	void Update () {
		gameObject.transform.localScale = new Vector2 (1, currentHealth);

		if (currentHealth <= maxHealth * .4 && !isHealthLow ) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = healthBars[1];
			isHealthLow = true;
		}

	}

	public void decreaseHealth(){
		if (currentHealth == 1) return;
		currentHealth -= 1; 
	}
}