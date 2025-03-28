// using System.IO;
// using System.Runtime.Serialization.Formatters.Binary;
// using UnityEngine;
//
// public static class SaveSystem
// {
//     private static string _path; 
//
//     static SaveSystem()
//     {
//         _path = Application.persistentDataPath + "/savefile.dat"; 
//     }
//
//     public static void SaveLevel(int level)
//     {
//         var formatter = new BinaryFormatter();
//         var stream = new FileStream(_path, FileMode.Create);
//
//         var data = new SaveData(level);
//         formatter.Serialize(stream, data);
//         stream.Close();
//     }
//
//     public static int LoadLevel()
//     {
//         if (File.Exists(_path))
//         {
//             var formatter = new BinaryFormatter();
//             var stream = new FileStream(_path, FileMode.Open);
//             var data = formatter.Deserialize(stream) as SaveData;
//             stream.Close();
//             return data.level;
//         }
//
//         return 0;
//     }
// }
//
//     [System.Serializable]
//     public class SaveData
//     {
//         public int level;
//
//         public SaveData(int i)
//         {
//             level = i;
//         }
//     }
