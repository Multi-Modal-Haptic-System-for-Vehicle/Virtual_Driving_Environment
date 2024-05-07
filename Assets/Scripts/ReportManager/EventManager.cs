using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public LogitechSteeringWheel LSW;
    public CSVManager CSVManager;
    public SendSerial SendSerial;
    public bool isReporting = false;
    

    void report()
    {
        CSVManager.AppendToReport(
            new string[3]
            {
                LSW.inputWheel.ToString(),
                LSW.inputBreak.ToString(),
                SendSerial.signalCode.ToString()
            });
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isReporting == true)
            {
                isReporting = false;
                Debug.Log("<color=red>Stop Reporting</color>");
            }
            else if (isReporting == false)
            {
                isReporting = true;
                Debug.Log("<color=green>Reporting...</color>");
            }

        }

    }


    void FixedUpdate()
    {
        if (isReporting)
            report();
    }
}
