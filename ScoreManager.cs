using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int currentScore; // 현재 점수
    public static int extraScore; // 아이템 점수
    int distanceScore; // 거리 점수
    float maxDistance; // 플레이어가 이동한 최대 거리

    [SerializeField] Text txt_Score;
    [SerializeField] Transform tf_Player; // 플레이어의 위치 정보

    void Update()
    {
        if(tf_Player.position.z > maxDistance)
        {
            maxDistance = tf_Player.position.z;
            distanceScore = Mathf.RoundToInt(maxDistance);
        }
        currentScore = extraScore + distanceScore;
        // txt_Score.text = currentScore.ToString();
        txt_Score.text = string.Format("{0:000,000}", currentScore);
    }

}
