using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class FpsController : MonoBehaviour
{
    private PlayerControls _input;
    public Vector2 AngularSensitivty = new Vector2(20, 20);
    public Vector2 _rotationEulerCache;
    public Vector2 LinearSensitivty = new Vector2(20,20);
    private Rigidbody _rigidbody;
    
     void Awake()
     {
         _rigidbody = GetComponent<Rigidbody>();
         _input = new PlayerControls();
     }

     protected void OnEnable() => _input.Enable();
    protected void OnDisable() =>_input.Disable();
    
    void Update()
    {
        Vector2 inputAngular = Time.deltaTime * AngularSensitivty * _input.PlayerMovement.Rotate.ReadValue<Vector2>();
        Vector2 inputLinear =  Time.deltaTime * LinearSensitivty * _input.PlayerMovement.Translate.ReadValue<Vector2>();
        
        _rotationEulerCache += inputAngular;
        //transform.rotation = Quaternion.identity;
//        transform.Rotate(transform.up,_rotationEulerCache.x,Space.World);
//        transform.Rotate(transform.right,-_rotationEulerCache.y,Space.World);
        
        _rigidbody.AddTorque(new Vector3(0f, inputAngular.x,0f));

        Vector3 rot = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(rot.x, rot.y, 0f);

        _rigidbody.AddForce(transform.forward * inputLinear.y);
        _rigidbody.AddForce(transform.right * inputLinear.x);

    }

    private void LateUpdate()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(rot.x, rot.y, 0f);
    }
}

