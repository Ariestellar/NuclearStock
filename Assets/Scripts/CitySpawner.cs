using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _template;    
    [SerializeField] private DataCities _dataCities;
    [SerializeField] private float _earthRadius;
    [SerializeField] private int _numberCities;
    [SerializeField] private List<GameObject> _cities;
    public List<GameObject> GetListGeneratedCities => _cities;

    private void Start()
    {
        for (int i = _numberCities; i > 0; i--)
        {
            _cities.Add(CreateCity(_template, _earthRadius, _dataCities));
        }        
    } 

    private GameObject CreateCity(GameObject cityTemplate, float earthRadius, DataCities dataCities)
    {
        GameObject city;
        Transform position;
        city = Instantiate(cityTemplate);
        city.transform.position = Random.onUnitSphere * earthRadius;
        city.GetComponent<RocketLaunch>().Init(transform.position);
        city.GetComponent<AssaultPolicy>().Init(dataCities);
        city.GetComponent<CityCondition>().Init(dataCities);
        return city;
    }
}
