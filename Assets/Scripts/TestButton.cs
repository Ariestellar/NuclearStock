using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    [SerializeField] private LevelGenerator _levelGenerator;
    public void Next()
    {
        _levelGenerator.CreateNewLevel();
    }
}
