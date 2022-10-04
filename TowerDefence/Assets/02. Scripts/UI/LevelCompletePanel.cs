using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelCompletePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _level;
    [SerializeField] private Transform _star1;
    [SerializeField] private Transform _star2;
    [SerializeField] private Transform _star3;
    [SerializeField] private Button _BackToLobbyButton;
    [SerializeField] private Button _ReplayButton;
    [SerializeField] private Button _NextButton;

    public void SetUp(int level, float lifeRatio, UnityAction buttonAction)
    {
        _level.text = level.ToString(); 
        _BackToLobbyButton.onClick.AddListener(buttonAction);
        _ReplayButton.onClick.AddListener(buttonAction);
        StartCoroutine(E_StarAnimation(lifeRatio));
        gameObject.SetActive(true);
    }

    IEnumerator E_StarAnimation(float lifeRatio)
    {
        yield return new WaitForSeconds(0.3f);
        if (lifeRatio >= 1f / 3f)
            _star1.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        if (lifeRatio >= 2f / 3f)
            _star2.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        if (lifeRatio >= 3f / 3f)
            _star3.GetChild(0).gameObject.SetActive(true);
    }
}
