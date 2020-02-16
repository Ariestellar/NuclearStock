using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AssaultPolicy))]
public class RocketLaunch : MonoBehaviour
{
    [SerializeField] private GameObject _rocketTemplate;
    [SerializeField] private AssaultPolicy _assaultPolicy;

    private GameObject _rocket;
    private float _startHeight = 10;

    private Vector3 _direction;
    private Vector3 _pointLaunchRocket;
    private Transform _earth;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _earth = FindObjectOfType<CitySpawner>().transform;
        _assaultPolicy = GetComponent<AssaultPolicy>();
    }

    public void Launch(Transform Target)
    {        
        _rocket = CreateRocket(GetPointLaunchRocket(_startHeight));
        //_rocket.transform.position = GetRocketFlightDirection(Target);transform.position assign attempt for 'RocketPrototype(Clone)' is not valid. Input position is { NaN, NaN, NaN }
        _rocket.GetComponent<RocketMovement>().SetTarget(Target.transform.position);
    }

    private GameObject CreateRocket(Vector3 pointLaunchRocket)
    {
        GameObject rocket = Instantiate(_rocketTemplate);
        rocket.transform.position = pointLaunchRocket;
        return rocket;
    }

    private Vector3 GetPointLaunchRocket(float startHeight)
    {
        return transform.position + GetDirection(transform, _earth) * startHeight;
    }

    private Vector3 GetRocketFlightDirection(Transform target)
    {
        return GetDirection(target, transform);
    }

    private Vector3 GetDirection(Transform whereTo, Transform whereFrom)
    {
        Vector3 heading = whereTo.position - whereFrom.transform.position;
        float distance = heading.magnitude;

        return heading / distance;
    }
}
