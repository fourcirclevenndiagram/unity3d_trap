using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] GameObject go_EffectPrefab;

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.name == "Player") // Hierarchy에서 취급하는 이름을 참조
        {
            other.transform.GetComponent<StatusManager>().DecreaseHp(damage);
            GameObject clone = Instantiate(go_EffectPrefab, transform.position, Quaternion.identity);
            Destroy(clone, 2f);
            Destroy(gameObject);

        }
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
