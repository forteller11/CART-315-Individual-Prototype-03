using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    public Camera LeftEye;

    public Camera RightEye;
    
    public float SideDisplayWidth = 0.2f;
    public float CenterDisplayWidth = 0.5f;

    public float VelForSide = 0.5f;
    public float VelForCenter = 0f;
    
    private float _amountCentered = 0.5f; //0 == side, 1 == centered
    private Rigidbody _rigidbody;

    
    void Awake()
    { 
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        GetAmountToCenter();
        PositionCameras();
    }
    
    void PositionCameras()
    {
        float displaySize = Mathf.Lerp(SideDisplayWidth, CenterDisplayWidth, _amountCentered);
        
        float leftPosition = _amountCentered;
        float rightPosition = displaySize - _amountCentered;
        
        LeftEye.rect = new Rect(leftPosition,0f, displaySize, 1f);
        RightEye.rect = new Rect(rightPosition,0f, displaySize, 1f);
    }

    private void GetAmountToCenter()
    {
        _amountCentered = Mathf.Lerp(1f,0f,(_rigidbody.velocity.magnitude - VelForCenter)/VelForSide);
    }
}
