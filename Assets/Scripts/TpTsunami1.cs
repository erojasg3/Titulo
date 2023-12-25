using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpTsunami : MonoBehaviour
{
    public GameObject teleportTarget;
    public GameObject thePlayer;
    public 
    
    void OnTriggerEnter(Collider other)
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }



}


