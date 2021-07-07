using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision_Detect : MonoBehaviour
{
    public Transform DesignatedStickWall;
    public Transform WallParent;

    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "WallStickPoint")
        {
            StickPoint_Availability WallAvailability_ = null;

            try { WallAvailability_ = collision.gameObject.GetComponent<StickPoint_Availability>(); } catch (System.Exception e) { }
            
            if (WallAvailability_ != null)
            {
                if (WallAvailability_.JustHitThisObject == gameObject && !GetComponent<StolenPossibility>().InPlayerPossession)
                {
                    //This is the enemy wall zone
                    transform.position = DesignatedStickWall.position;
                    transform.rotation = DesignatedStickWall.rotation;
                    transform.SetParent(WallParent);
                }
            }
            else
            {
                PlayerStickPoint PlayerStick = collision.gameObject.GetComponent<PlayerStickPoint>();

                if (PlayerStick.JustHitThisObject == gameObject && GetComponent<StolenPossibility>().InPlayerPossession && collision.gameObject.GetComponent<PlayerStickPoint>())
                {
                    transform.position = collision.transform.position;
                    transform.rotation = collision.transform.rotation;
                    transform.SetParent(WallParent);
                }
            }
        }
    }
}
