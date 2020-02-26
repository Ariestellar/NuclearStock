using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AssaultPolicy : MonoBehaviour
{
    [SerializeField] private DataCities _dataCities;       
    [SerializeField] private float _timerChargeDefault;
    [SerializeField] private GameObject _timerTemp;

    private Action<GameObject> _rocketLaunch;

    public event Action<GameObject> RocketLaunch
    {
        add => _rocketLaunch += value;
        remove => _rocketLaunch -= value;
    }

    public void Init()
    {
        _dataCities = FindObjectOfType<DataCities>();                
    }

    public void LaunchTimerCharge()
    {        
        GameObject targetAttack = GetTargetAttack(_dataCities.GetListGeneratedCities);

        var timer = Instantiate(_timerTemp, this.gameObject.transform);
        timer.GetComponent<Timer>().StartTimer(_timerChargeDefault,() => _rocketLaunch?.Invoke(targetAttack));
    }

    private GameObject GetTargetAttack(List<GameObject> listTarget)
    {
        GameObject target;
        do 
        {
            target = listTarget[UnityEngine.Random.Range(0, listTarget.Count)];
        } 
        while (target.transform.position == transform.position);

        return target;
    }
}
