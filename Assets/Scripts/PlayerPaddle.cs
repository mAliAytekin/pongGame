using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    public float speed = 4f;
    private int score;
    
    public int Score
    {
        get => score; 
    }
    
    public void increaseScore()
    {
        score++;
    }

    public void increaseSpeed(float multiplier)
    {
        speed += multiplier;
    }

    public void init()
    {
        score = 0;
        speed = 4f;
    }
    
    // Use this for initialization
    void Start () {
		
    }
	
    // Update is called once per frame
    void Update () {
        float verticalMovement = Input.GetAxis ("Vertical");

        GetComponent<Rigidbody2D> ().velocity = new Vector2 (
            0,
            verticalMovement * speed
        );
    }
}
