using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    public static TestButton instance;
    private Button button;

    public void Subscribe(GameObject subscriber, UnityAction action)
    {

    }

    private void Awake()
    {
        instance = this;
        button.onClick.AddListener(() => Debug.Log("Hi"));
    }
}
