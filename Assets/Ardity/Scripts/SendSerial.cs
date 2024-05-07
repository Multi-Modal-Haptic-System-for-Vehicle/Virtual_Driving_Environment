using UnityEngine;
using System.Collections;

/**
 * Sample for reading using polling by yourself, and writing too.
 */
public class SendSerial : MonoBehaviour
{
    public SerialController serialController;
    public int signalCode = 0;

    // Initialization
    void Start()
    {
        //serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        
        Debug.Log("Press NumKeypad to execute some actions");
    }

    // Executed each frame
    void Update()
    {
        //---------------------------------------------------------------------
        // Send data
        //---------------------------------------------------------------------

        // If you press one of these keys send it to the serial device. A
        // sample serial device that accepts this input is given in the README.
        signalCode = 0;
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            Debug.Log("Sending left");
            serialController.SendSerialMessage("L");
            signalCode = 4;
        }

        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            Debug.Log("Sending right");
            serialController.SendSerialMessage("R");
            signalCode = 6;
        }

        if (Input.GetKeyUp(KeyCode.Keypad3))
        {
            Debug.Log("Sending Forward");
            serialController.SendSerialMessage("F");
            signalCode = 8;
        }

        if (Input.GetKeyUp(KeyCode.Keypad4))
        {
            Debug.Log("Sending Backward");
            serialController.SendSerialMessage("B");
            signalCode = 2;
        }

        if (Input.GetKeyUp(KeyCode.Keypad5))
        {
            Debug.Log("Sending U-turn");
            serialController.SendSerialMessage("U");
            signalCode = 5;
        }

        //---------------------------------------------------------------------
        // Receive data
        //---------------------------------------------------------------------

        string message = serialController.ReadSerialMessage();

        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Arduino Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
            Debug.Log("Message arrived: " + message);
    }
}
