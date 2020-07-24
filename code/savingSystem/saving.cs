using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class saving
{
    public static void savePosOfCam(testSaving player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //string path = Application.persistentDataPath + "/player.save";
        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        posSave data = new posSave(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static posSave loadPosOfCam()
    {
        string path = Application.persistentDataPath + "/player.save";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            posSave data = formatter.Deserialize(stream) as posSave;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save File Not Found in " + path);
            return null;
        }
    }
    //real in game save the others was just an test
    public static savingBuildPos loadPosOfBuilding()
    {
        string path = Application.persistentDataPath + "/buildingPos.save";
        Debug.Log(Application.persistentDataPath + "/buildingPos.save");

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            savingBuildPos data = formatter.Deserialize(stream) as savingBuildPos;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save File Not Found in " + path);
            return null;
        }
    }
    public static void savePosOfBuilding (testSaving Cam)
    {
        //greates the encrypter
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/buildingPos.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        //send the dater further in the system
        savingBuildPos data = new savingBuildPos(Cam);
        //encrypt the data
        formatter.Serialize(stream, data);
        stream.Close();
    }

}