using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Speedometer _speedometer;

    // Start is called before the first frame update
    void Start()
    {
        _speedometer = GameObject.FindGameObjectWithTag("Speedometer").GetComponent<Speedometer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * _speedometer.Speed;
    }
}
