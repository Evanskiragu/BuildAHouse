using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathDetermination : MonoBehaviour
{
    //PUBLIC
    public NavMeshAgent Agent;

    [Space(2f)] [Header("Locally Available Waypoints")]
    public Transform[] WayPoints;

    //PRIVATE
    bool Patrol = false;
    int WayPoint_Counter = 0;


    public void Start()
    {
        StartPathDetermination();
    }
    
    public void StartPathDetermination()
    {
        //Assign Target to NavAgent
        Agent.destination = WayPoints[WayPoint_Counter].position;
        Patrol = true;

        //Always loop to check if Agent is close to target
        StartCoroutine("Update_WayPoints");
    }

    IEnumerator Update_WayPoints()
    {
        while (Patrol)
        {
            yield return new WaitForSeconds(0.1f);

            //Calculate if player is close to WayPoint
            float distance = Vector3.Distance(WayPoints[WayPoint_Counter].position, transform.position);
            
            if (distance < 1f)
            {
                Agent.destination = WayPoints[Switch_WayPoint_Target()].position;
            }
        }
    }

    public int Switch_WayPoint_Target()
    {
        //check if we need to reset waypoint count
        if (WayPoint_Counter >= WayPoints.Length - 1)
        {
            WayPoint_Counter = 0;
        }
        else
        {
            WayPoint_Counter++;
        }
        
        return WayPoint_Counter;
    }

    public void PausePatrol()
    {
        StopCoroutine("Update_WayPoints");
        Patrol = false;
    }
}
