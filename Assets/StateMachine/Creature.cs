using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    private float hp;
    private float hunger;
    private float thirst;
    protected State<Creature> state;

    public void ChangeState(State<Creature> newState)
    {
        state = newState;
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
    }

    public float getHunger()
    {
        return hunger;
    }

    public void setHunger(float hunger)
    {
        this.hunger = hunger;
    }

    public float getThirst()
    {
        return thirst;
    }

    public void setThirst(float thirst)
    {
        this.thirst = thirst;
    }
}

