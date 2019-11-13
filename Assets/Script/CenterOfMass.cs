using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CenterOfMass : MonoBehaviour
{
    public Rigidbody Rb ;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Rb == null)
        {
            Rb = GetComponentInParent<Rigidbody>();
        }
        var pos = transform.position;
        Rb.centerOfMass = Rb.transform.InverseTransformPoint(pos);
    }

    // Update is called once per frame
    void Update()
    {
       // Rb.drag = Rb.velocity.magnitude / 250; //250
       // Rb.angularDrag = Rb.velocity.magnitude / 250; //250  
    }
}
