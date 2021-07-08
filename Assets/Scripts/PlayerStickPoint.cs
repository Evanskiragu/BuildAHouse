using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStickPoint : MonoBehaviour
{
    public GameObject JustHitThisObject;
    public PickUpWall PickWall;
    
    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Wall" && JustHitThisObject == null)
        {
            PickWall.PlayerHasDroppedWall();
            JustHitThisObject = collision.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            JustHitThisObject = null;
        }
    }
}
