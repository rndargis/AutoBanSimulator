using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum ControllerAttribute { NoController = 0, Controller1, Controller2}

public class ControllerManagerComponent : MonoBehaviour
{
    public List<string> Joysticks;
    public List<string> JoysticksAssignation;
    private ControllerAttribute _Player1 = ControllerAttribute.NoController;
    private ControllerAttribute _Player2 = ControllerAttribute.NoController;
    public ControllerAttribute Player1 { get { return this._Player1; } set {
            int previousValue = (int)this._Player1;
            this._Player1 = value;

            if (value != ControllerAttribute.NoController)
            {
                onSelectedControllerChanged(1, (int)value);
            }
            else
                release(previousValue);
        }
    }
    public ControllerAttribute Player2 { get { return this._Player2; } set {
            int previousValue = (int)this._Player2;
            this._Player2 = value;
            if (value != ControllerAttribute.NoController) 
            {
                onSelectedControllerChanged(2, (int)value); 
            }
            else
                if(previousValue != 0)
                    release(previousValue);
        } 
    }
    public Action<int, int> onSelectedControllerChanged = null;
    private Dictionary<int, int> Assignation = new Dictionary<int, int>();

    public bool control(int joystickNum, int playerNumber) {
        if (joystickNum <= Joysticks.Count)
        {
            if (Assignation[joystickNum - 1] == 0 || Assignation[joystickNum - 1] == playerNumber)
            {
                Assignation[joystickNum - 1] = playerNumber;
                JoysticksAssignation[joystickNum - 1] = $"Controller {joystickNum} is assigned to player {Assignation[joystickNum - 1]}";
                return true;
            }
        }
        else
            Debug.Log($"Controller {joystickNum} not connected");
        return false;
            }
    public void release(int joystickNum) {
        Assignation[joystickNum] = 0;
    }

    private void UpdateJoytickList() {
        Joysticks = new List<string>(Input.GetJoystickNames());
    }

    public int GetControllerNumber(int playerNumber)
    {
        int controllerNumber = 0;
        foreach (KeyValuePair<int, int> entry in Assignation)
            if (entry.Value == playerNumber)
                controllerNumber = entry.Key + 1;
        return controllerNumber;

    }
    private void UpdateAssignation()
    {
        if (Assignation.Count < Joysticks.Count)
            for (int i = Assignation.Count; i < Joysticks.Count; ++i)
            {
                Assignation.Add(i, 0);
                JoysticksAssignation.Add($"Controller {i + 1} is assigned to player {Assignation[i]}");
            }
    }

void Start()
    {
        onSelectedControllerChanged = (playerNumber, controllerNumber) => { if (!control(controllerNumber, playerNumber)) { switch(playerNumber){ case 1:  Player1 = ControllerAttribute.NoController; break; case 2: Player2 = ControllerAttribute.NoController; break; } } };
    }

    // Update is called once per frame
    void Update()
    {
        UpdateJoytickList();
        UpdateAssignation();

    }
}

[CustomEditor(typeof(ControllerManagerComponent))]
public class ControllerDropdownMenu : Editor
{
    public override void OnInspectorGUI()
    {
        ControllerManagerComponent script = (ControllerManagerComponent)target;

        script.Player1 = (ControllerAttribute)EditorGUILayout.EnumPopup("Player 1", script.Player1);
        script.Player2 = (ControllerAttribute)EditorGUILayout.EnumPopup("Player 2", script.Player2);
    }

}


