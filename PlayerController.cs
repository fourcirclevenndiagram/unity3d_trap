using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool canMove = true;

    [Header("속도 관련 변수")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jetPackSpeed;

    Rigidbody myRigid;

    public bool IsJet{get; private set;} // Property : 속성이라 부르며, 변수의 참조와 수정을 따로 관리 가능. get에는 public이 생략되어있음.

    [Header("파티클 시스템(부스터)")]
    [SerializeField] ParticleSystem ps_LeftEngine;
    [SerializeField] ParticleSystem ps_RightEngine;

    AudioSource audioSource; // private이 생략되어있음.

    JetEngineFuelManager theFuel;


    // Start is called before the first frame update
    void Start()
    {
        IsJet = false;
        myRigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        theFuel = FindObjectOfType<JetEngineFuelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TryMove();
        TryJet();    
        
    }
    void TryMove()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 && canMove)
        {
            // D키 = 1, A키 = -1
            Vector3 moveDir = new Vector3(0, 0, Input.GetAxisRaw("Horizontal"));
            myRigid.AddForce(moveDir * moveSpeed);
        }
        if(Input.GetAxisRaw("Vertical") != 0 && canMove)
        {
            Vector3 moveZ = new Vector3(-Input.GetAxisRaw("Vertical"), 0, 0);
            myRigid.AddForce(moveZ * moveSpeed);
        }
    }
    void TryJet()
    {
        if(Input.GetKey(KeyCode.Space) && theFuel.IsFuel && canMove)
        {
            if(!IsJet)
            {
                ps_LeftEngine.Play();
                ps_RightEngine.Play();
                audioSource.Play();
                IsJet = true;
            }
            myRigid.AddForce(Vector3.up * jetPackSpeed);
        }
        else
        {
            if(IsJet)
            {
                ps_LeftEngine.Stop();
                ps_RightEngine.Stop();
                audioSource.Stop();
                IsJet = false;
            }
            myRigid.AddForce(Vector3.down * jetPackSpeed);
        }

    }
}
