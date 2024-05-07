using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class MyTools
{
    [MenuItem("My Tools/Add to Report %F1")]
    static void DEV_appendToReport()
    {
        Debug.Log("<color=green>Append to Report</color>");
        CSVManager.AppendToReport(
            new string[3]
            {
                Random.Range(-10, 10).ToString(),
                Random.Range(0, 100).ToString(),
                "0"
            });
    }

    [MenuItem("My Tools/Reset Report %F2")]
    static void DEV_resetToReport()
    {
        Debug.Log("<color=red>Reset Report</color>");
        CSVManager.CreateReport();
    }
}
