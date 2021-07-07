﻿using System.Collections;
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

    bool StartTimer = false;
    Transform WallToPickUp;


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
        WallToPickUp.GetComponent<StolenPossibility>().InPlayerPossession = true;
        WallToPickUp.GetComponent<StolenPossibility>().Stolen = true;
        WallToPickUp.SetParent(CarryPoint);
        WallToPickUp.transform.localPosition = Vector3.zero;
        WallToPickUp.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
    }
}
