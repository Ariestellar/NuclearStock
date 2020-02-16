using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AssaultPolicy : MonoBehaviour
{
    [SerializeField] private DataCities _dataCities;
    [SerializeField] private float _currentTimerCharge;    
    [SerializeField] private float _timerChargeDefault;
    [SerializeField] private GameObject _targetAttack;

    private event DeathHandler _rocketLaunch;

    public delegate void DeathHandler(Transform target);
    public event DeathHandler RocketLaunch
    {
        add => _rocketLaunch += value;
        remove => _rocketLaunch -= value;
    }

    public GameObject TargetAttack => _targetAttack;



    private void Init()
    {
        _dataCities = FindObjectOfType<DataCities>();
    }

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        DecreaseChargeTimer();
    }

    public void LaunchTimerCharge()
    {
        _currentTimerCharge = _timerChargeDefault;
    }

    private void DecreaseChargeTimer()
    {
        if (_currentTimerCharge != 0)
        {
            _currentTimerCharge -= Time.deltaTime;
            if (_currentTimerCharge < 0)
            {
                _targetAttack = GetTargetAttack(_dataCities.GetListGeneratedCities);
                _rocketLaunch?.Invoke(_targetAttack.transform);
                _currentTimerCharge = 0;
            }
        }        
    }

    private GameObject GetTargetAttack(List<GameObject> listTarget)
    {        
        return listTarget[Random.Range(0, listTarget.Count)];
    }
}
