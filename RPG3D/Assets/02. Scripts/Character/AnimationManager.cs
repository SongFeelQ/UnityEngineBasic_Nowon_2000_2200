using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationManager : MonoBehaviour
{
    private Animator _animator;
    private int _monitorOnStateHash;
    private int _monitorOnStateHashMem;
    private int _monitorOffStateHash;
    public bool isPreviousStateHasFinished => _monitorOnStateHashMem == _monitorOffStateHash;
    public bool isCastingFinished { get; private set; }
    public float speed
    {
        get => _animator.speed;
        set => _animator.speed = value;
    }
    public bool SetCastingFinished() => isCastingFinished = true;    
    public void Play(string clipName) => _animator.Play(clipName);
    public void SetBool(string name, bool value) => _animator.SetBool(name, value);
    public void SetFloat(string name, float value) => _animator.SetFloat(name, value);
    public void GetBool(string name) => _animator.GetBool(name);
    public void GetFloat(string name) => _animator.GetFloat(name);
    public float GetNormalizedTime()
    {
        return _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        foreach (AnimatorStateMonitor monitor in _animator.GetBehaviours<AnimatorStateMonitor>())
        {
            monitor.OnEnter += (hash) =>
            {
                _monitorOnStateHashMem = _monitorOnStateHash;
                _monitorOnStateHash = hash;
                isCastingFinished = false;
            };

            monitor.OnExit += (hash) =>
            {
                _monitorOffStateHash = hash;
            };
        } 
    }
}