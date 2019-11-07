using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    private float targetTorque = 0.0f;
    private float throttle = 0.0f;
    public  float maxTorque  = 350.0f;
    private float currTorque = 0.0f;
    public float Throttle { get => throttle;
        set 
        {
            throttle = Mathf.Clamp(value, 0.0f, 1.0f) ;
            targetTorque = throttle * maxTorque;
        }
    }

    private Differantial[] diff;

    private void Awake()
    {
       diff = GetComponentsInChildren<Differantial>();
    }
    // Update is called once per frame

    private void updateTorque() 
    {
        if (currTorque < targetTorque)
        {
            currTorque = Mathf.Clamp(currTorque + throttle * Time.deltaTime * maxTorque, 0.0f, targetTorque);
        }
        else 
        {
            currTorque = Mathf.Clamp(currTorque - (1.0f-throttle) * Time.deltaTime * maxTorque, targetTorque,currTorque);
        }
         
            
    }  


    void Update()
    {
        //clamp in 
        if (currTorque != targetTorque)
        {
            updateTorque();
            foreach (var d in diff)
            {
                d.InputTorque = currTorque;
            }
        }
    }
}
