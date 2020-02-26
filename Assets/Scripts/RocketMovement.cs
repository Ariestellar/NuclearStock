using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RocketCondition))]
public class RocketMovement : MonoBehaviour
{        
    private float _speed;
    private float _flightAltitude;
    private Vector3 _targetPosition;    
    private Vector3 _earth;
    private Vector3 _axis;
    private Action _rocketHitTarget;

    public event Action RocketHitTarget
    {
        add => _rocketHitTarget += (value);
        remove => _rocketHitTarget -= (value);
    }

    private void Update()
    {
        Fly(_earth, _axis, _speed, _targetPosition);        
    }

    public void Init(GameObject target, Vector3 cityLaunch)
    {
        _speed = UnityEngine.Random.Range(10, 30);
        _flightAltitude = UnityEngine.Random.Range(5, 25);
        _earth = FindObjectOfType<CitySpawner>().transform.position;
        transform.position = GetDestination(cityLaunch, _flightAltitude, _earth);
        _targetPosition = GetDestination(target.transform.position, _flightAltitude, _earth);
        _axis = GetAxis(_targetPosition, transform.position);
    }

    private Vector3 GetAxis(Vector3 target, Vector3 currentPosition)
    {        
        return Vector3.Cross(currentPosition - target, currentPosition);
    }   

    private void Fly(Vector3 flightPathPoint, Vector3 axisRotation, float speed, Vector3 target )
    {  
        transform.RotateAround(flightPathPoint, axisRotation, speed * Time.deltaTime);
        transform.LookAt(GetDirection(_targetPosition, transform.position), GetDirection(_targetPosition, transform.position));

        if (OnPointsMatch(transform.position, _targetPosition))//В другом классе
        {
            _rocketHitTarget?.Invoke();
        }
    }

    private bool OnPointsMatch(Vector3 firstPoint, Vector3 secondPoint)//В другом классе
    {
        float measurementError = 0.5f;
        return ComparePoints(firstPoint, secondPoint) < measurementError;
    }

    private Double ComparePoints(Vector3 a, Vector3 b)//В другом классе
    {
        return Math.Sqrt(Math.Pow((a.x - b.x), 2) + Math.Pow((a.y - b.y), 2) + Math.Pow((a.z - b.z), 2));
    }

    private Vector3 GetDestination(Vector3 cityLocation, float startHeight, Vector3 flightPathPoint)
    {
        return cityLocation + GetDirection(cityLocation, flightPathPoint) * startHeight;
    }

    private Vector3 GetDirection(Vector3 whereTo, Vector3 whereFrom)
    {
        Vector3 heading = whereTo - whereFrom;
        float distance = heading.magnitude;

        return heading / distance;
    }
}
