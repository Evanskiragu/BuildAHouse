using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackProgress : MonoBehaviour
{
    public GameObject Success;
    public PlayerStickPoint[] StickPoints; 

    public void Start()
    {
        InvokeRepeating("CheckProgress", 0.2f,0.2f);
    }

    public void CheckProgress()
    {
        if (StickPoints[0].JustHitThisObject && StickPoints[1].JustHitThisObject && StickPoints[2].JustHitThisObject && StickPoints[3].JustHitThisObject)
        {
            Success.SetActive(true);
        }
    }
}
