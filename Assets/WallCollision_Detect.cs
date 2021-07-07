using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision_Detect : MonoBehaviour
{
    public Transform DesignatedStickWall;

    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "WallStickPoint")
        {
            StickPoint_Availability WallAvailability_;
            WallAvailability_ = collision.gameObject.GetComponent<StickPoint_Availability>();

            if (WallAvailability_.JustHitThisObject == gameObject && !GetComponent<StolenPossibility>().InPlayerPossession)
            {
                transform.position = collision.transform.position;
                transform.rotation = collision.transform.rotation;
                transform.SetParent(null);
            }            
        }
    }
}
