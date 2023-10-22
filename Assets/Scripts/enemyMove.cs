using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class enemyMove : MonoBehaviour
{
    private Animator animator;
    public NavMeshAgent enemy;//navMeshAgent
    public Transform Player;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isMoving 0", false);
        animator.SetBool("isAttack", false);
    
        
    }
    void Update()
    {
        enemy.SetDestination(Player.position);// temp moving script
        animator.SetBool("isMoving 0", true);

        if (enemy.GetComponent<Collider>().bounds.Intersects(Player.GetComponent<Collider>().bounds))
        {
            Debug.Log("asasadfsafsdf");
        }
    } 
}
