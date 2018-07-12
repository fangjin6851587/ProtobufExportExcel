using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using ProtoBuf;
using UnityEngine;

public class ExcelDataManager {
    public static T ReadOneDataConfig<T>(string fileName)
    {
        string filePath = GetDataConfigPath(fileName);
        if (!File.Exists(filePath))
        {
            return default(T);
        }

        using (var fs = new FileStream(filePath, FileMode.Open))
        {
            T t = Serializer.Deserialize<T>(fs);
            return t;
        }
    }

    private static string GetDataConfigPath(string fileName)
    {
        return Application.dataPath + "/DataConfig/data/" + fileName + ".data";
    }
}
