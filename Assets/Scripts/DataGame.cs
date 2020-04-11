using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataGame : MonoBehaviour
{
    [SerializeField] private CitySpawner _citySpawner;
    [SerializeField] private InfoPanel _infoPanel;
    [SerializeField] private List<GameObject> _cities;
    [SerializeField] private List<GameObject> _rocketsFired;
    [SerializeField] private int _amountTargets;
    [SerializeField] private int _numberRocketHitTarget;
    [SerializeField] private int _rocketHitLimit;
    [SerializeField] private int _rocketsLimit;
    [SerializeField] private int _rocketsCaught;
    [SerializeField] private int _currentLevel;
    [SerializeField] private int _numberRocketsCurrentLevel;
    [SerializeField] private int _numberCity;
    [SerializeField] private UnityEvent _losing;
    [SerializeField] private UnityEvent _victory;

    public int NumberRocketsCurrentLevel => _numberRocketsCurrentLevel;
    public int CurrentLevel => _currentLevel;    
    public int AmountTargets => _amountTargets;
    public List<GameObject> GetListGeneratedCities => _cities;
    public bool IsNuclearStockHasRunOut { get; private set; }

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
        DecreaseCurrentRocket();
        _rocketsFired.Add(rocket);
        if (_rocketsFired.Count  == _rocketsLimit)
        {
            IsNuclearStockHasRunOut = true;
        }        
    }

    public void ClearData()
    {
        _rocketsFired.Clear();
        _cities.Clear();
        IsNuclearStockHasRunOut = false;
        _rocketsCaught = 0;
    }

    public void SetDataNewGame()
    {
        _amountTargets = 1;//количество одновременных целей из одного города        
        _rocketHitLimit = 10;//лимит ракет для попадания
        _rocketsLimit = 2;//общий лимит ракет для запуска из всех городов    
        _currentLevel = 1;//текущий уровень
        _numberRocketsCurrentLevel = _rocketsLimit; // колличество невыпущенных ракет
        _numberCity = 2; //количество заспавненных городов 2
    }

    public void IncreaseRocketHitTarget()
    {
        _numberRocketHitTarget++;
        if (_rocketHitLimit <= _numberRocketHitTarget)
        {
            _losing?.Invoke();
        }
    }

    public int GetNumberCity()
    {
        return _numberCity;
    }

    public void DecreaseCurrentRocket()
    {
        _numberRocketsCurrentLevel--;
        _infoPanel.UpdateCountRocket(NumberRocketsCurrentLevel);

    }

    public void IncreaseLevel()
    {
        _currentLevel++;
        _numberCity++;
        _rocketsLimit++;
        _numberRocketsCurrentLevel = _rocketsLimit;
    }
}
