using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[Serializable]
public class LogFileManager : MonoBehaviour
{
    public static string DataPath;
    private static System.Random _rand;
    private static int _fileId;
    private static string _concatenatedLogString;
    private static DateTimeOffset _dto;

    //public Text LogText;

    private void Start()
    {
        _rand = new System.Random();
        _fileId = _rand.Next(1, 999999);
        DataPath = Application.persistentDataPath;
    }

    //private void Update()
    //{
    //    LogText.text = _concatenatedLogString;
    //}

    public void WriteFile()
    {
        DataPath += "/UGIW_Logfile_" + _fileId +".ugiw";
        File.WriteAllText(DataPath, _concatenatedLogString);
    }

    public void TriggerPressed()
    {
        _dto = DateTimeOffset.Now;
        _concatenatedLogString += "| UGIW | Trigger-Pressed | " 
            + _dto.LocalDateTime.ToString("dd/MM/yyyy hh:mm:ss.fff tt") + " |" + "\n";
    }

    public void GeneralPurposeLogMessage(string message)
    {
        _dto = DateTimeOffset.Now;
        _concatenatedLogString += "| UGIW | General_msg | " + message + " |"
            + _dto.LocalDateTime.ToString("dd/MM/yyyy hh:mm:ss.fff tt") + " |" + "\n";
    }
    public void PickedUp(GameObject controller)
    {
        _dto = DateTimeOffset.Now;
        _concatenatedLogString += "| UGIW | Object picked up with " + controller.name + " | "  
            + _dto.LocalDateTime.ToString("dd/MM/yyyy hh:mm:ss.fff tt") + " |" + "\n";
    }

    public void Released(GameObject controller)
    {
        _dto = DateTimeOffset.Now;
        _concatenatedLogString += "| UGIW | Object dropped with " + controller.name + " | "
            + _dto.LocalDateTime.ToString("dd/MM/yyyy hh:mm:ss.fff tt") + " |" + "\n";
    }

    public void StartHoveringInteractable(GameObject controller)
    {
        _dto = DateTimeOffset.Now;
        _concatenatedLogString += "| UGIW | Starting to hover over interactable with " + controller.name + " | "
            + _dto.LocalDateTime.ToString("dd/MM/yyyy hh:mm:ss.fff tt") + " |" + "\n";
    }
    public void EndHoveringInteractable(GameObject controller)
    {
        _dto = DateTimeOffset.Now;
        _concatenatedLogString += "| UGIW | Stops to hover over interactable with " + controller.name + " | "
            + _dto.LocalDateTime.ToString("dd/MM/yyyy hh:mm:ss.fff tt") + " |" + "\n";
    }

    public void SaveLogFile()
    {
        GeneralPurposeLogMessage("Saved on device!");
        WriteFile();
    }
}
