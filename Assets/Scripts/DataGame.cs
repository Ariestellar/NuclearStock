using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataGame 
{
    private static DataGame _dataGame;
    private int _currentLevel;
    private int _numberCity;
    private int _numberRockets;

    public static DataGame GetInstance()
    {
        if (_dataGame == null)
        {
            _dataGame = new DataGame();
        }
        return _dataGame;
    }

    private DataGame()
    {
        _numberCity = 2;
        _numberRockets = 2;
        _currentLevel = 1;        
    }

    public int GetCurrentLevel()
    {
        return _currentLevel;
    }

    public int GetNumberCity()
    {
        return _numberCity;
    }

    public int GetNumberRockets()
    {
        return _numberRockets;
    } 

    public void IncreaseLevel()
    { 
        _currentLevel++;
        _numberCity++;
        _numberRockets++;
    }
}
