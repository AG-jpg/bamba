using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveControl : MonoBehaviour
{
    
    private void Start()
    {
        if(SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByBuildIndex(0)))
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

    }

    public void LoadGame()
    {
        
    }
}
