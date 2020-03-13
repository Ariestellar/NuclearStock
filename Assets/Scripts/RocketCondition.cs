using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCondition : MonoBehaviour
{
    private DataCities _dataCities;

    public void Init(DataCities dataCities)
    {
        _dataCities = dataCities;
    }

    private void OnMouseDown()
    {
        Destruction();
        _dataCities.CatchRocket();
    }

    public void Destruction()
    {
        Destroy(this.gameObject);
    }
}
