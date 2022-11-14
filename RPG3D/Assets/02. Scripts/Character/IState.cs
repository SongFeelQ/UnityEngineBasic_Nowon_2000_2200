using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public enum Commands
    {
        Idle,
        Prepare,
        Casting,
        WaitForCastingFinished,
        Action,
        WaitForActionFinished,
        Finish,
        WaitForFinished,
    }
    public bool IsBusy { get; }
    public Commands current { get; }
    public bool canExecute { get; }
    public void Execute();
    public void Reset();
    public object Update();
    public void MoveNext();
}
