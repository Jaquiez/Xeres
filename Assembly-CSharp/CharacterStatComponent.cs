//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class CharacterStatComponent : MonoBehaviour
{
    public GameObject manager;
    public CreateStat type;

    public void nextOption()
    {
        this.manager.GetComponent<CustomCharacterManager>().nextStatOption(this.type);
    }

    public void prevOption()
    {
        this.manager.GetComponent<CustomCharacterManager>().prevStatOption(this.type);
    }
}

