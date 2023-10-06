using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : Creature
{
    int gold;
    int bankedGold;

    void Start()
    {
        this.state = gameObject.AddComponent<MiningForGold>();
    }

    public void ChangeGold(int goldChange)
    {
        gold += goldChange;
    }

    public void ChangedBankedGold(int bankedGoldChange)
    {
        bankedGold += bankedGoldChange;
    }
}