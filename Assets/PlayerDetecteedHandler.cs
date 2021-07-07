using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieMarc.EnemyVision;

public class PlayerDetecteedHandler : MonoBehaviour
{
    public EnemyVision enemy;
    
    public void Start()
    {
        enemy.onSeeTarget += OnSeen;
    }

    private void OnSeen(VisionTarget target, int distance)
    {
        //Add code for when target get seen and enemy get alerted, 0=touch, 1=near, 2=far, 3=other
        Debug.Log("Seen");
    }
}
