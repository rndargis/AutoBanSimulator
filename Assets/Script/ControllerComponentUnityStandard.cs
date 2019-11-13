using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof(CarController))]
public class ControllerComponentUnityStandard : MonoBehaviour
{
    public int PlayerNumber;
    public int ControllerNumber;
    //public string[] ControllerAssigned;
    private GameObject ControllerManager;
    private ControllerManagerComponent controllerManagerComponent;
    private CarController car = null;

    public float LeftTrigger;
    public float RightTrigger;
    public float MoveStickX;
    public float MoveStickY;
    public float CameraStickX;
    public float CameraStickY;
    public bool ButtonA;

    // Start is called before the first frame update
    void Start()
    {
        ControllerManager = GameObject.Find("Controller Manager");
        if (ControllerManager != null)
        {
            Debug.Log("Controller Manager Found!");
            controllerManagerComponent = ControllerManager.GetComponent(typeof(ControllerManagerComponent)) as ControllerManagerComponent;
            car = GetComponent<CarController>();
        }
        else
            Debug.Log("Controller Manager Not Found!");

    }

    // Update is called once per frame
    void Update()
    {
        ControllerNumber = controllerManagerComponent.GetControllerNumber(PlayerNumber);
        if (ControllerNumber > 0)
        {
            ButtonA = Input.GetKey($"joystick {ControllerNumber} button 1");
            //LeftTrigger = Input.GetAxis($"Joystick {ControllerNumber} Left Trigger");
            //RightTrigger = Input.GetAxis($"Joystick {ControllerNumber} Right Trigger");
            /*CameraStickX = Input.GetAxis($"Joystick {ControllerNumber} Camera X");
            CameraStickY = Input.GetAxis($"Joystick {ControllerNumber} Camera Y");
            MoveStickX = Input.GetAxis("Horizontal");
            MoveStickY = Input.GetAxis("Vertical");*/
            float handbrake = 0f;
            float boost = 1f;
            if (Input.GetKey($"joystick {ControllerNumber} button 0"))
                handbrake = 1f;
            if (Input.GetKey($"joystick {ControllerNumber} button 1"))
                boost = 2f;
            car.Move(Input.GetAxis("Horizontal"), Input.GetAxis($"Joystick {ControllerNumber} Right Trigger") * boost, Input.GetAxis($"Joystick {ControllerNumber} Left Trigger"), handbrake);
        }
    }
}