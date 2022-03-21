using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public void MoveTo(Vector3 targetDirection)
    {
        targetDirection += transform.localPosition;
        targetDirection.x = Mathf.Clamp(targetDirection.x, GameManager.MIN_X,GameManager.MAX_X);
        //transform.position = targetDirection;
        transform.position = Vector3.Lerp(transform.position, targetDirection, GameManager.Instance.playerSmooth * Time.deltaTime);
        
    }
}
