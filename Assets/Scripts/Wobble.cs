﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    [Range(0.1f, 5f)]
    public float WaitBetweenWobbles = 0.5f;

    [Range(1f, 50f)]
    public float Intensity = 20f;

    Quaternion _targetAngle;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeTarget", 0, WaitBetweenWobbles);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetAngle, Time.deltaTime);

    }

    void ChangeTarget()
    {
        var intensity = Random.Range(0.1f, Intensity);
        var curve = Mathf.Sin(Random.Range(0, Mathf.PI * 2));
        _targetAngle = Quaternion.Euler(Vector3.forward * curve * intensity);
    }
}
