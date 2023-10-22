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

    public float startWaitTime = 4;
    public float timeToRotate = 2;
    public float speedWalk = 6;
    public float speedRun = 9;

    public float viewRadius = 15;
    public float viewAngle = 90;
    public LayerMask playerMask;
    public LayerMask obstacleMask;
    public float meshResolution = 1f;
    public int edgeIterations = 4;
    public float edgeDistance = .5f;

    public Transform[] waypoints;
    int m_CurrentWaypontIndex;

    Vector3 playerLastPosition = Vector3.zero;
    Vector3 m_PlayerPosition;

    float m_WaitTime;
    float m_TimeToRotate;
    bool m_PlayerInRange;
    bool m_PlayerNear;
    bool m_IsPatrol;
    bool m_CaughtPlayer;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isMoving 0", false);
        animator.SetBool("isAttack", false);

        m_PlayerPosition = Vector3.zero;
        m_IsPatrol = true;
        m_CaughtPlayer = false;
        m_PlayerInRange = false;
        m_WaitTime = startWaitTime;
        m_TimeToRotate = timeToRotate;

        m_CurrentWaypontIndex = 0;
        enemy = GetComponent<NavMeshAgent>();

        enemy.isStopped = false;
        enemy.speed = speedWalk;
        enemy.SetDestination(waypoints[m_CurrentWaypontIndex].position);
        
    }
    void Update()
    {
        enemy.SetDestination(Player.position);// temp moving script
        animator.SetBool("isMoving 0", true);
        /*EnvironmentView();

        if (!m_IsPatrol)
        {
            Chasing();
        }
        else
        {
            Patroling();
        }
        */
    }
    /*
    private void Chasing()
    {
        m_PlayerNear = false;
        playerLastPosition = Vector3.zero;

        if(!m_CaughtPlayer)
        {
            Move(speedRun);
            enemy.SetDestination(m_PlayerPosition);
        }
        if(enemy.remainingDistance <= enemy.stoppingDistance)
        {
            if(m_WaitTime <= 0 && !m_CaughtPlayer && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position)>=6f)
            {
                m_IsPatrol = true;
                m_PlayerNear=false;
                Move(speedWalk);
                m_TimeToRotate=timeToRotate;
                m_WaitTime = startWaitTime;
                enemy.SetDestination(waypoints[m_CurrentWaypontIndex].position);
            }
            else
            {
                if (Vector3.Distance(transform.position,GameObject.FindGameObjectWithTag("Player").transform.position) >= 2.5f)
                {
                    Stop();
                    m_WaitTime -= Time.deltaTime;
                }
            }
            
        }
    }
    private void Patroling()
    {
        if (m_PlayerNear) 
        { 
            if(m_TimeToRotate <= 0)
            {
                Move(speedWalk);
                LookingPlayer(playerLastPosition);
            }
            else
            {
                Stop();
                m_TimeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            m_PlayerNear = false;
            playerLastPosition = Vector3.zero;
            enemy.SetDestination(waypoints[m_CurrentWaypontIndex].position);
            if(enemy.remainingDistance <= enemy.stoppingDistance)
            {
                if(m_WaitTime <= 0)
                {
                    NextPoint();
                    Move(speedWalk);
                    m_WaitTime = startWaitTime;
                }
                else
                {
                    Stop();
                    m_WaitTime -= Time.deltaTime;
                }
            }
        }
    }
    void Move(float speed)
    {
        enemy.isStopped = false;
        enemy.speed = speed;
    }

    void Stop()
    {
        enemy.isStopped = true;
        enemy.speed = 0;
    }

    public void NextPoint()
    {
        m_CurrentWaypontIndex = (m_CurrentWaypontIndex + 1) % waypoints.Length;
        enemy.SetDestination(waypoints[m_CurrentWaypontIndex].position);
    }

    void CaughtPlayer()
    {
        m_CaughtPlayer = true;
    }
    void LookingPlayer(Vector3 player)
    {
        enemy.SetDestination(player);
        if(Vector3.Distance(transform.position, player) <= 0.3)
        {
            if(m_WaitTime <= 0)
            {
                m_PlayerNear = false;
                Move(speedWalk);
                enemy.SetDestination(waypoints[m_CurrentWaypontIndex].position);
                m_WaitTime = startWaitTime;
                m_TimeToRotate = timeToRotate;
            }
            else
            {
                Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }
    void EnvironmentView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);

        for(int i=0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            
            if(Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2)
            {
                float dstToPlayer = Vector3.Distance(transform.position, player.position);
                if(!Physics.Raycast(transform.position, dirToPlayer, dstToPlayer, obstacleMask))
                {
                    m_PlayerInRange = true;
                    m_IsPatrol = false;
                }
                else
                {
                    m_PlayerInRange = false;
                }
            }
            if(Vector3.Distance(transform.position, player.position) > viewRadius)
            {
                m_PlayerInRange = false;
            }
            if (m_PlayerInRange)
            {
                m_PlayerPosition = player.transform.position;
            }
        }
        
    }
    */
    /*
    void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.gameObject.name == "PlayerCapsule")
        {
            animator.SetBool("isAttack", true);
        }
        
        else
        {
            animator.SetBool("isAttack", false);
            animator.SetBool("isMoving 0", true);
        }
        
    }*/
}
