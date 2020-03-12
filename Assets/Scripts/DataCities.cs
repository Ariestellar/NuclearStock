using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataCities : MonoBehaviour
{
    [SerializeField] private CitySpawner _citySpawner;
    [SerializeField] private List<GameObject> _cities;
    [SerializeField] private UnityEvent _listCitiesEmpty;
    [SerializeField] private int _amountTargets;

    public int AmountTargets => _amountTargets;
    public List<GameObject> GetListGeneratedCities => _cities;

    private void Start()
    {
        _cities = _citySpawner.GetListGeneratedCities;
    }

    public void ExcludeFromList(GameObject city)
    {
        _cities.Remove(city);
        /*if (_cities.Count <= 1)
        {
            _listCitiesEmpty?.Invoke();
        }   */   
    }    
}
