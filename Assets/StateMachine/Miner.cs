using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Xml;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using static UnityEngine.Rendering.DebugUI;

public class Miner : Creature
{
    int gold;
    int bankedGold;
    [SerializeField]
    private float miningWeight;
    [SerializeField]
    private float foragingWeight;
    [SerializeField]
    private float healingWeight;

    protected override Dictionary<System.Type, Func<float>> setUpPossibleStates()
    {
        Debug.Log("setting up states in Miner");

        Dictionary<System.Type, Func<float>> dict = base.setUpPossibleStates();

        // Add possible states for this creature here along with their evaluator functions
        // make sure that the evaluators are declared in this creature as well
        // an evaluator should be a function with no input that returns a float

        dict.Add(typeof(MiningForGold), evaluateMining);
        dict.Add(typeof(Forage), evaluateForaging);
        dict.Add(typeof(Healing), evaluateHealing);

        // 

        return dict;
    }

    protected override void Start()
    {
        base.Start();
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

    private float evaluateMining()
    {
        //when neither very thirsty nor very hungry, mine
        return (miningWeight);
    }

    private float evaluateForaging()
    {
        //when thirsty or hungry, dont mine
        return Mathf.Clamp((foragingWeight * 8 * (maxHuger / hunger) + (maxThirst / thirst)) - 8, 0, 100);
    }
    private float evaluateHealing()
    {
        return Mathf.Clamp((healingWeight * 12* Mathf.Pow((maxHp / hp), 2)), 0, 100);
    }


}