using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLEManagerMock : MonoBehaviour, IBLEManager
{
    private List<Characteristic> _characteristics;
    private IRCharacteristic _irCharacteristic;

    // Start is called before the first frame update
    void Start()
    {
        _irCharacteristic = new IRCharacteristic();

        _characteristics = new List<Characteristic>(
            new Characteristic[] { _irCharacteristic }
            );

        //InvokeRepeating("UpdateCharacteristics", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            _irCharacteristic.UpdateValue(BitConverter.GetBytes(1));
        }
        else
        {
            _irCharacteristic.UpdateValue(BitConverter.GetBytes(0));
        }
    }

    private void UpdateCharacteristics()
    {
        if (_irCharacteristic.Value)
        {
            _irCharacteristic.UpdateValue(BitConverter.GetBytes(0));
        }
        else
        {
            _irCharacteristic.UpdateValue(BitConverter.GetBytes(1));
        }
    }

    public T GetCharacteristic<T>() where T : Characteristic
    {
        return _characteristics.Find(c => c.GetType() == typeof(T)) as T;
    }
}
