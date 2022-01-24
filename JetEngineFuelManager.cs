using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetEngineFuelManager : MonoBehaviour
{
    [SerializeField] float maxFuel; // 최대 연료
    float currentFuel; // 현재 연료

    [SerializeField] Slider slider_JetEngine;
    [SerializeField] Text txt_JetEngine;
    // Start is called before the first frame update

    PlayerController thePC;
    void Start()
    {
        currentFuel = maxFuel;
        slider_JetEngine.maxValue = maxFuel;
        slider_JetEngine.value = currentFuel;
        thePC = FindObjectOfType<PlayerController>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(thePC.IsJet)
        {
            currentFuel -= Time.deltaTime; // 1초에 1씩 감소
            if(currentFuel <= 0)
                currentFuel = 0;
            slider_JetEngine.value = currentFuel;
            txt_JetEngine.text = Mathf.Round(currentFuel / maxFuel * 100f).ToString() + " %";
        }
    }
}
