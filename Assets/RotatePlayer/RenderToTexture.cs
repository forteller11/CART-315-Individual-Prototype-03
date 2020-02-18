using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderToTexture : MonoBehaviour
{
    private Camera _camera;
    public RenderTexture RenderTexture;
    void Awake()
    {
        _camera = GetComponent<Camera>();
        _camera.targetTexture = RenderTexture;
    }
    
}
