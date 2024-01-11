using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarUltimoModalTsunami : MonoBehaviour
{
    public void ActivarModal()
    {
        StartCoroutine("Tiempo_modal")
    }

    public IEnumerator Tiempo_modal(Tiempo_modal)
    {
        yield return new waitForSeconds (10f);
        Mensaje.SetActive(true);
    }
}
