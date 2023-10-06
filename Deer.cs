using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : Creature
{
    void Start()
    {
        this.state = gameObject.AddComponent<MiningForGold>();
    }

}
