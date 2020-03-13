using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityCondition : MonoBehaviour
{
    private DataCities _dataCities;
    public bool IsСityDestroyed { get; private set; }

    public void Init(DataCities dataCities)
    {
        _dataCities = dataCities;
    }

    public void Destruction()
    {
        GetComponent<MeshRenderer>().enabled = false;
        IsСityDestroyed = true;
        _dataCities.ExcludeFromList(this.gameObject);
        Deleted();
    }

    public void Deleted()
    {
        Destroy(this.gameObject);
    }
}
