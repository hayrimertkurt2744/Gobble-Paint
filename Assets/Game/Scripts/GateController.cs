using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public Material greenColor;
    public Material orangeColor;
    public Material pinkColor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Character>().currentCharacterID == Character.CharacterID.Player)
        {
            print("değdi");
        }
    }
}
