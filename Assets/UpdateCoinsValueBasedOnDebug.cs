using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateCoinsValueBasedOnDebug : MonoBehaviour
{
    public TextMeshProUGUI CoinsText;

    public void Start()
    {
        InvokeRepeating("UpdateCoinsValue", 0.1f, 0.1f);
    }

    public void UpdateCoinsValue()
    {
        CoinsText.SetText("X"+DebugMenuSingleton.Instance.CoinsValue);
    }
}
