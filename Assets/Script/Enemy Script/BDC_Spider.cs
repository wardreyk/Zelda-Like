using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BDC_Spider : MonoBehaviour
{
    NavMeshAgent agent;


    public EnemyStates currentState;

    [SerializeField]
    FunctionPathFinding functionPathFinding;

    public enum EnemyStates
    {
        FollowPlayer,
        Wandering,
        DoShoot,
        Defend,

    }

    EnemyStates SpiderState = EnemyStates.Wandering;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.speed = functionPathFinding.speed;
        agent.updateUpAxis = false;
        agent.stoppingDistance = (Random.Range(functionPathFinding.minimumRange, functionPathFinding.maximumRange));
        SpiderState = EnemyStates.Wandering;
    }

    private void Update()
    {
        doSpiderBehavior();
        updateSpiderStates();
        functionPathFinding.playerInSight();
    }

    void doSpiderBehavior()
    {
        switch (SpiderState)
        {
            case EnemyStates.FollowPlayer:
                agent.speed = functionPathFinding.followingSpeed;
                agent.acceleration = functionPathFinding.accelerationSpeed;
                functionPathFinding.FollowPlayer();
                Debug.Log("FollowPlayerActivé");
                break;

            case EnemyStates.DoShoot:

                functionPathFinding.DoShoot();
                Debug.Log("DoShoot");
                break;

            case EnemyStates.Defend:
               
                break;

            case EnemyStates.Wandering:
                functionPathFinding.Wander();
                Debug.Log("WanderingActivé");
                break;
            default:


                break;
        }
    }
    void updateSpiderStates()
    {
        if (currentState == EnemyStates.Wandering && functionPathFinding.isPlayerInDetectionRange(functionPathFinding.pathent))
        {
            currentState = EnemyStates.FollowPlayer;
            functionPathFinding.curWanderingTime = 0f;
            Debug.Log("Follow Activé");

        }
        else if (currentState == EnemyStates.FollowPlayer && functionPathFinding.playerDistance(functionPathFinding.pathent) < functionPathFinding.shootDistance)
        {
            currentState = EnemyStates.DoShoot;
            Debug.Log("DoShoot Activé");
            functionPathFinding.curFollowTime = 0f;
        }
        else if (currentState == EnemyStates.DoShoot && functionPathFinding.curShootTime >= functionPathFinding.shootTime)
        {
            currentState = EnemyStates.Wandering;
            functionPathFinding.curShootTime = 0f;
            Debug.Log("Wandering Activé");
        } 
    
    
    }
}

