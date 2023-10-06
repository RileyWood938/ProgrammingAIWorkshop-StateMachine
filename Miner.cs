using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

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

    private SortedList<float, System.Type> desires; //using a sortedDictionary here because unity does not support priorityQueue

    protected override void Start()
    {
        base.Start();
        desires = new SortedList<float, System.Type>();
        this.state = gameObject.AddComponent<MiningForGold>();
        ChangeState(chooseNextState());
        StartCoroutine(updateDesires());
    }

    public void ChangeGold(int goldChange)
    {
        gold += goldChange;
    }

    public void ChangedBankedGold(int bankedGoldChange)
    {
        bankedGold += bankedGoldChange;
    }

    protected override System.Type chooseNextState()
    {
        desires.Clear();
        desires.Add(evaluateMining(), typeof(MiningForGold));
        desires.Add(evaluateForaging(), typeof(Forage));
        desires.Add(evaluateHealing(), typeof(Healing));

        Debug.Log(desires.Values[desires.Count-1] + "sdf");
        return desires.Values[desires.Count - 1];
    }

    private IEnumerator updateDesires() //update the desires every half second
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            this.ChangeState(chooseNextState());
        }
    }

    private float evaluateMining()
    {
        //when neither very thirsty nor very hungry, mine
        return (35f);
    }

    private float evaluateForaging()
    {
        //when thirsty or hungry, dont mine
        Debug.Log("Forage desire: "+Mathf.Clamp((miningWeight * 0.5f * ((maxHuger / hunger) + (maxThirst / thirst))), 0, 100));
        return Mathf.Clamp((miningWeight * ((maxHuger/hunger) +(maxThirst/thirst))), 0, 100); 
    }
    private float evaluateHealing(){
        Debug.Log("Heal desire: " + Mathf.Clamp((healingWeight * Mathf.Pow((maxHp / hp), 2)), 0, 100));
        return Mathf.Clamp((healingWeight * Mathf.Pow((maxHp / hp), 2)), 0, 100);
    }
}