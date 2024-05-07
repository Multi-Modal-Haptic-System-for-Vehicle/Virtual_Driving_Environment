using UnityEngine;
using System.IO;

public class CSVManager : MonoBehaviour
{
    private static string reportDirectoryName = "Report";
    private static string reportFileName = "report.csv";
    private static string reportSeperator = ",";
    private static string[] reportHeaders = new string[3]
    {
        "Steering Wheel",
        "Break",
        "Activating Signal"
    };
    private static string timeStampHeader = "Time";

    // Interactions
    public static void AppendToReport(string[] strings)
    {
        VerifyDirectory();
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetFilePath()))
        {
            string finalString = "";
            finalString += GetTimeStamp();
            for (int i=0; i < strings.Length; i++)
            {
                if (finalString != "")
                    finalString += reportSeperator;
                finalString += strings[i];
            }
            sw.WriteLine(finalString);
        }
    }
    public static void CreateReport()
    {
        VerifyDirectory();
        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            string finalString = "";
            finalString += timeStampHeader;
            for (int i=0; i<reportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeperator;
                }
                finalString += reportHeaders[i];
            }
            sw.WriteLine(finalString);

        }
    }

    // Operations
    static void VerifyDirectory()
    {
        string dir = GetDirectoryPath();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }
    static void VerifyFile()
    {
        string file = GetFilePath();
        if (!File.Exists(file))
        {
            CreateReport();
        }
    }

    // Queries
    static string GetDirectoryPath()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }
    static string GetFilePath()
    {
        return GetDirectoryPath() + "/" + reportFileName;
    }
    static string GetTimeStamp()
    {
        System.DateTime time = System.DateTime.Now;

        string ret = time.ToString("mm:ss.fff");
        
        return ret;
        // return System.DateTime.UtcNow.ToString();
    }

}
