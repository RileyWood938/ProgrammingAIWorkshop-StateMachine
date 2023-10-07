using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MiningForGold : State
{
    public override void Execute(Creature creature)
    {
        if (creature is Miner)
        {
            Miner m = (Miner)creature;
            m.ChangeGold(5);
            //Debug.Log("Mining for gold");
        }
        else
        {
            throw new System.Exception("MiningForGolod.Execute can only be called on a Miner type creature");
        }

    }
}