using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public List<TextMeshProUGUI> texts;
    
    public int FramesToAppear = 1;
    public int FramesToFade = 30;
    [Range(0, 1f)]
    public float CurrentAlpha = 0;
    public bool ShowTextWhenCenterIsGreaterThan = true;
    [Range(0, 1)]
    public float CenterThreshold = 0.5f;

    private float _deltaTimeCorrection = 0.02f;
    
    private float _toIncreaseEachFrame { get => 1f / FramesToAppear; }
    private float _toDecreaseEachFrame { get => 1f / FramesToFade; }
    
    
    private Coroutine _currentCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine( "Fade");
    }

    private void Start()
    {
        foreach (var text in texts)
            text.alpha = CurrentAlpha;
    }

    private void OnTriggerStay(Collider other)
    {
        var camController = other.GetComponent<CamerasController>();
        if (camController == null)
            return;
        
        if (ShowTextWhenCenterIsGreaterThan)
        {
            if (camController.AmountCentered >= CenterThreshold)
                ContinueAppearence();
            else
                ContinueFade();
        }
        else
        {
            if (camController.AmountCentered < CenterThreshold)
                ContinueAppearence();
            else
                ContinueFade();
        }
        
    }

    void ContinueAppearence()
    {
        CurrentAlpha += _toIncreaseEachFrame * Time.deltaTime/_deltaTimeCorrection;
        CurrentAlpha = Mathf.Clamp01(CurrentAlpha);
        foreach (var text in texts)
            text.alpha = CurrentAlpha;
    }
    
    void ContinueFade()
    {
        CurrentAlpha -= _toDecreaseEachFrame * Time.deltaTime/_deltaTimeCorrection;
        CurrentAlpha = Mathf.Clamp01(CurrentAlpha);
        foreach (var text in texts)
            text.alpha = CurrentAlpha;
    }

    IEnumerator Fade() 
    {
        for (; CurrentAlpha > 0; CurrentAlpha -= _toDecreaseEachFrame * Time.deltaTime/_deltaTimeCorrection)
        {
            foreach (var text in texts)
                text.alpha = CurrentAlpha;
            
            yield return null;
        }
    }
}


