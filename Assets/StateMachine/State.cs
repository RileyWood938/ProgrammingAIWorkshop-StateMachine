using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class State<TCreature> : ScriptableObject where TCreature : Creature
{
    public State()
    {

    }

    public virtual void Execute(TCreature creature)
    {

    }
}
