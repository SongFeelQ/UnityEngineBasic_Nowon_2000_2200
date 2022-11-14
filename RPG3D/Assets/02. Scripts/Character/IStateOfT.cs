using System.Collections.Generic;
using System;

public interface IState<T> where T : Enum
{
    public T stateType { get;  }
    public bool canExecute { get; }
    public void Execute()
    {
        Workflow().Reset();
    }

    public void Stop();
    public T Tick()
    {
        Workflow().MoveNext();
        return Workflow().Current;
    }

    public IEnumerator<T> Workflow();
}
