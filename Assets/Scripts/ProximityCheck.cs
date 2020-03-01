using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityCheck : MonoBehaviour
{
    private Vector3 _target;
    private Action _rocketHitTarget;

    public event Action RocketHitTarget
    {
        add => _rocketHitTarget += (value);
        remove => _rocketHitTarget -= (value);
    }

    public void Init(Vector3 target)
    {
        _target = target;
    }

    private void Update()
    {
        if (OnRocketHitTarget())
        {
            _rocketHitTarget?.Invoke();
        }
    }

    private bool OnRocketHitTarget()
    {
        return OnPointsMatch(transform.position, _target);
    }    

    private bool OnPointsMatch(Vector3 firstPoint, Vector3 secondPoint)
    {
        float measurementError = 0.5f;
        return ComparePoints(firstPoint, secondPoint) < measurementError;
    }

    private Double ComparePoints(Vector3 a, Vector3 b)
    {
        return Math.Sqrt(Math.Pow((a.x - b.x), 2) + Math.Pow((a.y - b.y), 2) + Math.Pow((a.z - b.z), 2));
    }    
}
