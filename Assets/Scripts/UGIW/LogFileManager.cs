using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR;

[Serializable]
public class LogFileManager : MonoBehaviour
{
    private InputDevice _rightController;
    private bool _rightTriggerValue;

    public static string DataPath;
    private static System.Random _rand = new System.Random();
    private static int _fileId = _rand.Next(1, 999999);
    private static string _concatenatedLogString;

    private void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics controllerCharacteristics = InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        foreach (InputDevice item in devices)
        {
            if (item.characteristics == InputDeviceCharacteristics.Right)
            {
                _rightController = item;
            }
        }
        _rightController.TryGetFeatureValue(CommonUsages.triggerButton, out _rightTriggerValue);

        DataPath = Application.persistentDataPath;
    }

    private void Update()
    {
        if (_rightTriggerValue)
        {
            TriggerPressed();
            WriteFile();
        }
    }

    public static void WriteFile()
    {
        DataPath += "/UGIW_Logfile_" + _fileId +".ugiw";
        File.WriteAllText(DataPath, _concatenatedLogString);
    }

    public static void TriggerPressed()
    {
        DateTimeOffset dto;
        dto = DateTimeOffset.Now;
        _concatenatedLogString += "| UGIW | Trigger-Pressed | " + dto.LocalDateTime + " |" + "\n";
    }
}
