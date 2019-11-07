using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Axle))]
public class Torque : MonoBehaviour
{

    public float torque =1500.0f;
    private Axle wc;
    // Start is called before the first frame update
    void Start()
    {
      
        wc = GetComponent<Axle>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
