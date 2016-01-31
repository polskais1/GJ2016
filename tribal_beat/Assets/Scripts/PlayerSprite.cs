using UnityEngine;
using System.Collections;

public class PlayerSprite : MonoBehaviour {
    // to use playersprite: just attach to a gameobj with a spriterenderer,
    // call forceChar(...) to make his next frame be the first frame in the
    // animation of fear(1) or hope (0).
    // call changeChar() to make it so that when the next animation cycle ends,
    // he changes to the other character.

    // also use startChar to say if you want fear (true) or hope (false).
    public bool startChar = false;

    private SpriteRenderer sprite;
    // we'll be a little more incremental since player animation doesn't have to sync exactly
    private float frameDuration = 0.2f;
    private float startTime;
    private bool character, nextChar;
    private int frame;
	
	void Start () {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        forceChar(startChar);
        startTime = Time.time;
	}
	
	void Update () {
        // TEST: press space to change character
        if (Input.GetKeyDown("space"))
            changeChar(); 

        if (Time.time - frameDuration > startTime)
        {
            startTime = Time.time;

            ++frame;
            if (character) // shifting fear because sprite subimages have different sizes
            {
                float shift = 0;
                switch (frame)
                {
                    case 3: shift = -0.13f; break;
                    case 4: shift = -0.2f; break;
                    case 7: shift = 0.2f; break;
                    case 8: shift = 0.13f; break;
                }
                gameObject.transform.Translate(new Vector2(0, shift));
            }

            if (character) frame %= 11;
            else frame %= 7;
            
            if (frame == 0 && nextChar != character)
            {
                character = nextChar;
                frame = -1;
            }
            sprite.sprite = Resources.Load(spriteName(character, frame), typeof(Sprite)) as Sprite;
        }
	}

    // make the animation flow into the other character
    public void changeChar()
    {
        nextChar = !character;
    }

    // immediately set the animation to the first frame of a given character
    public void forceChar(bool fear)
    {
        frame = 0;
        character = nextChar = fear;
    }

    string spriteName(bool isFear, int f)
    {
        if (f == -1) return "images/characters/transition-02";
        return "images/characters/" + (isFear ? "fear-" : "hope-") + (f < 9 ? "0" : "") + (f+1);
    }
}
