using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieMarc.EnemyVision;
using System;

public class PlayerDetecteedHandler : MonoBehaviour
{
    public EnemyVision enemy;
    public Transform[] MyWalls;
    
    public void Start()
    {
        enemy.onSeeTarget += OnSeen;
    }

    private void OnSeen(VisionTarget target, int distance)
    {
        if (target.GetComponent<PickUpWall>().WallToPickUp && Array.IndexOf(MyWalls, target.GetComponent<PickUpWall>().WallToPickUp) != -1)
        {
            //Player is carrying a wall
            //This is also the enemy's wall so chase
            GetComponent<ChaseAfterStolenWall>().ChaseWall(target.GetComponent<PickUpWall>().WallToPickUp);
        }
    }
}
