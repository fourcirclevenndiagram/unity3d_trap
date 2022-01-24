using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("따라갈 플레이어 설정")]
    [SerializeField] Transform tf_Player;

    [Header("따라갈 스피드 조정")]
    [Range(0, 1f)] [SerializeField] float chaseSpeed;

    float camNormalXPos;
    
    // Start is called before the first frame update
    void Start()
    {
        camNormalXPos = transform.position.x;        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movePos = Vector3.Lerp(transform.position, tf_Player.position, chaseSpeed);
        transform.position = new Vector3(camNormalXPos, movePos.y, movePos.z);
    }
}
