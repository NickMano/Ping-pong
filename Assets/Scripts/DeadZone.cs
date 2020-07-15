using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    public Text playerScoreText;
    public Text oponentScoreText;
    public SceneChanger sceneChanger;


    int playerScoreQuantity = 0, oponentScoreQuantity = 0;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "PlayerWall") {
            oponentScoreQuantity++;
            updateScoreLabel(oponentScoreText, oponentScoreQuantity);
        } else if(gameObject.tag == "OponentWall") {
            playerScoreQuantity++;
            updateScoreLabel(playerScoreText, playerScoreQuantity);
        }
        checkScore();
        other.GetComponent<BallBehaviour>().gameStarted = false;
        audioSource.Play();
    }

    private void updateScoreLabel(Text label, int score) {
        label.text = score.ToString();
    }

    void checkScore() {
        if (playerScoreQuantity >= 3) {
            sceneChanger.ChangeSceneTo("WinScene");
        } else if (oponentScoreQuantity >= 3) {
            sceneChanger.ChangeSceneTo("GameOverScene");
        }
    }
}
