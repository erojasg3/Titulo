using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{

    public void change(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void salir (){
        Application.Quit();
    }
    
}
