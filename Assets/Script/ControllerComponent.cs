using UnityEngine;

[RequireComponent(typeof(CarComponent))]
public class ControllerComponent : MonoBehaviour
{
    public int PlayerNumber;
    public int ControllerNumber;
    //public string[] ControllerAssigned;
    private GameObject ControllerManager;
    private ControllerManagerComponent controllerManagerComponent;
    private CarComponent car = null;

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
            car = GetComponent<CarComponent>();
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
            /*ButtonA = Input.GetKey($"joystick {ControllerNumber} button 0");
            LeftTrigger = Input.GetAxis($"Joystick {ControllerNumber} Left Trigger");
            RightTrigger = Input.GetAxis($"Joystick {ControllerNumber} Right Trigger");
            CameraStickX = Input.GetAxis($"Joystick {ControllerNumber} Camera X");
            CameraStickY = Input.GetAxis($"Joystick {ControllerNumber} Camera Y");
            MoveStickX = Input.GetAxis("Horizontal");
            MoveStickY = Input.GetAxis("Vertical");*/

            car.setGazThrottle(Input.GetAxis($"Joystick {ControllerNumber} Right Trigger"));
            car.setSteeringTarget(Input.GetAxis("Horizontal"));
            car.setBreaksThrottle(Input.GetAxis($"Joystick {ControllerNumber} Left Trigger"));

        }
    }
}
