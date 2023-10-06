using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forage : State
{
    public override void Execute(Creature creature)
    {
        Debug.Log("LookingForFood");
    }


}