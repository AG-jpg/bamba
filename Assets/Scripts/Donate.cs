using UnityEngine;

public class Donate : MonoBehaviour
{
    public string URL;

    public void Open(){
        Application.OpenURL(URL);
    }
}
