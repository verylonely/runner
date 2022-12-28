using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

namespace VLTools 
{
    public class SaveLoad : MonoBehaviour 
    {
        public static void Save<T>(T objectToSave, string key)
        {
            string path = Application.persistentDataPath + "/saves/";
            Directory.CreateDirectory(path);
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path + key + ".sav", FileMode.Create))
            {
                formatter.Serialize(stream, objectToSave);
            }
            Debug.Log("Saved to: " + path + key + ".sav");
        }
        public static T Load<T>(string key)
        {
            string path = Application.persistentDataPath + "/saves/";
            Directory.CreateDirectory(path);
            BinaryFormatter formatter = new BinaryFormatter();
            T returnValue = default(T);
            using (FileStream stream = new FileStream(path + key + ".sav", FileMode.Open))
            {
                returnValue = (T)formatter.Deserialize(stream);
            }
            return returnValue;
        }

        public static bool SaveExist(string key)
        {
            string path = Application.persistentDataPath + "/saves/" + key + ".sav";
            return File.Exists(path);
        }

        public static void SeriouslyDeleteAllSaveFiles()
        {
            string path = Application.persistentDataPath + "/saves";
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.Delete(true);
            Directory.CreateDirectory(path);
        }
    }
}
