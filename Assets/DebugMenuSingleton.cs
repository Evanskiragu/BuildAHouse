using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugMenuSingleton : MonoBehaviour
{
    private static DebugMenuSingleton _instance;
    public static DebugMenuSingleton Instance { get { return _instance; } }

    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public float PlayerSpeed;
    public float EnemySpeed;
    public float EnemyPopulation;
    public float CoinsValue;
    public float EnemyVisionAngle;
    public float EnemyVisionDistance;


    public Slider PlayerSpeed_Slider;
    public Slider EnemySpeed_Slider;
    public Slider EnemyPopulation_Slider;
    public Slider CoinsValue_Slider;
    public Slider EnemyVisionAngle_Slider;
    public Slider EnemyVisionDistance_Slider;



    public void ValueChange(string SliderName)
    {
        switch (SliderName)
        {
            case "PlayerSpeed":
                PlayerSpeed = PlayerSpeed_Slider.value;

                break;

            case "EnemySpeed":
                EnemySpeed = EnemySpeed_Slider.value;

                break;

            case "EnemyPopulation":
                EnemyPopulation = EnemyPopulation_Slider.value;

                break;

            case "CoinsValue":

                CoinsValue = CoinsValue_Slider.value;
                break;

            case "VisionAngle":

                EnemyVisionAngle = EnemyVisionAngle_Slider.value;
                break;

            case "VisionDistance":

                EnemyVisionDistance = EnemyVisionDistance_Slider.value;
                break;                
        }
    }
}
