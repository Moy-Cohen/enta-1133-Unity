using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    private int _timesEnabled = 0;
    private float _timer = 0f;

    // Awake is called when the script instance is loading
    private void Awake()
    {
        Debug.Log("Awake");
    }

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Start");
    }

    private void OnEnable()
    {
        _timesEnabled++;
        Debug.Log($"I've been enabled {_timesEnabled} Times");
        _timer = 0f;
    }

    private void OnDisable()
    {
        Debug.Log($"I was updating for {_timer,0:000.000} seconds");
    }

    // Update is called once per frame
    private void Update()
    {
        _timer += Time.deltaTime; // Time between frames (in fractions of a second)
    }
}
