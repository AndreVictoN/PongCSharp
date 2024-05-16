using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneHelper : MonoBehaviour
{
    public string sceneToOpen;

    public string backToMenu;

    public void OpenScene()
    {
        SceneManager.LoadScene(sceneToOpen);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SaveController.instance.two = false;
            
            SceneManager.LoadScene(backToMenu);
        }
    }
}
