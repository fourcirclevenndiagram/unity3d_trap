using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("따라갈 플레이어 설정")]
    [SerializeField] Transform tf_Player;

    [Header("따라갈 스피드 조정")]
    [Range(0, 1f)] [SerializeField] float chaseSpeed;

    float camNormalXPos; // 평상시, CurrentX에 Normal를 대입
    [SerializeField] [Header("부스터시 떨어질 x거리")]
    float camJetXPos; // 부스터시, CurrentX에 JetX를 대입
    float camCurrentXPos;

    PlayerController thePlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = tf_Player.GetComponent<PlayerController>();
        camNormalXPos = transform.position.x;
        camCurrentXPos = camNormalXPos;        
    }

    // Update is called once per frame
    void Update()
    {
        if(thePlayer.IsJet)
            camCurrentXPos = camJetXPos;
        else
            camCurrentXPos = camNormalXPos;
        Vector3 movePos = Vector3.Lerp(transform.position, tf_Player.position, chaseSpeed);
        float cameraPosX = Mathf.Lerp(transform.position.x, camCurrentXPos, chaseSpeed); // Vector3.Lerp의 Float버전
        // transform.position = new Vector3(camNormalXPos, movePos.y, movePos.z);
        // transform.position = new Vector3(camCurrentXPos, movePos.y, movePos.z);
        transform.position = new Vector3(cameraPosX, movePos.y, movePos.z);
    }
}
