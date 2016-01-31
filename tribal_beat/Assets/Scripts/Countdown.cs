using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour {

    public int secondsToRun = 61;
    private float endTime;

    public Text counter, leftStatus, rightStatus;

	void Start () {
        endTime = Time.time + secondsToRun;
        leftStatus.text = rightStatus.text = "";
	}

	void Update () {
        counter.text = "" + secondsRemaining();
        if (timeUp())
        {
            leftStatus.text = "LOSER";
            rightStatus.text = "WINNER";
        }
	}

    int secondsRemaining()
    {
        return (int)(endTime - Time.time);
    }

    bool timeUp()
    {
        return (endTime <= Time.time);
    }
}
