using UnityEngine;
using System.Collections;

public class LoadSceneOnClick : MonoBehaviour 
{
    public string SceneName = "MainScene";
	void OnMouseDown()
    {
        Application.LoadLevel(SceneName);
    }
}
