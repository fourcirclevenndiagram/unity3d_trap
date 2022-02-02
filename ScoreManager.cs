using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int currentScore; // 현재 점수
    public static int extraScore; // 아이템 점수

    [SerializeField] Text txt_Score;

    void Update()
    {
        currentScore = extraScore;
        txt_Score.text = currentScore.ToString();
    }

}
