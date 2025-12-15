using UnityEngine;
using System.IO; // Required for file operations

public class TextFileCreator : MonoBehaviour
{
    public string fileName = "MyGameData.txt"; // Name of the file
    public string folderName = "SaveData"; // Name of the folder to store the file

    void Start()
    {
        CreateAndWriteToFile();
    }

    void CreateAndWriteToFile()
    {
        // Define the path for the folder and file
        string folderPath = Path.Combine(Application.persistentDataPath, folderName);
        string filePath = Path.Combine(folderPath, fileName);

        // Create the directory if it doesn't exist
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Debug.Log("Created directory: " + folderPath);
        }

        // Content to write to the file
        string content = "This is some sample data for my game.\n";
        content += "Player Name: John Doe\n";
        content += "Score: 12345\n";
        content += "Date: " + System.DateTime.Now.ToString();

        try
        {
            // Write all content to the file. If the file doesn't exist, it will be created.
            // If it exists, its content will be overwritten.
            File.WriteAllText(filePath, content);
            Debug.Log("Text file created and written to: " + filePath);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error writing to file: " + ex.Message);
        }
    }
}
