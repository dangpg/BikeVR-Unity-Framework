using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    private IBLEManager _bleManager;
    public float RPM { get; set; }
    public float Speed { get; set; } // in meter per second
    public float Resistance = 0.002f;

    public float Diameter = 0.3f; // in meter

    private bool _prevValue;
    private bool _currentValue;

    private float _prevTime;
    private float _duration;
    
    void Start()
    {
        RPM = 0f;
        Speed = 0f;
        _bleManager = GameObject.FindGameObjectWithTag("BLEManager").GetComponent<IBLEManager>();
        _prevValue = false;
        _prevTime = 0f;
    }
    
    void Update()
    {
        var now = Time.time;
        _currentValue = _bleManager.GetCharacteristic<IRCharacteristic>().Value;
        
        if (_prevValue != _currentValue && _currentValue)
        {
            _duration = now - _prevTime;
            RPM = 60.0f / _duration;
            _prevTime = now;
            Speed = Mathf.PI * Diameter * (RPM / 60.0f);
        }
        else if (now - _prevTime > 2.0f)
        {
            RPM = 0f;
        }

        if (Speed > 0.0f)
        {
            Speed = Mathf.Max(0.0f, Speed - Resistance);
        }

        _prevValue = _currentValue;
    }
}
