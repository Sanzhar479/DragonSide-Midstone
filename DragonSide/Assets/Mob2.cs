using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob2 : Mob
{
    private void Start()
    {
        StartState(AI(SetPathFindingA(5f)));
    }
}
