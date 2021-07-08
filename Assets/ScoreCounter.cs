using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI ScoreDisplay;
    public int score_counter = 0;

    public void AddScore(int incoming)
    {
        score_counter += incoming;
        ScoreDisplay.text = "Coins:  "+ score_counter;
    }
}
