using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityCondition : MonoBehaviour
{
    public void Destruction()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}
