using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    public static Action StartTimer;
    public static Action<float> SetTime;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        StartTimer += StartTimerFunc;
        SetTime += SetTimeFunc;
    }

    private void StartTimerFunc()
    {
        StartCoroutine(StartTimerCor());
    }

    private void SetTimeFunc(float _sec)
    {
        time += _sec;
    }

    private IEnumerator StartTimerCor()
    {
        while(time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
    }
}
