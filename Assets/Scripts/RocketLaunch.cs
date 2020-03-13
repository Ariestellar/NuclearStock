using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetFinder))]
[RequireComponent(typeof(RocketPrep))]
public class RocketLaunch : MonoBehaviour
{
    [SerializeField] private GameObject _rocketTemplate;

    private TargetFinder _assaultPolicy;
    private RocketPrep _rocketPrep;
    private CityCondition _cityCondition;
    private float _flightAltitude;
    private Vector3 _earth;
    private DataCities _dataCities; 

    public void Init(DataCities dataCities, Vector3 earth)
    {
        _earth = earth;
        _assaultPolicy = GetComponent<TargetFinder>();
        _rocketPrep = GetComponent<RocketPrep>();
        _cityCondition = GetComponent<CityCondition>();
        _dataCities = dataCities;
        _flightAltitude = UnityEngine.Random.Range(5, 25);        
    }

    public void SendRockets()
    {
        if (_cityCondition.IsСityDestroyed == false)
        {
            _assaultPolicy.RefreshList();
            Launch(_assaultPolicy.GetList());
            _rocketPrep.StartRocketPreparing();
        }                    
    }

    private void Launch(List<GameObject> listTarget)
    {
        foreach (var target in listTarget)
        {
            if (_dataCities.IsNuclearStockHasRunOut == false)
            {
                Vector3 spawnsPosition = GetDestination(transform.position, _flightAltitude, _earth);
                Vector3 targetPosition = GetDestination(target.transform.position, _flightAltitude, _earth);
                var rocket = CreateRocket(spawnsPosition);
                rocket.GetComponent<RocketMovement>().Init(targetPosition, _earth);
                rocket.GetComponent<ProximityCheck>().Init(targetPosition);
                rocket.GetComponent<RocketCondition>().Init(_dataCities);
                rocket.GetComponent<ProximityCheck>().RocketHitTarget += rocket.GetComponent<RocketCondition>().Destruction;
                rocket.GetComponent<ProximityCheck>().RocketHitTarget += target.GetComponent<CityCondition>().Destruction;
                rocket.GetComponent<ProximityCheck>().RocketHitTarget += _dataCities.IncreaseRocketHitTarget;
                _dataCities.AddRocketsFired(rocket);                
            }
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