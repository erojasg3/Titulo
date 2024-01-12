using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup.alpha = 1;
    }

    private void Update()
    {
        if (_canvasGroup.alpha >0)
        {
            _canvasGroup.alpha -=Time.deltaTime;
        }
    }
    public void Fade()
    {
        _canvasGroup.alpha = 1;
        if (_canvasGroup.alpha > 0)
        {
            _canvasGroup.alpha -= Time.deltaTime;
        }

    }
}
