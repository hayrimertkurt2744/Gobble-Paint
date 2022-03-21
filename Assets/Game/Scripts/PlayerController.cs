using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    
    public Move moveInstance;

    private void Awake()
    {
        moveInstance = GetComponent<Move>();
    }

    private void Start()
    {
        InputManager.Instance.onTouchStart += ProcessPlayerSwere;
        InputManager.Instance.onTouchMove += ProcessPlayerSwere;
    }

    private void OnDisable()
    {
        InputManager.Instance.onTouchStart -= ProcessPlayerSwere;
        InputManager.Instance.onTouchMove -= ProcessPlayerSwere;
        
    }

    private void Update()
    {
        ProcessPlayerForwardMovement();
    }

    private void ProcessPlayerForwardMovement()
    {
        if (GameManager.Instance.currentState == GameManager.GameState.Normal)
        {
            moveInstance.MoveTo(new Vector3(0f, 0f, 1f));
        }
    }

    private void ProcessPlayerSwere()
    {
        if (GameManager.Instance.currentState == GameManager.GameState.Normal)
        { 
            moveInstance.MoveTo(new Vector3(InputManager.Instance.GetDirection().x * GameManager.Instance.horizontalSpeed, 0f, 0f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Character>() != null)
        {
            Character targetCharaterInstance = other.GetComponent<Character>();
            Character charaterInstance = GetComponent<Character>();
            
            if (targetCharaterInstance.currentCharacterID == Character.CharacterID.Stack &&
                targetCharaterInstance.currentMaterial.name == charaterInstance.currentMaterial.name)
            {
                int currentAmount = charaterInstance.characterFood;
                currentAmount++;
                charaterInstance.characterFood = currentAmount;
                GameManager.Instance.onCharacterTake?.Invoke(currentAmount);
                
                print(charaterInstance.characterFood);
                Destroy(other.gameObject);
            }
            else if (targetCharaterInstance.currentCharacterID == Character.CharacterID.Stack && 
                     targetCharaterInstance.currentMaterial.name != charaterInstance.currentMaterial.name)
            {
                int currentAmount = charaterInstance.characterFood;
                currentAmount--;
                charaterInstance.characterFood = currentAmount;
                GameManager.Instance.onCharacterTake?.Invoke(currentAmount);

                print(charaterInstance.characterFood);
                Destroy(other.gameObject);
            }
        }
    }
}
