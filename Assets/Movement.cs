using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private int _directionIndex = 1;
    private Rigidbody _rigidbody;
    private float _speed = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _directionIndex = _directionIndex == 1 ? 0 : 1;
        }
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    Vector3 GetDirection()
    {
        if (_directionIndex == 0)
            return Vector3.right;

        return Vector3.forward;
    }
    void FixedUpdate()
    {
        Vector3 velocity = GetDirection() * _speed;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }
    
    private void OnDisable()
    {
        Vector3 velocity = Vector3.zero;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }
}
