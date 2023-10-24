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
    public AudioSource dmg;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isDead", false);
    }
    public void TakeDamage (float amount)
    {
        health -= amount;
        dmg.Play ();
        if(health <= 0f)
        {
            animator.SetBool("isDead", true);
            Invoke("Die", 2);
            //Die();//
        }
    }
    void Die()
    {
        
        sound.Play();
        Destroy(gameObject);
        FindObjectOfType<GameManager>().addScore();
    }
}
