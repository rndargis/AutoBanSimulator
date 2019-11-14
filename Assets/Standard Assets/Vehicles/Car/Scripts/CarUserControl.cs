using System;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;






    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        
        private  CarController m_Car; // the car controller we want to use
        public   string[] ControlAxis = new string[]{ "Horizontal1","Vertical1","Jump1" };
        public   Camera camera;
        public float getMaxSpeed() => m_Car.MaxSpeed;
        public float getSpeed() => m_Car.CurrentSpeed;

    public CarUserControl(Camera cam = null) 
    {
        
        camera = cam;
    }
        
        private void Awake()
        {
            // get the car controller
           
        }

    private void Start()
    {
        m_Car = GetComponent<CarController>();
        if (camera == null)
        {
            camera = GetComponentInChildren<Camera>();
        }
        
    }

    private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis(ControlAxis[0]);
            float v = CrossPlatformInputManager.GetAxis(ControlAxis[1]);
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis(ControlAxis[2]);
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
      
}

