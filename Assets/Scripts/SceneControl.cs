using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    public GameObject slimeFab;
    public GameObject win;

    private int score = 0;
    [SerializeField] private int totalSlime;
    void Start()
    {
        for (int i = 0; i < totalSlime; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-45, 45), 0f, Random.Range(-45, 45));
            Instantiate(slimeFab, randomPos, Quaternion.identity, transform);
        }
        Time.timeScale = 1f;
        scoreText.enabled = true;
        win.SetActive(false);
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
        scoreText.enabled = false;
        win.SetActive(true);
        Time.timeScale = 0f;
    }
}
