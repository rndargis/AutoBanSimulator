using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(CarComponent))]
public class PlayerCarKeyboardControlComponnent : MonoBehaviour
{
    public KeyCode[] MovementKeys;

    private CarComponent car;
    private Action[] commands;
    private Action[] relase; 
    void Awake()
    {
        CreateCommands();
        car = GetComponent<CarComponent>();
        Debug.Assert(MovementKeys.Length == commands.Length);
    }

    private void CreateCommands()
    {
        // 0 : foward
        // 1 : left
        // 2 : breaks
        // 3 : right
        commands = new Action[]
        {
            () =>car.setGazThrottle(1.0f),
            () =>car.setSteeringTarget (-1.0f),
            () =>car.setBreaksThrottle(1.0f),
            () =>car.setSteeringTarget(1.0f)
        };

        relase = new Action[]
        {
            () => car.setGazThrottle(0.0f),
            () => car.setSteeringTarget(0.0f),
            () => car.setBreaksThrottle(0.0f),
            () => car.setSteeringTarget(0.0f)
        };
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < MovementKeys.Length; i++)
        {
            if (Input.GetKeyDown(MovementKeys[i]))
            {
                commands[i].Invoke();
            }
            if (Input.GetKeyUp(MovementKeys[i])) 
            {
                relase[i].Invoke();
            }
        }
        
    }
}
