using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Axle))]
public class Steering : MonoBehaviour
{
    private Axle axle;
    
    private float currentDegree =0.0f;

    public  float degreeMax = 20.0f;
    
    //for steering wheel users
    public float CurrentDegree { 
            get => currentDegree;
            set => setSteeringAngle(value);             
            }




    /// <summary>
    /// Set the steering angle
    /// </summary>
    /// <param name="value">needs to be between -1.0f and 1.0f</param>

    private void updateSteeringAngle() 
    {
        for (int i = 0; i< axle.length;i++)
        {
            float rotation = Input.GetAxis("Vertical") * (currentDegree-axle.Wheels[i].steerAngle);
            axle.WheelTransforms[i].Rotate(0, rotation, 0);

            axle.Wheels[i].steerAngle = currentDegree;
            
        }
    }
    public void setSteeringAngle(float value)
    {
        currentDegree = Mathf.Clamp(value * degreeMax, -degreeMax, degreeMax);

        updateSteeringAngle();
    }


    public void turnBy(float value) 
    {
        CurrentDegree = Mathf.Clamp(value * degreeMax+currentDegree, -degreeMax, degreeMax);
        
    }

    public void turnBy(float value , float target)
    {
        if (target > value)
        {
            CurrentDegree = Mathf.Clamp(value * degreeMax + currentDegree, value, target);
        }
        else
        {
            CurrentDegree = Mathf.Clamp(value * degreeMax + currentDegree, target, value);
        }
       
    }

    private void Awake()
    {
        axle = GetComponent<Axle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
