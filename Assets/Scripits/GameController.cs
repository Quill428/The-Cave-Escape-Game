using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //int progressAmount;

    public GameObject player;

    public GameObject gameOverScreen;
    public Timer Timeset;

    public PlayerHealth playerHealth;

    public static event Action OnReset;

    public player_movement playermoves;

    public Items item;

    //add a checkpointPos vector

    void Start()
    {
        //progressAmount = 0;
        //Items.OnGemCollect += IncreaseProgressAmount;

        PlayerHealth.OnPlayerDeath += GameOverScreen;
        gameOverScreen.SetActive(false);
    }

    void GameOverScreen()
    {
        SoundEffectManager.Play("Gameover");
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void OutOfBounds()
    {
        Respawn();
    }
    public void Respawn()
    {
        //go to the check point
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            OutOfBounds();
        }
    }

    public void ResetGame()
    {
        gameOverScreen.SetActive(false);
        //OnReset.Invoke();
        Timeset.RestartTimer();
        //SceneManager.LoadScene(0);
        //playerHealth.ResetHealth();
        //Start();
        //timer.ToString = 0
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("SampleScene");

    }
       
}
