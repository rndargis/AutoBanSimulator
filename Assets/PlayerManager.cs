using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using System;
public class PlayerManager : MonoBehaviour
{
    [Range(1,2)]public int nbOfPlayers = 1;
    public Transform spawn;
    public SpeedoMeter speedometer;
    public CarUserControl carModel;
    private Action[] updateSpeedo;
    private void Awake()
    {
         carModel = new CarUserControl();
        updateSpeedo = new Action[nbOfPlayers];
        for (int i = 0; i < nbOfPlayers; i++)
        {
           var car = Instantiate(carModel, spawn);

            car.camera.aspect /= nbOfPlayers;

            updateSpeedo[i] = new Action(() => { speedometer.Speed = car.getSpeed(); });
        }
         

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var up in updateSpeedo) 
        {
            up.Invoke();
        }
    }
}
