using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float lerpSpeed;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - target.position;
    }
    void Update()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, target.position+ offset,lerpSpeed);
        transform.position = newPos;
    }
}
