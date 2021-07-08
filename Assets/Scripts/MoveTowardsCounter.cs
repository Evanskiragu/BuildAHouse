using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MoveTowardsCounter : MonoBehaviour
{
    public int CoinValue;
    Transform Target;

    public void Ready()
    {
        GetComponent<TextMeshProUGUI>().text = "+ " + CoinValue;
        Target = FindObjectOfType<ScoreCounter>().transform;
        MoveTowardsScore();
    }

    public void MoveTowardsScore()
    {
        transform.DOMove(Target.position, 1f).OnComplete(ReachedTarget);
    }

    public void ReachedTarget()
    {
        Target.GetComponent<ScoreCounter>().AddScore(CoinValue);
        Destroy(gameObject);
    }
}
