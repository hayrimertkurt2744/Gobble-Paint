using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum CharacterID
    {
        Player,
        Stack,
        ColorChanger,
        Boss,
        None
    }

    public CharacterID currentCharacterID = CharacterID.None;
    public int characterFood = 0;
    public Material currentMaterial;

    private void Awake()
    {
        currentMaterial = GetComponent<MeshRenderer>().materials[0];
        print(currentMaterial.name);
    }
}
