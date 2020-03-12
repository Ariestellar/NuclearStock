using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private DataCities _dataCities;
    [SerializeField] private CitySpawner _citySpawner;
    [SerializeField] private int _numberCities;
    [SerializeField] private int _numberRockets;
    
    public void PlayNextLevel()
    {
        ClearLevel();
        IncreaseNumberCities();
        _citySpawner.GeneratorCities(_numberCities);
        FirstLaunchRocket();
    }

    private void ClearLevel()
    {
        var cities = _dataCities.GetListGeneratedCities;
        if (cities != null)
        {
            foreach (var city in cities)
            {
                city.GetComponent<CityCondition>().Deleted();
            }
        }
        cities.Clear();
    }

    private void FirstLaunchRocket()
    {
        foreach (var citi in _dataCities.GetListGeneratedCities)
        {
            citi.GetComponent<AssaultPolicy>().SendRockets();
        }
    }

    private void IncreaseNumberCities()
    {
        _numberCities += 1;
    }
}
