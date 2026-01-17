using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    //public static void SavePlayer(Player_Health playerH, Player_Movement playerS)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string path = Application.persistentDataPath + "/player.fun";
    //    FileStream stream = new FileStream(path, FileMode.Create);

    //    PlayerData data = new PlayerData(playerH, playerS);

    //    formatter.Serialize(stream, data);
    //}
    //public static  PlayerData LoadPlayer()
    //{
    //    string path = Application.persistentDataPath + "/player.fun";
    //    if (File.Exists(path))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream stream = new FileStream(path, FileMode.Open);

    //        PlayerData data = formatter.Deserialize(stream) as PlayerData;
    //        stream.Close();

    //        return data;
    //    }
    //    else
    //    {
    //        Debug.LogError("Your save file is in another castle..." + path);
    //        return null;
    //    }
    //}

}
