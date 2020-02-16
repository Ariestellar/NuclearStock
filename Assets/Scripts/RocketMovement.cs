using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{        
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _target;
        
    void Update()
    {
        Fly(_target);
    }

    private void Fly(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed);
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }
}
