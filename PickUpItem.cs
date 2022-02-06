using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] Gun[] guns;

    GunController theGC;

    void Start()
    {
        theGC = FindObjectOfType<GunController>();
    }

    const int NORMAL_GUN = 0;
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Item"))
        {
            Item item = other.GetComponent<Item>();

            int extra = 0;

            if(item.itemType == ItemType.Score)
            {
                SoundManager.instance.PlaySE("Score");
                extra = item.extraScore;
                // Debug.Log(item.extraScore + "를 획득했습니다.");
                // ScoreManager.extraScore += item.extraScore;                                
                ScoreManager.extraScore += extra;
            }
            else if(item.itemType == ItemType.NormalGun_Bullet)
            {
                SoundManager.instance.PlaySE("Bullet");
                extra = item.extraScore;
                guns[NORMAL_GUN].bulletCount += extra;
                theGC.BulletUiSetting();
            }
            string message = "+" + extra;
            FloatingTextManager.instance.CreateFloatingText(other.transform.position, message);
            
            Destroy(other.gameObject);
        }
    }

}
