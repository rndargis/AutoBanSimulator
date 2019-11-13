using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Engine))]
public class CarComponent : MonoBehaviour
{
    private float currSteer = 0.0f;
    public float steerTarget { get; private set; }
    public float turnRate = 0.8f;
    
    
    

    Engine engine;
    Steering[] steering;
    Axle[] axles;

    public void setSteeringTarget(float steering) => steerTarget = steering;

    public void setBreaksThrottle(float throttle) 
    {
        if (axles[0].Wheels[0].rpm < 20)
        {
            foreach (Axle a in axles)
            {
                a.applyBreak(throttle);
            }
        }
        else {
            engine.trans.toggleReverse();
            setGazThrottle(throttle);        
        }
    }

    public void setGazThrottle(float throttle) => engine.Throttle = throttle;

    

    private void Awake()
    {
        steering =GetComponentsInChildren<Steering>();
        axles = GetComponentsInChildren<Axle>();
        engine = GetComponent<Engine>();
    }

    
   

   // Update is called once per frame
   void Update()
    {
        if (currSteer != steerTarget) 
        {
            float deltaSteer;
            if (currSteer > steerTarget)
            {
                deltaSteer = -turnRate * Time.deltaTime ;
                currSteer = Mathf.Clamp(deltaSteer + currSteer, steerTarget, currSteer);
            }
            else 
            {
                deltaSteer = turnRate * Time.deltaTime ;
                currSteer = Mathf.Clamp(deltaSteer + currSteer, currSteer, steerTarget);
            }
            foreach (Steering s in steering) 
            {
                s.CurrentDegree = currSteer;
            }
            
        }
    }
}
