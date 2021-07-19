using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR;

[Serializable]
public class LogFileManager : MonoBehaviour
{
    public static string DataPath;
    private static System.Random _rand;
    private static int _fileId;
    private static string _concatenatedLogString;
    private static DateTimeOffset _dto;

    public string LogString;

    private void Start()
    {
        _rand = new System.Random();
        _fileId = _rand.Next(1, 999999);
        DataPath = Application.persistentDataPath;
    }

    private void Update()
    {
        LogString = _concatenatedLogString;
    }

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
}
