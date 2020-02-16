using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    [SerializeField] private DataCities _dataCities;
    public void LaunchRocket()
    {
        foreach (var citi in _dataCities.GetListGeneratedCities)
        {
            citi.GetComponent<AssaultPolicy>().LaunchTimerCharge();
        }
    }
}
