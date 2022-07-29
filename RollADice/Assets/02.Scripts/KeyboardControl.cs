using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class KeyboardControl : MonoBehaviour
{
    private GraphicRaycaster graphicRaycaster;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.RollADice();
        }   
    }
}
