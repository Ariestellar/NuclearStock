using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCondition : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destruction();
    }

    public void Destruction()
    {
        Destroy(this.gameObject);
    }
}
