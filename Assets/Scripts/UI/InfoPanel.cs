using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private Text _currentLevel;
    [SerializeField] private Text _countRocket;

    private void UpdateCurrentLevel(int currentLevel)
    {
        _currentLevel.text = Convert.ToString(currentLevel);        
    }

    public void UpdateCountRocket(int countRocket)
    {
        _countRocket.text = Convert.ToString(countRocket);
    }

    public void UpdateValue(int currentLevel, int countRocket)
    {
        UpdateCurrentLevel(currentLevel);
        UpdateCountRocket(countRocket);
    }
}
