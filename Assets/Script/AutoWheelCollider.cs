using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//automaticaly adjust the radius of wheelcollider
[RequireComponent(typeof(WheelCollider))]
public class AutoWheelCollider : MonoBehaviour
{ 
    private void Start()
    {  
       
        WheelCollider wheel = GetComponent<WheelCollider>();

        Mesh mesh = GetComponent<MeshFilter>().mesh;

     


        //if the game object has no mesh whe don't want the editor
        //to create one for us. So whe do not include it in [RequiresComponent]

        Debug.Assert(mesh != null,"The AutoWheelColider needs a mesh");
        Bounds bound = mesh.bounds;
        wheel.radius = bound.size.y/2;
        wheel.center = bound.center;
           
    }
    

    
}
