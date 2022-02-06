using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] Text txt_CurrentScore;
    [SerializeField] GameObject go_UI;
    [SerializeField] ScoreManager theSM;

    [SerializeField] Rigidbody playerRigid;

    public void ShowClearUI()
    {
        PlayerController.canMove = false;
        playerRigid.isKinematic = true;
        go_UI.SetActive(true);
        txt_CurrentScore.text = string.Format("{0:000,000}", theSM.GetCurrentScore());
    }
}
