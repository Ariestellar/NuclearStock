using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPrep : MonoBehaviour
{
    [SerializeField] private GameObject _timerTemp;
    [SerializeField] private float _timerChargeDefault;

    private GameObject _timer;
    private RocketLaunch _rocketLaunch;

    public void Init()
    {
        _rocketLaunch = GetComponent<RocketLaunch>();
        _timer = Instantiate(_timerTemp, this.gameObject.transform);
        StartRocketPreparing();        
    }

    public void StartRocketPreparing()
    {        
        LaunchTimerPreparationRocket();             
    }

    private void LaunchTimerPreparationRocket()
    {
        _timer.GetComponent<Timer>().StartTimer(_timerChargeDefault, _rocketLaunch.SendRockets);
    }
}
