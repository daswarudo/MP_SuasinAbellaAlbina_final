using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class Target : MonoBehaviour
{
    //private int score = 0;
    public float health = 50f;
    
    public AudioSource sound;
    public void TakeDamage (float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        sound.Play();
        Destroy(gameObject);
        FindObjectOfType<GameManager>().addScore();
    }
}