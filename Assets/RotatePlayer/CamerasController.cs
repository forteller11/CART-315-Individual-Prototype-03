using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    public Camera LeftEye;
    public Camera RightEye;
    
    [Header("Eye Widths")]
    [Range(0,1)]
    public float SideDisplayWidth = 0.2f;
    [Range(0,1)]
    public float CenterDisplayWidth = 0.5f;

    [Header("Rotation Offset")]
    [Range(0,180f)]
    public float SideRotationOffset = 60f;
    [Range(0,180f)]
    public float CenterRotationOffset = 0f;
    
    [Header("POV")] 
    [Range(0,180f)]
    public float SideFov = 110f;
    [Range(0,180f)]
    public float CenterFov = 50f;
    
    [Header("Transition")]
    [Range(0,1)]
    public float AmountToLerpToCenter = 0.1f;
    [Range(0,1)]
    public float AmountToLerpToSides = 0.01f;
    
    //lerp
    [Header("Velocitys")]
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
        //_amountCentered = 0f;
        float displaySize = Mathf.Lerp(SideDisplayWidth, CenterDisplayWidth, _amountCentered);

        float centerLeftPosition = 0.5f;
        float centerRightPosition = centerLeftPosition;
        float sideLeftPosition = 0f;
        float sideRightPosition = 1f - displaySize;


        float leftPosition = Mathf.Lerp(sideLeftPosition, centerLeftPosition, _amountCentered);
        float rightPosition = Mathf.Lerp(sideRightPosition, centerRightPosition, _amountCentered);
            
        LeftEye.rect = new Rect(leftPosition,0f, displaySize, 1f);
        RightEye.rect = new Rect(rightPosition,0f, displaySize, 1f);

        float rotationOffset = Mathf.Lerp(SideRotationOffset, CenterRotationOffset, _amountCentered);
        LeftEye.transform.localRotation = Quaternion.Euler(0f, -rotationOffset, 0f);
        RightEye.transform.localRotation = Quaternion.Euler(0f, rotationOffset, 0f);
        
        //POV
        float fov = Mathf.Lerp(SideFov, CenterFov, _amountCentered);
        LeftEye.fieldOfView = fov;
        RightEye.fieldOfView = fov;
    }

    private void GetAmountToCenter()
    {
        float targetAmountToCenter = Mathf.Lerp(1f,0f,(_rigidbody.velocity.magnitude - VelForCenter)/VelForSide);
        if (targetAmountToCenter > _amountCentered) //if going towards center
            _amountCentered = Mathf.Lerp(_amountCentered, targetAmountToCenter, AmountToLerpToCenter);
        else
            _amountCentered = Mathf.Lerp(_amountCentered, targetAmountToCenter, AmountToLerpToSides);
            
        

    }
}
