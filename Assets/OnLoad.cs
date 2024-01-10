using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoad : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;
    public void ShowUI()
    {
        fadeIn = true;
    }
    public void HideUi()
    {
        fadeOut = true;
    }

    private void Update()
    {
        if (fadeIn)
        {
            if (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += Time.deltaTime;
                if (_canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }

        }

        if (fadeOut)
        {
            if (_canvasGroup.alpha >= 0)
            {
                _canvasGroup.alpha -= Time.deltaTime;
                if (_canvasGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }

}
