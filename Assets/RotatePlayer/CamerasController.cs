﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CamerasController : MonoBehaviour
{
    public Camera LeftEye;
    public Camera RightEye;

    public RectTransform LeftMask;
    public RectTransform RightMask;

    public RectTransform LeftImage;
    public RectTransform RightImage;
    
    [Header("Eye Widths")]
    [Range(0,0.5f)]
    public float SideDisplayWidth = 0.1f;
    [Range(0,0.5f)]
    public float CenterDisplayWidth = 0.05f;

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
    [Range(0, 0.5f)] public float AmountToLerpToCenter = 0.1f;
    [Range(0, 0.1f)] public float AmountToLerpToSides = 0.01f;
    [Range(0, 0.1f)] public float MinAmountToChange = 0.0002f;
    
    
    //lerp
    [Header("Velocitys")]
    public float VelForSide = 0.5f;
    public float VelForCenter = 0f;
    
    
    private float _amountCentered = 1.0f; //0 == side, 1 == centered
    private Rigidbody _rigidbody;
    private float _width;
    private float _height;

    
    void Awake()
    { 
        _rigidbody = GetComponent<Rigidbody>();
        _width = Display.main.renderingWidth;
        _height = Display.main.renderingHeight;
    }
    
    void Update()
    {
        GetAmountToCenter();
        PositionCameras();
    }
    
    void PositionCameras()
    {
        
        float displaySize = Mathf.Lerp(SideDisplayWidth, CenterDisplayWidth, _amountCentered);
        float displaySizePixels = displaySize * _width;
        
        float centerLeftPosition = _width/2 - displaySizePixels;
        float centerRightPosition = _width/2 ;
        float sideLeftPosition = 0f;
        float sideRightPosition = _width - displaySizePixels;


        float leftPosition = Mathf.Lerp(sideLeftPosition, centerLeftPosition, _amountCentered);
        float rightPosition = Mathf.Lerp(sideRightPosition, centerRightPosition, _amountCentered);
        
        //in pixel coords
        LeftMask.transform.position = new Vector3(leftPosition,0f,0f);
        RightMask.transform.position = new Vector3(rightPosition,0f,0f);
        
        LeftImage.position = Vector3.zero;
        RightImage.position = Vector3.zero;
        
        //in normalized coords
        LeftMask.transform.localScale = new Vector3(displaySize,1,1f);
        RightMask.transform.localScale = new Vector3(displaySize,1,1f);
        
        LeftImage.transform.localScale = new Vector3(1/displaySize,1,1f);
        RightImage.transform.localScale = new Vector3(1/displaySize,1,1f);
        

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
        {
            float newCentered = Mathf.Lerp(_amountCentered, targetAmountToCenter, AmountToLerpToCenter);
            float deltaBetweenFrames = Mathf.Abs(newCentered - _amountCentered);
            if (deltaBetweenFrames < MinAmountToChange)
                _amountCentered += MinAmountToChange;
            else
                _amountCentered = newCentered;
        }

        else
        {
            float newCentered = Mathf.Lerp(_amountCentered, targetAmountToCenter, AmountToLerpToSides);
            float deltaBetweenFrames = Mathf.Abs(newCentered - _amountCentered);
            if (deltaBetweenFrames < MinAmountToChange)
                _amountCentered -= MinAmountToChange;
            else
                _amountCentered = newCentered;
        }
        
        _amountCentered = Mathf.Clamp(_amountCentered,0,1f);
        

    }
}
