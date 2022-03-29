using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public Material[] gateColors;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<Character>().currentCharacterID == Character.CharacterID.Player)
        {
            print("değdi");
        }
    }
}
