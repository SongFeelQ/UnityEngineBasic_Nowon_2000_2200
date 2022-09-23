using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int _hp;
    public int hp
    { 
        get
        {
            return _hp;
        }
        set
        {
            if (value < 0)
                value = 0;

            _hp = value;
            _hpBar.value = (float) _hp / hpMax;
        }
    }

    public int hpMax;
    [SerializeField] private Slider _hpBar;
    [SerializeField] private Canvas _uiCanvas;

    private void Awake()
    {
        hp = hpMax;
    }
}