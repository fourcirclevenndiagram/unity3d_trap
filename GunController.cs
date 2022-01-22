using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    /* Gun 컨트롤러에서 관리하게 됐으므로, 중복된 변수가 되니까 삭제
    // [Header("총구 섬광")]
    // [SerializeField] ParticleSystem ps_MuzzleFlash;
 
    // [Header("총알 프리팹")]
    // [SerializeField] GameObject go_Bullet_Prefab;

    // [Header("총알 스피드")]
    // [SerializeField] float bulletSpeed;
    */
    [Header("현재 장착된 총")]
    [SerializeField] Gun currentGun;

    float currentFireRate;

    // Start is called before the first frame update
    void Start()
    {
        currentFireRate = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        FireRateCalc();
        TryFire();
        LockOnMouse();

    }
    void FireRateCalc()
    {
        if(currentFireRate > 0)
        {
            currentFireRate -= Time.deltaTime; // 한 프레임을 실행하는데 걸리는 시간. 약 60분의 1의 값을 지님.
        }
    }
    void TryFire()
    {
        if(Input.GetButton("Fire1"))
        {
            if(currentFireRate <= 0) // 1초에 1씩 감소하는 currentFireRate가 0보다 클 경우에는 발사 불가능
            {
                currentFireRate = currentGun.fireRate; // 다시 0.2의 값이 들어가게 됨
                Fire();
            }
        }
    }
    void Fire()
    {
        Debug.Log("Fire Bullet");
        currentGun.animator.SetTrigger("GunFire");
        // ps_MuzzleFlash.Play(); // Gun 스크립트로 뽑아냈으므로 무효한 변수명이 됨
        currentGun.ps_MuzzleFlash.Play();
        // Instantiate(go_Bullet_Prefab, ps_MuzzleFlash.transform.position, Quaternion.identity);
        // var clone = Instantiate(go_Bullet_Prefab, ps_MuzzleFlash.transform.position, Quaternion.identity); // Gun 스크립트로 뽑아냈으므로 무효한 변수명이 됨
        var clone = Instantiate(currentGun.go_Bullet_Prefab, currentGun.ps_MuzzleFlash.transform.position, Quaternion.identity); // Quaternion.identity : 회전값이 의미없을 때 사용하면 됨
        // clone.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed); // bulletSpeed를 Speed로 수정했으므로 무효한 변수명이 됨
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * currentGun.speed);
    }
    void LockOnMouse()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraPos.x));
        Vector3 target = new Vector3(0f, mousePos.y, mousePos.z);
        transform.LookAt(target);
    }
}
