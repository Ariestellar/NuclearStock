using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AssaultPolicy))]
public class RocketLaunch : MonoBehaviour
{
    [SerializeField] private GameObject _rocketTemplate;

    private AssaultPolicy _assaultPolicy;
    private float _flightAltitude;
    private Vector3 _earth;
    private GameObject _rocket;

    public void Init(Vector3 earth)
    {
        _earth = earth;
        _assaultPolicy = GetComponent<AssaultPolicy>();        
        _assaultPolicy.RocketLaunch += Launch;        
        _flightAltitude = Random.Range(5, 25);
    }

    private void Launch(List<GameObject> listTarget)
    {
        foreach (var target in listTarget)
        {
            Vector3 spawnsPosition = GetDestination(transform.position, _flightAltitude, _earth);
            Vector3 targetPosition = GetDestination(target.transform.position, _flightAltitude, _earth);
            _rocket = CreateRocket(spawnsPosition);
            _rocket.GetComponent<RocketMovement>().Init(targetPosition, _earth);
            _rocket.GetComponent<ProximityCheck>().Init(targetPosition);
            _rocket.GetComponent<ProximityCheck>().RocketHitTarget += _rocket.GetComponent<RocketCondition>().Destruction;
            _rocket.GetComponent<ProximityCheck>().RocketHitTarget += target.GetComponent<CityCondition>().Destruction;
        }        
    }

    private GameObject CreateRocket(Vector3 spawnsPosition)
    {
        return Instantiate(_rocketTemplate, spawnsPosition, Quaternion.identity);
    }

    private Vector3 GetDestination(Vector3 cityLocation, float startHeight, Vector3 flightPathPoint)
    {
        return cityLocation + GetDirection(cityLocation, flightPathPoint) * startHeight;
    }

    private Vector3 GetDirection(Vector3 whereTo, Vector3 whereFrom)//Такой же метод в RocketMovement
    {
        Vector3 heading = whereTo - whereFrom;
        float distance = heading.magnitude;

        return heading / distance;
    }
}