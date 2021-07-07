using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PickUpWall : MonoBehaviour
{
    public Transform EyePosition;
    public float EyeVisionDistance;
    public LayerMask RayCastLayer;
    public float timer;
    public GameObject Timer_Parent;
    public Image TimerUI;
    public Transform CarryPoint;

    public Transform RightArm;
    public Transform LeftArm;

    public Transform RightArm_pos;
    public Transform LeftArm_pos;

    public Transform WallToPickUp;

    bool StartTimer = false;
    
    bool placeArms  = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit Ray;

        Debug.DrawRay(EyePosition.position, EyePosition.forward * EyeVisionDistance, Color.red);

        if (Physics.Raycast(EyePosition.position, EyePosition.forward * EyeVisionDistance, out Ray, EyeVisionDistance, RayCastLayer))
        {
            if (Ray.collider.tag == "Wall" && !Ray.collider.GetComponent<StolenPossibility>().Stolen && !StartTimer)
            {
                Timer_Parent.SetActive(true);
                TimerUI.fillAmount = 0f;
                WallToPickUp = Ray.collider.transform;
                StartTimer = true;
                PickUpWallTimer();
            }
        }
        else if(StartTimer)
        {          
            Timer_Parent.SetActive(false);
            StartTimer = false;
            StopCoroutine("Timer");
            TimerUI.fillAmount = 0f;
            TimerUI.DOKill();
        }

        //Place arms on wall being carried
        if (placeArms)
        {           
            RightArm.position = RightArm_pos.position;
            LeftArm.position = LeftArm_pos.position;
        }        
    }

    public void PickUpWallTimer()
    {
        StartCoroutine("Timer");
    }

    IEnumerator Timer()
    {
        TimerUI.DOFillAmount(1, timer);
        yield return new WaitForSeconds(timer);      
        ReadyToPickUpWall();
    }

    public void ReadyToPickUpWall()
    {
        placeArms = true;
        WallToPickUp.GetComponent<StolenPossibility>().InPlayerPossession = true;
        WallToPickUp.GetComponent<StolenPossibility>().Stolen = true;
        WallToPickUp.SetParent(CarryPoint);
        WallToPickUp.transform.localPosition = Vector3.zero;
        WallToPickUp.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
    }

    public void PlayerHasDroppedWall()
    {
        placeArms = false;
        WallToPickUp = null;
    }
}
