using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    // from => https://forum.unity.com/threads/scripting-ai-for-2d-pong-game.229226/
    
    public Ball theBall;
    private float speed = 30;
    private float lerpSpeed = 1f;
    private Rigidbody2D rigidBody;
    private int score;

    public int Score
    {
        get => score; 
    }
    
    public void increaseScore()
    {
        score++;
    }

    public void init()
    {
        score = 0;
        speed = 30f;
    }
    
    public void increaseSpeed(float multiplier)
    {
        speed += multiplier;
    }
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
   
    void FixedUpdate () {
        if (theBall == null)
            return;
        if (theBall.transform.position.y > transform.position.y)
        {
            if (rigidBody.velocity.y < 0) rigidBody.velocity = Vector2.zero;
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.up * speed, lerpSpeed * Time.deltaTime);
        }
        else if (theBall.transform.position.y < transform.position.y)
        {
            if (rigidBody.velocity.y > 0) rigidBody.velocity = Vector2.zero;
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.down * speed, lerpSpeed * Time.deltaTime);
        }
        else
        {
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.zero * speed, lerpSpeed * Time.deltaTime);
        }
    }
}
