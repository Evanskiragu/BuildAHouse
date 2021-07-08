using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UpdateEnemySpeedWithSingletne : MonoBehaviour
{
    public NavMeshAgent Agent;

    public void Start()
    {
        InvokeRepeating("UpdateSpeed",0.1f, 0.1f);
    }
    
    public void UpdateSpeed()
    {
        Agent.speed = DebugMenuSingleton.Instance.EnemySpeed;
    }
}
