using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : Creature
{
    int gold;
    int bankedGold;

    void Start()
    {
        this.state = (State<Creature>)ScriptableObject.CreateInstance("MiningForGold"); //I cant create a MiningForGold object because this doesnt support creating generics.
        //The issue is that I need MiningForGold to be generic so that I can limit the state to only Miners
        //The options are: add a check to the miningForGold script to make it only work for miners but accept any creature
        //Or switch to a component-state framework
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
