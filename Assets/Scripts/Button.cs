using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    public void PressButton(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
