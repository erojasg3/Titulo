using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UbicacionEspecifica : MonoBehaviour
{
    public UnityEvent OnTeleportEnter;
    public UnityEvent OnTeleport;
    public UnityEvent OnTeleportExit;
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void OnPointerEnterXR()
    {
        OnTeleportEnter?.Invoke();
    }
    public void OnPointerClickXR()
    {
        ExecuteTeleportation2();
        OnTeleport?.Invoke();
        TeleportManager.Instance.DisableTeleportPoint(gameObject);
    }
    public void OnPostRender()
    {
        OnTeleportExit?.Invoke();
    }

    private void ExecuteTeleportation2()
    {
        GameObject player = TeleportManager.Instance.Player;
        player.transform.position = new Vector3(4.3, 50.8, -3.4);
    }
}

