using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float difficultyMultiplier = 1.3f;

    public float minXSpeed = 0.8f;
    public float maxXSpeed = 1.2f;

    public float minYSpeed = 0.8f;
    public float maxYSpeed = 1.2f;

    private Rigidbody2D ballRigidbody;
    private PlayerPaddle playerPaddle;
    private AIPaddle aiPaddle;
    
    // Use this for initialization
    void Start () {
        ballRigidbody = GetComponent<Rigidbody2D> ();
        ballRigidbody.velocity = new Vector2 (
            Random.Range(minXSpeed, maxXSpeed) * (Random.value > 0.5f ? -1 : 1),
            Random.Range(minYSpeed, maxYSpeed) * (Random.value > 0.5f ? -1 : 1)
        );

        playerPaddle = GameObject.FindObjectOfType<PlayerPaddle>();
        aiPaddle =GameObject.FindObjectOfType<AIPaddle>();
         
    }
	
    // Update is called once per frame
    void Update () {
		
    }

    void OnTriggerEnter2D (Collider2D otherCollider) {
        if (otherCollider.tag == "Limit") {
            GetComponent<AudioSource> ().Play ();

            // Collided with the top limit.
            if (otherCollider.transform.position.y > transform.position.y && ballRigidbody.velocity.y > 0) {
                ballRigidbody.velocity = new Vector2 (
                    ballRigidbody.velocity.x,
                    -ballRigidbody.velocity.y
                );
            }

            // Collided with the bottom limit.
            if (otherCollider.transform.position.y < transform.position.y && ballRigidbody.velocity.y < 0) {
                ballRigidbody.velocity = new Vector2 (
                    ballRigidbody.velocity.x,
                    -ballRigidbody.velocity.y
                );
            }
        } else if (otherCollider.tag == "Paddle") {
            GetComponent<AudioSource> ().Play ();

            // Collided with the left paddle.
            if (otherCollider.transform.position.x < transform.position.x && ballRigidbody.velocity.x < 0) {
                ballRigidbody.velocity = new Vector2 (
                    -ballRigidbody.velocity.x * difficultyMultiplier,
                    ballRigidbody.velocity.y * difficultyMultiplier
                );
            }

            // Collided with the left paddle.
            if (otherCollider.transform.position.x > transform.position.x && ballRigidbody.velocity.x > 0) {
                ballRigidbody.velocity = new Vector2 (
                    -ballRigidbody.velocity.x * difficultyMultiplier,
                    ballRigidbody.velocity.y * difficultyMultiplier
                );
            }
            playerPaddle.increaseSpeed(difficultyMultiplier);
            aiPaddle.increaseSpeed(difficultyMultiplier);
        }
    }
}
