using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{

    private float hp;
    [SerializeField]
    private float maxHp;
    private float hunger;
    [SerializeField]
    private float maxHuger;
    private float thirst;
    [SerializeField]
    private float maxThirst;

    protected State state;

    private void Start()
    {
        state = gameObject.AddComponent<State>();
        thirst = maxThirst;
        hunger = maxHuger;
        hp = maxHp;
    }
    public void ChangeState(System.Type newState)
    {
        Destroy(state);
        state = (State)gameObject.AddComponent(newState.GetType());
    }
    private void Update()
    {
        state.Execute(this);
        hunger--;
        thirst--;

        if (hunger < 1)
        {
            //hungry
        }
        if (thirst < 1)
        {
            //Thirsty
        }
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