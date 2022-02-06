using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] StageManager theSM;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            theSM.ShowClearUI();
        }
    }
}
