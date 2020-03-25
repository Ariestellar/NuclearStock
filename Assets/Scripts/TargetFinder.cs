using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetFinder : MonoBehaviour
{ 
    [SerializeField] private List<GameObject> _listTarget;

    private int _amountTargets;
    private DataGame _dataCities;

    public void Init(DataGame dataCities, int amountTargets)
    {
        _dataCities = dataCities;
        _amountTargets = amountTargets;       
    }

    public List<GameObject> GetList()
    {             
        return _listTarget;        
    }

    public void RefreshList()
    {
        _listTarget.Clear();        
        SelectTargets(_amountTargets);        
    }

    private GameObject GetTargetAttack(List<GameObject> listCities)
    {
        GameObject target = null;
        if (listCities.Count > 1)
        {
            do
            {
                target = listCities[UnityEngine.Random.Range(0, listCities.Count)];
            }
            while (target.transform.position == transform.position || _listTarget.Contains(target));
        }
        return target;
    }

    private void SelectTargets(int amountTargets)
    {
        for (int i = 0; i < amountTargets; i++)
        {
            GameObject targetAttack = GetTargetAttack(_dataCities.GetListGeneratedCities);
            _listTarget.Add(targetAttack);
        }        
    }    
}
