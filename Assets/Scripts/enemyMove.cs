using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class enemyMove : MonoBehaviour
{
    private Animator animator;
    public NavMeshAgent enemy;
    public Transform Player;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isMoving 0", false);
    }
    void Update()
    {
        enemy.SetDestination(Player.position);
        animator.SetBool("isMoving 0", true);
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerCapsule")
        {
            //Debug.Log("Collision Detected with Capsule!");
        }
        
    }
}
