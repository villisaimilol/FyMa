using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fillbar : MonoBehaviour
{
    [SerializeField] private Image Progress;
    [SerializeField] private float amount = 0.1f;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && Progress.fillAmount >= 0)
        {
            Progress.fillAmount -= amount;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && Progress.fillAmount <= 1)
        {
            Progress.fillAmount += amount;
        }
    }
}
