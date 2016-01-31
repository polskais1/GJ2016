using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public GameController gameController;
    // Time.time is better than Time.deltaTime, but AudioSource.timeSamples is exact.
    // So... we have to throw out our tempo variable and instead rely on the fact
    // that our audio assets all have exactly 8 beats.
    public AudioSource backgroundBeat;
    private static int beatsInSoundClip = 8;

	public PlayerSprite leftSprite, rightSprite;

	public Text countDown, leftRes, rightRes, switching;

    // how long a player has to hit a beat, in fraction of a beat
    public float tolerance; 
	
    // interval values used to compute beats
	private float lastOffset = 0;
    private int loops;

	public int beatsInRound;
	private bool switched = false;

	void Start () {

	}

    void Update ()
    {
        if (backgroundBeat.timeSamples < lastOffset) ++loops;
        lastOffset = backgroundBeat.timeSamples;

		countDown.text = "" + (timeLeft () > 0 ? timeLeft () : 0);

		if (!gameOver ()) {
			leftRes.text = rightRes.text = "";
		} else {
			if (gameController.player1.currentHealth > gameController.player2.currentHealth) {
				leftRes.text = "WINNER";
				rightRes.text = "LOSER";
			} else if (gameController.player1.currentHealth < gameController.player2.currentHealth) {
				rightRes.text = "WINNER";
				leftRes.text = "LOSER";
			} else
				rightRes.text = leftRes.text = "TIE";
			foreach (GameObject note in GameObject.FindGameObjectsWithTag ("Note")) {
				Destroy (note);
			}
		}

		if (displaySwitch())
			switching.text = "SWITCHING\nLEADERS";
		else
			switching.text = "";

		if (beatsPassed () == beatsInRound / 2 && !switched) {
			gameController.switchLeaders ();
			leftSprite.changeChar();
			rightSprite.changeChar ();
			switched = true;
		} else if (beatsPassed () == beatsInRound) {
			gameController.endRound ();
		}


	}

    // returns the fractional amount of beats that have passed.
    // this is the foundation of all the other class methods.
	public float fractionalBeat () {
        // equivalent to (Time.time - startTime) / beatLength + 0.5f;
        // return (Time.time - startTime) * tempo / 60f + 0.5f;
        // but we want to sync to the audio, so we use numbers from the audio.
        return ((backgroundBeat.timeSamples + 0f) / backgroundBeat.clip.samples + loops) * beatsInSoundClip;
    }

    // returns: the number of the closest beat to now.
    // for use in inBeatWindow(), beatStatus(), etc.
    // for getting animations to align with the beat, use beatsPassed().
    public int closestBeat()
    {
        return (int)(fractionalBeat() + 0.5f);
    }

    // returns: the number of beats that have passed.
    public int beatsPassed()
    {
        return (int)fractionalBeat();
    }

	// returns: whether the game's switched the lead/follower
	public bool hasSwitched()
	{
		return switched;
	}

    // returns: whether or not we're close to a beat.
    public bool inBeatWindow () {
		float beatFraction = fractionalBeat () + 0.5f - Mathf.Round (fractionalBeat ());
		return (beatFraction < 0.5 + tolerance && beatFraction > 0.5f - tolerance);
	}

    // returns: 2 if PAST the beat window, 1 if ON the beat window, 0 if NOT YET on the beat window.
	public int beatStatus (int beat) {
        // this tells us how far away we are from the argument beat, with fractions.
        float beatDifference = fractionalBeat() + 0.0f - beat;
        if (beatDifference > tolerance) return 2;
        if (beatDifference > -tolerance) return 1;
        return 0;
	}

	public int timeLeft() {
		return (int)((beatsInRound - fractionalBeat ()) * backgroundBeat.clip.length / beatsInSoundClip);
	}

	public bool gameOver() {
		return (beatsInRound <= fractionalBeat ());
	}

	public bool displaySwitch() {
		float left = -(fractionalBeat () - beatsInRound / 2);
		float fractional = left - (int)(left);
		return (fractional <= 0.5) && (left < 3 && left >= 0);
	}
}
