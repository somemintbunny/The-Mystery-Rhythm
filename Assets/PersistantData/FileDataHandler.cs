using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq.Expressions;
public class FileDataHandler
{
    private string dataDirtPath = "";

    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirtPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        // path.combine works for multiple OS's which is pretty cool
        string fullPath = Path.Combine(dataDirtPath, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                // load le data
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //deserialize
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error while saving to file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }
    public void save(GameData data)
    {
        // path.combine works for multiple OS's which is pretty cool
        string fullPath = Path.Combine(dataDirtPath, dataFileName);
        try
        {
            // create dir
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // cerialize c# - Json
            string dataToStore = JsonUtility.ToJson(data, true);

            // write file
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error while saving to file: " + fullPath + "\n" + e);
        }
    }

}
