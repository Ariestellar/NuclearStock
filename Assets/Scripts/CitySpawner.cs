using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _template;  
    [SerializeField] private float _earthRadius;
    [SerializeField] private int _numberCities;
    [SerializeField] private List<GameObject> _cities;
    public List<GameObject> GetListGeneratedCities => _cities;

    private void Start()
    {
        for (int i = _numberCities; i > 0; i--)
        {
            _cities.Add(CreateCity(_template, _earthRadius));
        }     
    } 

    private GameObject CreateCity(GameObject cityTemplate, float earthRadius)
    {
        GameObject city;
        city = Instantiate(cityTemplate);
        city.transform.position = Random.onUnitSphere * earthRadius;
        city.GetComponent<RocketLaunch>().Init();
        city.GetComponent<AssaultPolicy>().Init();
        return city;
    }
}
