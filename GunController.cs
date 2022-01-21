using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("총구 섬광")]
    [SerializeField] ParticleSystem ps_MuzzleFlash;

    [Header("총알 프리팹")]
    [SerializeField] GameObject go_Bullet_Prefab;

    [Header("총알 스피드")]
    [SerializeField] float bulletSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TryFire();
        LockOnMouse();

    }
    void TryFire()
    {
        if(Input.GetButton("Fire1"))
        {
            Fire();

        }
    }
    void Fire()
    {
        Debug.Log("Fire Bullet");
        ps_MuzzleFlash.Play();
        // Instantiate(go_Bullet_Prefab, ps_MuzzleFlash.transform.position, Quaternion.identity);
        var clone = Instantiate(go_Bullet_Prefab, ps_MuzzleFlash.transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }
    void LockOnMouse()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraPos.x));
        Vector3 target = new Vector3(0f, mousePos.y, mousePos.z);
        transform.LookAt(target);
    }
}
