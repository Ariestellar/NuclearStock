using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private DataGame _dataGame;
    [SerializeField] private CitySpawner _citySpawner;
    [SerializeField] private InfoPanel _infoPanel;

    private void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        _dataGame.SetDataNewGame();
        _citySpawner.GeneratorCities(_dataGame.GetNumberCity());        
        _infoPanel.UpdateValue(_dataGame.CurrentLevel, _dataGame.NumberRocketsCurrentLevel);
    }

    public void CreateNewLevel()
    {
        ClearCurrentLevel();
        _dataGame.ClearData();                     
        _citySpawner.GeneratorCities(_dataGame.GetNumberCity());          
        _dataGame.IncreaseLevel();
        _infoPanel.UpdateValue(_dataGame.CurrentLevel, _dataGame.NumberRocketsCurrentLevel);
    }

    private void ClearCurrentLevel()
    {        
        if (_dataGame.GetListGeneratedCities != null)
        {
            var cities = _dataGame.GetListGeneratedCities;
            foreach (var city in cities)
            {
                city.GetComponent<CityCondition>().Deleted();
            }
            cities.Clear();
        }        
    }
}
