using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseAfterStolenWall : MonoBehaviour
{
    public EnemyPathDetermination EnemyPathDetermination_;
    public NavMeshAgent MyNavMesh;
    public Transform EyePosition;
    public Transform WallToChase;
    public bool ChaseAfterWall = false;
    public float EyeVisionDistance;
    public Transform CarryPoint;
    bool returning_wall;
    

    public void ChaseWall(Transform StolenWall)
    {
        EnemyPathDetermination_.PausePatrol();
        WallToChase = StolenWall;

        StartCoroutine("UpdateChaseWallLocation");

        ChaseAfterWall = true;
    }

    IEnumerator UpdateChaseWallLocation()
    {
        while (true)
        {
            MyNavMesh.destination = WallToChase.position;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Update()
    {
        RaycastHit Ray;

        Debug.DrawRay(EyePosition.position, EyePosition.forward * EyeVisionDistance, Color.red);

        if (ChaseAfterWall && Physics.Raycast(EyePosition.position, EyePosition.forward * EyeVisionDistance, out Ray, EyeVisionDistance))
        {
            if (Ray.collider.transform == WallToChase)
            {
                //We have found the wall we are chasing
                StopCoroutine("UpdateChaseWallLocation");
                ChaseAfterWall = false;
                ReturnTheWall();
            }
        }
    }


    public void ReturnTheWall()
    {
        WallToChase.GetComponent<StolenPossibility>().InPlayerPossession = false;
        WallToChase.SetParent(CarryPoint);
        WallToChase.transform.localPosition = Vector3.zero;
        WallToChase.transform.localRotation = Quaternion.Euler(0f,90f,0f);
        MyNavMesh.destination = WallToChase.GetComponent<WallCollision_Detect>().DesignatedStickWall.position;

        returning_wall = true;
        StartCoroutine("ReturningWall");
    }

    IEnumerator ReturningWall()
    {
        Vector3 destination = WallToChase.GetComponent<WallCollision_Detect>().DesignatedStickWall.position;

        while (returning_wall)
        {
            yield return new WaitForSeconds(0.1f);

            //Calculate if player is close to WayPoint
            float distance = Vector3.Distance(destination, transform.position);

            if (distance < 1f)
            {
                returning_wall = false;
                EnemyPathDetermination_.StartPathDetermination();
                StopCoroutine("ReturningWall");
            }
        }
    }
}
