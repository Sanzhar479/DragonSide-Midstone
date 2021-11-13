using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob1 : Mob
{
    public void Notice()
    {
        StartState(AI(SetPathFindingA(3f)));
    }
}