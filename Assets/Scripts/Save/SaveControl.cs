using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveControl : MonoBehaviour
{

    void Start()
    {
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByBuildIndex(0)))
        {
            LoadGame();
        }
    }

    private Save CreateSavedGameObject()
    {
        Save info = new Save();

        //Inventario Data
        info.notes = Data.notes;
        // Stats Data
        info.level = Data.level;
        info.vida = Data.vida;
        info.velocidad = Data.velocidad;
        info.salto = Data.salto;

        return info;
    }

    public void SaveGame()
    {
        Save info = CreateSavedGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, info);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save info = (Save)bf.Deserialize(file);
            file.Close();

            //Inventario Data
            Data.notes = info.notes;
            // Stats Data
            Data.level = info.level;
            Data.vida = info.vida;
            Data.velocidad = info.velocidad;
            Data.salto = info.salto;

            Application.OpenURL(Application.persistentDataPath);
        }
        else
        {
            //Valores iniciales
            Data.notes = 0;
            Data.vida = 3;
            Data.velocidad = 5;
            Data.salto = 10;

            SaveGame();
        }
    }
}
