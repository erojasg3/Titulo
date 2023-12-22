
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    public GameObject teleportTarget;
    public GameObject Player;

    void OnTriggerEnter(Collider other)
    {
        Player.transform.position = teleportTarget.transform.position;
    }
}
