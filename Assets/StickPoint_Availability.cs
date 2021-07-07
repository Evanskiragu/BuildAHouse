using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPoint_Availability : MonoBehaviour
{
    public GameObject JustHitThisObject;
    
    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Wall" && JustHitThisObject == null)
        {
            JustHitThisObject = collision.gameObject;
            ChangeWallToNotStolen(collision.transform);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            JustHitThisObject = null;
            ChangeWallToStolen(other.transform);
        }
    }

    public void ChangeWallToStolen(Transform Wall)
    {
        if (Wall.GetComponent<WallCollision_Detect>().DesignatedStickWall == transform)
        {
            Wall.GetComponent<StolenPossibility>().Stolen = true;
        }
    }

    public void ChangeWallToNotStolen(Transform Wall)
    {
        if (Wall.GetComponent<WallCollision_Detect>().DesignatedStickWall == transform)
        {
            Wall.GetComponent<StolenPossibility>().Stolen = false;
        }
    }
}
