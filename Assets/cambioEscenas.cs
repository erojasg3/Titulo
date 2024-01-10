using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio_Escenas : MonoBehaviour
{
    public string nombreEscena;
    public void LoadScene(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}