using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ballPrefab;
    public Text aiScoreText;
    public Text playerScoreText;
    public float scoreCoordinates = 7f;
    public AIPaddle aiPaddle;
    public PlayerPaddle playerPaddle;
    private Ball currentBall; 

    // Use this for initialization
    void Start () {
        initGameScene();
    }

    private void initGameScene()
    {
        GameObject ballInstance = Instantiate (ballPrefab, transform); 
        currentBall = ballInstance.GetComponent<Ball> ();
        currentBall.transform.position = Vector3.zero; 
        setScoreText();
        aiPaddle.theBall = currentBall; 
        aiPaddle.init();
        playerPaddle.init();
    }

    private void setScoreText()
    {
        aiScoreText.text = aiPaddle.Score.ToString();
        playerScoreText.text = playerPaddle.Score.ToString ();
    }
	
    // Update is called once per frame
    void Update () {
        if (currentBall != null) {
            if (currentBall.transform.position.x > scoreCoordinates) {
                //aiScore++;
                aiPaddle.increaseScore();
                Destroy (currentBall.gameObject);
                initGameScene ();
            }

            if (currentBall.transform.position.x < -scoreCoordinates) {
                //playerScore++;
                Destroy (currentBall.gameObject);
                initGameScene ();
            }
        }
    }
}
