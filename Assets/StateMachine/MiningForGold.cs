 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MiningForGold<TMiner> : State<TMiner> where TMiner:Miner
{
    public MiningForGold()
    {

    }
    
    public void Execute(TMiner miner)
    {
        Debug.Log("Mining for gold");
        miner.ChangeGold(5);
    }
}
