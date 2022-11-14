using System;
using System.Collections.Generic;
using UnityEngine;

public class StateBase<T> : IState<T> where T : Enum
{
    public T stateType {get; protected set;}

    public bool canExecute => (_condition != null ? _condition.Invoke() : true) &&
                              _animationManager.isPreviousMachineHasFinished &&
                              _animationManager.isPreviousStateHasFinished;

    private Func<bool> _condition;
    private List<KeyValuePair<Func<bool>, T>> _transitions;
    private AnimationManager _animationManager;

    public StateBase(T stateType, Func<bool> condition, List<KeyValuePair<Func<bool>, T>> transtions, GameObject owner)
    {
        this.stateType = stateType;
        this._condition = condition;
        this._transitions = transtions;
        this._animationManager = owner.GetComponent<AnimationManager>();
    }

    public void Execute()
    {
        Workflow().Reset();
    }

    public void Stop()
    {
        Workflow().Reset();
    }
    
    public T Tick()
    {
        return Workflow().Current;
    }

    public IEnumerator<T> Workflow()
    {
        // ���� ���·� transition �������� üũ (���� ������ ���¿��� �����ϴ� ����)
        while (true)
        {
            foreach (var transition in _transitions)
            {
                if (transition.Key.Invoke())
                    yield return transition.Value;
            }
            yield return stateType;
        }
    }
}
