using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMove : StateBase<EnemyStates>
{
    private CharacterBase _character;
    public EnemyStateMove(EnemyStates stateType, Func<bool> condition, List<KeyValuePair<Func<bool>, EnemyStates>> transtions, GameObject owner) : base(stateType, condition, transtions, owner)
    {
        owner.GetComponent<CharacterBase>();
    }

    public override void Execute()
    {
        base.Execute();
        animationManager.SetBool("DoMove", true);
    }

    public override void Stop()
    {
        base.Stop();
        animationManager.SetBool("DoMove", false);
    }

    public override EnemyStates Tick()
    {
        EnemyStates next = stateType;
        return next;
    }
}
