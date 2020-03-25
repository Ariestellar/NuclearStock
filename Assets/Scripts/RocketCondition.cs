using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCondition : MonoBehaviour
{
    private DataGame _dataCities;

    public void Init(DataGame dataCities)
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
