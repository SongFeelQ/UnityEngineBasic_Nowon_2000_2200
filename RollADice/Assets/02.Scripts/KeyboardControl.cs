using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControl : MonoBehaviour
{    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.RollADice();
        }
    }
}
