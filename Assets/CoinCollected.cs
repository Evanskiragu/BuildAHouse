using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollected : MonoBehaviour
{
    public GameObject SpawnTextPrefab;
    Canvas MainCanvas;

    public void Start()
    {
        MainCanvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "CanBeGrabbed")
        {
            GameObject obj = Instantiate(SpawnTextPrefab);
            obj.transform.SetParent(MainCanvas.transform);
            obj.transform.localScale = new Vector3(1,1,1);

            obj.GetComponent<MoveTowardsCounter>().CoinValue = (int)DebugMenuSingleton.Instance.CoinsValue;
            obj.GetComponent<MoveTowardsCounter>().Ready();

            Destroy(transform.parent.gameObject);
        }        
    }
}
