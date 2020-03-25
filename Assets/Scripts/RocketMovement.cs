using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProximityCheck))]
public class RocketMovement : MonoBehaviour
{        
    private float _speed;    
    private Vector3 _targetPosition;    
    private Vector3 _earth;
    private Vector3 _axis;   

    private void Update()
    {
        Fly(_earth, _axis, _speed, _targetPosition);        
    }

    public void Init(Vector3 targetPosition, Vector3 earth)
    {
        _targetPosition  = targetPosition;
        _earth = earth;
        _speed = UnityEngine.Random.Range(5, 10);
        _axis = GetAxis(_targetPosition, transform.position);
    }

    private Vector3 GetAxis(Vector3 target, Vector3 currentPosition)
    {        
        return Vector3.Cross(currentPosition - target, currentPosition);
    }   

    private void Fly(Vector3 flightPathPoint, Vector3 axisRotation, float speed, Vector3 targetPosition )
    {  
        transform.RotateAround(flightPathPoint, axisRotation, speed * Time.deltaTime);
        transform.LookAt(GetDirection(targetPosition, transform.position), GetDirection(targetPosition, transform.position));
    }

    private Vector3 GetDirection(Vector3 whereTo, Vector3 whereFrom)//Такой же метод в RocketLaunch
    {
        Vector3 heading = whereTo - whereFrom;
        float distance = heading.magnitude;

        return heading / distance;
    }
}
