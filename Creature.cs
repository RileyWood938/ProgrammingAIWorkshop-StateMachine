using System.Collections;
using System.Collections.Generic;
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

    protected virtual System.Type chooseNextState()
    {
        return typeof(State);
    }

    protected virtual void Start()
    {
        state = gameObject.AddComponent<State>();
        thirst = maxThirst;
        hunger = maxHuger;
        hp = maxHp;
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
}