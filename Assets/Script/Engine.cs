using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transmission))]
public class Engine : MonoBehaviour
{
    private float targetRpm = 0.0f;
    private float throttle = 0.0f;
    public  float maxTorque  = 350.0f;
    private float currRpm = 0.0f;
    public  float  maxRpm = 7000.0f;
    private float currTorque;
    private float minRpm = 700.0f;
    public float Throttle { get => throttle;
        set 
        {
            throttle = Mathf.Clamp(value, 0.0f, 1.0f) ;
            targetRpm = throttle * maxRpm;
        }
    }

    public Transmission trans;

    private void Awake()
    {
       trans = GetComponent<Transmission>();
    }
    // Update is called once per frame

    private void updateTorque() 
    {

        currRpm = trans.rpm;


        if (currRpm < targetRpm)
        {
            currTorque = maxTorque;//Mathf.Clamp((maxRpm-currRpm)/maxRpm * throttle * maxTorque, 0.0f, targetRpm);
        }
        else 
        {
            currTorque = -maxTorque;//Mathf.Clamp((currRpm / maxRpm - throttle) *  maxTorque / 5, targetRpm, currRpm);
        }

        if (maxRpm <= currRpm)
        {
            trans.CurrGear++;
        } else if (trans.CurrGear != 0 && currRpm >= minRpm) 
        {
            trans.CurrGear--;
        }

         
            
    }  


    void Update()
    {
        //clamp in 
        if (currRpm != targetRpm)
        {
            updateTorque();
            trans.setInputTorque(currTorque);
        }
    }
}
