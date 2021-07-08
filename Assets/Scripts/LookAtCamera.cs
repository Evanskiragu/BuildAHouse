using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform MainCamera;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(MainCamera);  
    }
}
