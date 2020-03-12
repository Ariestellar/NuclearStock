using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AssaultPolicy : MonoBehaviour
{          
    [SerializeField] private float _timerChargeDefault; 
    [SerializeField] private GameObject _timerTemp; 
    [SerializeField] private List<GameObject> _listTarget;

    private GameObject _timer;
    private bool _rocketReadiness;
    private int _amountTargets;
    private DataCities _dataCities;
    private Action<List<GameObject>> _rocketLaunch;
   
    public event Action<List<GameObject>> RocketLaunch
    {
        add => _rocketLaunch += value;
        remove => _rocketLaunch -= value;
    }  

    public void Init(DataCities dataCities, int amountTargets)

    {
        _dataCities = dataCities;
        _amountTargets = amountTargets;
        _rocketReadiness = true;
        _timer = Instantiate(_timerTemp, this.gameObject.transform);
    }

    public void SendRockets()
    {
        if (_rocketReadiness)
        {
            LaunchTimerCharge();
            SelectTargets(_amountTargets);
            _rocketLaunch?.Invoke(_listTarget);            
            _rocketReadiness = false;
            _listTarget.Clear();
        }
    }

    private void LaunchTimerCharge()
    {               
        _timer.GetComponent<Timer>().StartTimer(_timerChargeDefault, ChargeRocket);
    }

    private GameObject GetTargetAttack(List<GameObject> listCities)
    {
        GameObject target = null;
        if (listCities.Count > 1)
        {
            do
            {
                target = listCities[UnityEngine.Random.Range(0, listCities.Count)];
            }
            while (target.transform.position == transform.position || _listTarget.Contains(target));
        }
        return target;
    }

    private void ChargeRocket()
    {
        _rocketReadiness = true;
    }

    private void SelectTargets(int amountTargets)
    {
        for (int i = 0; i < amountTargets; i++)
        {
            GameObject targetAttack = GetTargetAttack(_dataCities.GetListGeneratedCities);
            _listTarget.Add(targetAttack);
        }        
    }    
}
