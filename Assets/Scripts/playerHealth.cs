using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public Slider slider;
    public AudioSource sound;
    public float health = 100f;
    public Text text;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        slider.value = health;
        //text.text = "Health: " + health.ToString();
        if (health < 1)
        {
            //Debug.Log("DED");

            //FindObjectOfType<GameManager>().EndGame();
            resetHealth();
            player.transform.position = respawnPoint.transform.position;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Collision Detected with Enemy!");
            health -= 20;
            //Debug.Log("health: "+health);
            sound.Play();
        }

    }

    public void resetHealth()
    {
        health = 100f;
    }

}
