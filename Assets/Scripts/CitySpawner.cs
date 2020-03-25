using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _template;    
    [SerializeField] private DataGame _dataCities;
    [SerializeField] private float _earthRadius;    
    [SerializeField] private List<GameObject> _cities;
    public List<GameObject> GetListGeneratedCities => _cities;

    public void GeneratorCities(int numberCities)
    {
        for (int i = numberCities; i > 0; i--)
        {
            _cities.Add(CreateCity(_template, _earthRadius, _dataCities));
        }        
    } 

    private GameObject CreateCity(GameObject cityTemplate, float earthRadius, DataGame dataCities)
    {
        GameObject city;
        Vector3 positionSpawn = Random.onUnitSphere * earthRadius;
        city = Instantiate(cityTemplate, positionSpawn, Quaternion.identity);        
        city.GetComponent<RocketLaunch>().Init(dataCities, transform.position);
        city.GetComponent<TargetFinder>().Init(dataCities, dataCities.AmountTargets);
        city.GetComponent<CityCondition>().Init(dataCities);
        city.GetComponent<RocketPrep>().Init();
        return city;
    }
}
