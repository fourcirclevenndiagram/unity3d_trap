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

            if(item.itemType == ItemType.Score)
            {
                SoundManager.instance.PlaySE("Score");
                // Debug.Log(item.extraScore + "를 획득했습니다.");
                ScoreManager.extraScore += item.extraScore;                                
            }
            else if(item.itemType == ItemType.NormalGun_Bullet)
            {
                SoundManager.instance.PlaySE("Score");
                guns[NORMAL_GUN].bulletCount += item.extraBullet;
                theGC.BulletUiSetting();
            }
            Destroy(other.gameObject);
        }
    }

}
