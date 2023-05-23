using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Frame : MonoBehaviour
{
    private BoxCollider2D frame;
    private Vector2 L2Size;
    private Vector2 L2Center;

    /// Awake is called when the script instance is being loaded.
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        frame = GetComponent<BoxCollider2D>();

        //Level Two Collider
        L2Size = new Vector2(79.72737f, 11.241531f);
        L2Center = new Vector2(22.23454f, 1.041531f);
    }

    /// Update is called every frame, if the MonoBehaviour is enabled.
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(scene.name == "Level2")
        {
            frame.size = L2Size;
            frame.offset = L2Center;
        }
    }

}
