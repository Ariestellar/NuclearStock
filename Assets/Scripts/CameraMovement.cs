using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform _targetEarth;
    private Vector3 _offset;
    private float _sensitivity = 3;
    private float _zoomSpeed = 10;
    private float _offsetX, _offsetY;

    private void Start()
    {
        _offset.z = -400;
    }

    private void Update()
    {
        ZoomCamera();
        RotateCamera();
        transform.position = transform.localRotation * _offset + _targetEarth.position;        
    }

    private void ZoomCamera()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            _offset.z += _zoomSpeed;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            _offset.z -= _zoomSpeed;

        _offset.z = Mathf.Clamp(_offset.z, -400, -200);        
    }

    private void RotateCamera()
    {
        if (Input.GetMouseButton(0))
        {
            _offsetX += Input.GetAxis("Mouse X") * _sensitivity;
            _offsetY += Input.GetAxis("Mouse Y") * _sensitivity;
            transform.localEulerAngles = new Vector3(-_offsetY, _offsetX, 0); 
        }
    }
}