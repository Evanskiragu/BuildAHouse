using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    public float XRotation;

    void LateUpdate()
    {
        Vector3 position = transform.position;
        position.x = Target.transform.position.x + Offset.x;
        position.z = Target.transform.position.z + Offset.z;
        position.y = Target.transform.position.y + Offset.y;
        transform.position = position;
    }

    private void OnEnable()
    {
        transform.position = new Vector3(Offset.y, 1f);
        transform.rotation = Quaternion.Euler(XRotation, 0,0);
    }
}