using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*
    bool gamehasEnded = false;
    public float restartDelay = 2f;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    public void EndGame()
    {
        if(gamehasEnded == false)
        {
            gamehasEnded = true;
            Debug.Log("GAME OVER");

            //Invoke("Restart", restartDelay); //2s delay
            Restart();
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //change to respawn later
        //FindObjectOfType<playerHealth>().resetHealth();
        //player.transform.position = respawnPoint.transform.position; //di mu reset ang health
    }

    public void Win()
    {
        SceneManager.LoadScene(1);
    }*/
    private int score = 0;
    public Text text;
    void Update()
    {
        //Debug.Log("score: "+score);
        text.text = "Score: " + score.ToString();
    }
    public void addScore()
    {
        score += 100;
    }
}
