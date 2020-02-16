using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCities : MonoBehaviour
{
    [SerializeField] private CitySpawner _citySpawner;
    [SerializeField] private List<GameObject> _cities;
    public List<GameObject> GetListGeneratedCities => _cities;

    private void Start()
    {
        _cities = _citySpawner.GetListGeneratedCities;
    }
}
