using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour
{
    public float timeToFade = 0.5f;
    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Mathf.Min(1, (Time.time - startTime) / timeToFade));
        if (Time.time - startTime > timeToFade)
            Destroy(this);
    }
}
