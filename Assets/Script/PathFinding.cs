using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathFinding : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;

    public float speed;


    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.speed = speed;
        agent.updateUpAxis = false;

    }

    void Update()
    {


    }


}
