using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform FollowTarget;
    private float _fixedY;
    private Vector3 _offset;
    private void Awake()
    {
        FollowTarget = GameObject.Find("Player").transform;
        Vector3 initialPosition = transform.position;
        _offset = initialPosition - FollowTarget.position;
        _fixedY = initialPosition.y;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = _offset + FollowTarget.position;
        newPosition.y = _fixedY;
        transform.position = newPosition;
    }
}