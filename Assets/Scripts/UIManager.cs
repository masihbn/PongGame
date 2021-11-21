using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text playerLives;
    public EventSystemCustom eventSystem;
    public GameObject p1, p2, ball;
    public Button restartBtn;

    // Start is called before the first frame update
    void Start()
    {
        playerLives.text = (p1.GetComponent<PlayerController>().lives).ToString();
        eventSystem.OnPlayerMissed.AddListener(playerMissed);
    }

    private void playerMissed()
    {
        int lives = p1.GetComponent<PlayerController>().lives - 1;
        p1.GetComponent<PlayerController>().lives = lives;
        playerLives.text = (p1.GetComponent<PlayerController>().lives).ToString();
        
        if (lives == 0)
            restartBtn.gameObject.SetActive(true);

        else
            Reset();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Reset()
    {
        p1.transform.position = p1.GetComponent<PlayerController>().startPos;
        p2.transform.position = p2.GetComponent<PlayerController>().startPos;
        ball.transform.position = ball.GetComponent<BallController>().startPos;

        ball.GetComponent<BallController>().Launch();
    }
}
