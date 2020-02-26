using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AssaultPolicy))]
public class RocketLaunch : MonoBehaviour
{
    [SerializeField] private GameObject _rocketTemplate;
    [SerializeField] private AssaultPolicy _assaultPolicy;

    private GameObject _rocket;

    public void Init()
    { 
        _assaultPolicy = GetComponent<AssaultPolicy>();        
        _assaultPolicy.RocketLaunch += Launch;
    }

    private void Launch(GameObject target)
    {
        _rocket = CreateRocket();        
        RocketMovement rocketMovement = _rocket.GetComponent<RocketMovement>();        
        rocketMovement.Init(target, transform.position);

        rocketMovement.RocketHitTarget += _rocket.GetComponent<RocketCondition>().Destruction;
        rocketMovement.RocketHitTarget += target.GetComponent<CityCondition>().Destruction;
    }

    private GameObject CreateRocket()
    {
        return Instantiate(_rocketTemplate);
    }
}