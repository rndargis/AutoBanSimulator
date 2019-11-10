using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(Axle))]
//currently behave like a locked diff
public class Differantial : MonoBehaviour
{

    private Axle axle;
    private float inputTorque = 0.0f;
    public float gearRatio = 1.0f;
    public float rpm { get => axle.Wheels.Average(x => x.rpm)/gearRatio; }
    public float InputTorque { get => inputTorque;
        set
        {
            inputTorque = value;
            applyTorque();
        }
    }

    private void applyTorque() 
    {
        float torque = (inputTorque * gearRatio) / 2;
        foreach (var wheel in axle.Wheels)
        {
            wheel.motorTorque= torque;
        }
    }

    private void Awake()
    {
        axle = GetComponent<Axle>();
    }
   
}
