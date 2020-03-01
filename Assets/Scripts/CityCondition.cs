using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityCondition : MonoBehaviour
{
    private DataCities _dataCities;
    public void Init(DataCities dataCities)
    {
        _dataCities = dataCities;
    }
    public void Destruction()
    {
        GetComponent<MeshRenderer>().enabled = false;
        _dataCities.ExcludeFromList(this.gameObject);
    }
}
