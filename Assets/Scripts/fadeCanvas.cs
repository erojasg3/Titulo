using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fadeCanvas : MonoBehaviour
{
    [SerializeField] CanvasGroup group;

    void Start()
    {
        if(group.alpha == 0)
            group.alpha = 1;
    }

    void Update()
    {
        if (group.alpha >= 0 )
        {
            group.alpha -= Time.deltaTime;
        }
    }
}
