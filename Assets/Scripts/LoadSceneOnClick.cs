using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour 
{
    public string SceneName = "MainScene";
	void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }
}
