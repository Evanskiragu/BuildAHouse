using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float CalculatedAngle = 0;
    private Vector2 direction;
    private Vector3 InitialPosition;
    private float sign = 1;
    public float Speed;
    private float PrivateSpeed;
    private float offset = 0;
    public float DecelerateionRate;
    
    
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InitialPosition = Input.mousePosition;
            PrivateSpeed = Speed;
        }
        
        if (Input.GetMouseButton(0))
        {
            if (InitialPosition != Vector3.zero)
            {
                direction = Input.mousePosition - InitialPosition;

                sign = (direction.x >= 0) ? 1 : -1;
                offset = (sign >= 0) ? 0 : 360;

                CalculatedAngle = (Vector3.Angle(Vector2.up, direction) * sign) + offset;
            }

            transform.rotation = Quaternion.Euler(new Vector3(0, CalculatedAngle, 0));
            transform.Translate(0, 0, Speed * Time.deltaTime);
        }
        else
        {
            //Decelerate
            if (PrivateSpeed > 0)
            {
                PrivateSpeed = PrivateSpeed - (Time.deltaTime * DecelerateionRate);
                transform.rotation = Quaternion.Euler(new Vector3(0, CalculatedAngle, 0));
                transform.Translate(0, 0, PrivateSpeed * Time.deltaTime);
            }
        }
    }
}
