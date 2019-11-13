using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class Transmission : MonoBehaviour
{
    private uint currGear=0;
    public uint CurrGear { 
            get => currGear;  
        set { 
            if (value < nbGears )
            {
                currGear = value;
            } 
        }
    } 
    public uint nbGears = 6;
    public float[] gears;
    public float reverseRatio;
    private float diffRatio;
    private Differantial[] differantials;
    public float rpm { get => Mathf.Abs( differantials.Average(x => x.rpm)/gears[currGear]); }

    public void toggleReverse() => currGear = (currGear == nbGears ? 0 : nbGears) ;
    

    public void setInputTorque(float torque)
    {
        foreach (var diff in differantials) 
        {
            diff.InputTorque = torque * gears[currGear];
        }
    } 
    

    private void Awake()
    {
        differantials = GetComponentsInChildren<Differantial>();
        Debug.Assert(nbGears == gears.Length);
        gears.Append(-reverseRatio);
    }

}
