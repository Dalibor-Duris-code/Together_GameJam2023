using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class SaveLoadPosition {
    
    // Save a GameObject's position to a file
    public static void SavePosition(GameObject obj
        , GameObject obj2, string filename) {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + filename);
        
        Vector3 positionP1 = obj.transform.position;
        Vector3 positionP2 = obj2.transform.position;
        
        float[] serPos = new float[6];
        serPos[0] = positionP1.x;
        serPos[1] = positionP1.y;
        serPos[2] = positionP1.z;
        serPos[3] = positionP2.x;
        serPos[4] = positionP2.y;
        serPos[5] = positionP2.z;

        string activeScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LevelSaved", activeScene);
        PlayerPrefs.SetFloat("Obj1PosX", serPos[0]);
        PlayerPrefs.SetFloat("Obj1PosY", serPos[1]);
        PlayerPrefs.SetFloat("Obj1PosZ", serPos[2]);
        PlayerPrefs.SetFloat("Obj2PosX", serPos[3]);
        PlayerPrefs.SetFloat("Obj2PosY", serPos[4]);
        PlayerPrefs.SetFloat("Obj2PosZ", serPos[5]);
        
        bf.Serialize(file, serPos);
        file.Close();

        Debug.Log("Game Saved");
    }

    // Load a GameObject's position from a file
    public static void LoadPosition(GameObject obj, GameObject obj2, string filename) {
        if (File.Exists(Application.persistentDataPath + "/" + filename)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + filename, FileMode.Open);
        
            float[] deserializedPos = (float[])bf.Deserialize(file);
            Vector3 position1 = new Vector3(deserializedPos[0], deserializedPos[1], deserializedPos[2]);
            Vector3 position2 = new Vector3(deserializedPos[3], deserializedPos[4], deserializedPos[5]);
            
            obj.transform.position = position1;
            obj2.transform.position = position2;

            file.Close();
            Debug.Log("Game Loaded");
        }
    }
}