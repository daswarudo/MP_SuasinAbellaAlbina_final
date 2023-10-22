using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    private int enemyCount = 0;
    //public AudioSource sound;
    public Text text;
    void Start()
    {
        // Initialize enemyCount by finding all game objects with the "Enemy" tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;

        //Debug.Log("Initial Enemy Count: " + enemyCount);
    }

    void Update()
    {
        // Optionally, you can update the enemy count in real-time in the Update() method.
        // This may be useful if enemies can be spawned or destroyed during gameplay.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;

        //Debug.Log("Current Enemy Count: " + enemyCount);

        text.text = "Remaining: "+ enemyCount.ToString();

        if(enemyCount < 1)
        {
            //sound.Play();
            Invoke("End", 1); //2s delay
        }
        
    }

    void End()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
