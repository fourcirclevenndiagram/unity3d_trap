using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("피격 이펙트")]
    [SerializeField] GameObject go_RicochetEffect;

    [Header("총알 데미지")]
    [SerializeField] int damage;

    [Header("피격 효과음")]
    [SerializeField] string sound_Ricochet;

    void OnCollisionEnter(Collision other) // 다른 컬라이더와 충돌하는 순간 호출되는 함수, 충돌한 객체의 정보는 other에 담김
    {
        ContactPoint contactPoint = other.contacts[0]; // 충돌한 객체의 접촉면 정보가 담김
        SoundManager.instance.PlaySE(sound_Ricochet);

        var clone = Instantiate(go_RicochetEffect, contactPoint.point, Quaternion.LookRotation(contactPoint.normal)); 
                                                        // Quaternion.LookRotation : 특정 방향을 바라보게 만드는 메서드. / normal : 충돌한 컬라이더의 표면 방향
        Destroy(clone, 0.5f); // 0.5초 뒤에 파괴시킴
        Destroy(gameObject); // 현재 이 객체를 가리킴
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
