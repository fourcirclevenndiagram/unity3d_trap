using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] ParticleSystem ps_MuzzleFlash;

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
        Debug.Log("총알 발사");
        ps_MuzzleFlash.Play();

    }
    void LockOnMouse()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraPos.x));
        Vector3 target = new Vector3(0f, mousePos.y, mousePos.z);
        transform.LookAt(target);
    }
}
