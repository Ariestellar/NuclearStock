using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataCities : MonoBehaviour
{
    [SerializeField] private CitySpawner _citySpawner;
    [SerializeField] private List<GameObject> _cities;
    [SerializeField] private List<GameObject> _rocketsFired;
    [SerializeField] private int _amountTargets;
    [SerializeField] private int _numberRocketHitTarget;
    [SerializeField] private int _rocketHitLimit;
    [SerializeField] private int _rocketsLimit;
    [SerializeField] private int _rocketsCaught;

    [SerializeField] private UnityEvent _losing;
    [SerializeField] private UnityEvent _victory;

    [SerializeField] public bool IsNuclearStockHasRunOut { get; private set; }

    public int AmountTargets => _amountTargets;
    public List<GameObject> GetListGeneratedCities => _cities;

    private void Start()
    {
        _cities = _citySpawner.GetListGeneratedCities;
    }
    public void CatchRocket()
    {
        _rocketsCaught++;
        if (_rocketsCaught == _rocketsLimit)
        {
            _victory?.Invoke();
        }
    }

    public void ExcludeFromList(GameObject city)
    {
        _cities.Remove(city);        
    }

    public void AddRocketsFired(GameObject rocket)
    {
        if (_rocketsFired.Count < _rocketsLimit)
        {
            _rocketsFired.Add(rocket);
            if (_rocketsFired.Count  == _rocketsLimit)
            {
                IsNuclearStockHasRunOut = true;
            }
        } 
    }

    public void ClearData()
    {
        _rocketsFired.Clear();
        _cities.Clear();
        IsNuclearStockHasRunOut = false;
        _rocketsCaught = 0;
    }

    public void IncreaseRocketHitTarget()
    {
        _numberRocketHitTarget++;
        if (_rocketHitLimit <= _numberRocketHitTarget)
        {
            _losing?.Invoke();
        }
    }
}
