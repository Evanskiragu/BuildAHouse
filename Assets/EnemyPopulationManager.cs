using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPopulationManager : MonoBehaviour
{
    public GameObject[] EnemyBases;
    int NumberOfEnemies;

    public void Start()
    {
         NumberOfEnemies = (int)DebugMenuSingleton.Instance.EnemyPopulation;
         InvokeRepeating("UpdateNumberOfEnemies",0.1f, 0.1f);
    }

    public void UpdateNumberOfEnemies()
    {
        NumberOfEnemies = (int)DebugMenuSingleton.Instance.EnemyPopulation;

        for (int i = 0; i < EnemyBases.Length; i++)
        {
            if (i < NumberOfEnemies)
            {
                EnemyBases[i].SetActive(true);
            }
            else
            {
                EnemyBases[i].SetActive(false);
            }
        }
    }
}
