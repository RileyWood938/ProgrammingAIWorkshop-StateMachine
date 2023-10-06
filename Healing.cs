using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Healing : State
{
    public override void Execute(Creature creature)
    {
        creature.setHp(creature.gethp() + 1);
        Debug.Log("healing");
    }
}