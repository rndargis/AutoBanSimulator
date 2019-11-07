using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Axle : MonoBehaviour
{

    public WheelCollider[] Wheels;
    public Transform[] WheelTransforms;
    public float  mass = 20;
    public float  wheelDampingRate = 0.25f;
    public float suspensionDistance = 0.3f;
    public float spring= 35000;
    public float damper=4500;
    public float targetPosition=0.5f;
    public float maxBreakForce = 1250;
    public int length;


    private void Awake()
    {
        length= Wheels.Length;
        WheelTransforms = new Transform[length];
        for (int i = 0; i < length; i++) 
        {
            WheelTransforms[i] = Wheels[i].GetComponent<Transform>();
        }
        
    }
    private void Start()
    {
        JointSpring suspensionSpring;
        suspensionSpring.spring = spring;
        suspensionSpring.damper = damper;
        suspensionSpring.targetPosition = targetPosition;
        foreach (WheelCollider wheel in Wheels)
        {
            wheel.suspensionSpring = suspensionSpring;
            wheel.suspensionDistance = suspensionDistance;
            wheel.mass = mass;
            wheel.wheelDampingRate = wheelDampingRate;
        }
        
    }

    private void Update()
    {
       
    }

    public void applyBreak(float val) 
    {
        float force = Mathf.Clamp(val * maxBreakForce, 0.0f, maxBreakForce);
        foreach (WheelCollider wheel in Wheels)
        {
            wheel.brakeTorque = force;
        }
       
    }

}
