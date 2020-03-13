using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private DataCities _dataCities;
    [SerializeField] private CitySpawner _citySpawner;
    [SerializeField] private int _numberCities;
    [SerializeField] private int _numberRockets;

    private DataGame _dataGame;
   
    public void CreateNewLevel()
    {
        ClearCurrentLevel();
        _dataCities.ClearData();
        _dataGame = DataGame.GetInstance();                
        _citySpawner.GeneratorCities(_dataGame.GetNumberCity());
        _dataGame.IncreaseLevel();        
    }

    private void ClearCurrentLevel()
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
}
