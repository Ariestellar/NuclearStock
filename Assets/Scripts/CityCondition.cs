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
        //GetComponent<RocketLaunch>().enabled = false;
        //проблема со списком
        _dataCities.ExcludeFromList(this.gameObject);
    }

    public void Deleted()
    {
        Destroy(this.gameObject);
    }
}
