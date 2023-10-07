using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField]
    protected float hp;
    [SerializeField]
    protected float maxHp;
    [SerializeField]
    protected float hunger;
    [SerializeField]
    protected float maxHuger;
    [SerializeField]
    protected float thirst;
    [SerializeField]
    protected float maxThirst;

    protected State state;

    protected Dictionary<System.Type, Func<float>> possibleStates;

    protected virtual Dictionary<System.Type, Func<float>> setUpPossibleStates()
    {
        Dictionary<System.Type, Func<float>> dict = new Dictionary<System.Type, Func<float>>();

        Debug.Log("setting up states in creature");
        dict.Add(typeof(State), evaluateState);


        return dict;
    }

    protected virtual void Start()
    {
        possibleStates = setUpPossibleStates();
        state = gameObject.AddComponent<State>();
        thirst = maxThirst;
        hunger = maxHuger;
        hp = maxHp;
        StartCoroutine(updateDesires());
    }
    public void ChangeState(System.Type newState)
    {
        if (newState != typeof(State))//make sure you dont re-create the state if there is no change
        {
            Debug.Log("changing State");
            Destroy(state);
            state = (State)gameObject.AddComponent(newState);
        }
    }

    private void Update()
    {
        state.Execute(this);
    }
    public float gethp()
    {
        return hp;
    }

    public void setHp(float hp)
    {
        this.hp = hp;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
    }

    public float getHunger()
    {
        return hunger;
    }

    public void setHunger(float hunger)
    {
        this.hunger = hunger;
        if (hunger > maxHuger)
        {
            hunger = maxHuger;
        }
    }

    public float getThirst()
    {
        return thirst;
    }

    public void setThirst(float thirst)
    {
        this.thirst = thirst;
        if (thirst > maxThirst)
        {
            thirst = maxThirst;
        }
    }

    private IEnumerator updateDesires()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            this.ChangeState(chooseNextState());
        }
    }
    private System.Type chooseNextState()
    {
        Type mostDesiredState = null;
        float maxResult = float.MinValue;
        foreach(KeyValuePair<System.Type, Func<float>> entry in possibleStates){
            float result = entry.Value.Invoke();
            if(result > maxResult)
            {
                mostDesiredState = entry.Key;
                maxResult = result;
            }
        }
        Debug.Log (mostDesiredState.ToString ());
        return mostDesiredState;
    }
    private float evaluateState()
    {
        return 0;
    }
}