using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public List<TextMeshPro> texts;
    
    public int FramesToAppear = 1;
    public int FramesToFade = 30;
    private float _toIncreaseEachFrame { get => 1f / FramesToAppear; }
    private float _toDecreaseEachFrame { get => 1f / FramesToFade; }
    public float CurrentAlpha = 0;
    
    private Coroutine _currentCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        StopCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine( "Appear");
    }
    
    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine( "Fade");
    }

    IEnumerator Fade() 
    {
        for (float a = CurrentAlpha; a > 0; a -= _toDecreaseEachFrame)
        {
            foreach (var text in texts)
                text.alpha = a;
            
            yield return null;
        }
    }
    
    IEnumerator Appear() 
    {
        for (float a = CurrentAlpha; a < 1; a += _toIncreaseEachFrame)
        {
            foreach (var text in texts)
                text.alpha = a;
            
            yield return null;
        }
    }
}


