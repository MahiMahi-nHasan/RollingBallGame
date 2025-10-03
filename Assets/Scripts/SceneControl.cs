using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;

    private int score = 0;
    private int totalSlime = 0;
    void Start()
    {
        totalSlime = GameObject.FindGameObjectsWithTag("Collectible").Length;
        Time.timeScale = 1f;
        updateScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y < -5)
        {
            RestartGame();
        }
        updateScore();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void updateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void onSlimeKill()
    {
        score++;
        updateScore();
        if (score >= totalSlime)
            winGame();
    }

    void winGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //Time.timeScale = 0f;
    }
}
