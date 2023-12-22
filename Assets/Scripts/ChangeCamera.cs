using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera Camera1;
    public Camera Camera2;
    // Start is called before the first frame update
    void Start()
    {
        Camera1.enabled = true;
        Camera2.enabled = false;
    }

    // Update is called once per frame
    public void ChangeCam()
    {
        Camera1.enabled=false;
        Camera2.enabled=true; 
    }

}
