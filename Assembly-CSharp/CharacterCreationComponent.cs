//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class CharacterCreationComponent : MonoBehaviour
{
    public GameObject manager;
    public CreatePart part;

    public void nextOption()
    {
        this.manager.GetComponent<CustomCharacterManager>().nextOption(this.part);
    }

    public void prevOption()
    {
        this.manager.GetComponent<CustomCharacterManager>().prevOption(this.part);
    }
}

