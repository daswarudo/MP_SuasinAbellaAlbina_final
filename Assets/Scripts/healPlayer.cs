using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healPlayer : MonoBehaviour
{
    public playerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1);
    }
    
        void OnTriggerEnter(Collider other)
        {
            // Check if the trigger is with the object you want to destroy
            if (other.gameObject.CompareTag("Player"))
            {
                playerHealth.resetHealth();
                // Destroy the GameObject this script is attached to
                Destroy(gameObject);
            }
        }
    
}
