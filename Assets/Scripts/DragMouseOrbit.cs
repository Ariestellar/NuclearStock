using UnityEngine;
using UnityEngine;
using System.Collections;

public class DragMouseOrbit : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float distance = 500.0f;
    [SerializeField] private float xSpeed = 0.001f;
    [SerializeField] private float ySpeed = 0.001f;
    [SerializeField] private float yMinLimit = -360f;
    [SerializeField] private float yMaxLimit = 360f;
    [SerializeField] private float distanceMin = 250f;
    [SerializeField] private float distanceMax = 500f;
    [SerializeField] private float smoothTime = 2f;
    [SerializeField] private float rotationYAxis = 0.0f;
    [SerializeField] private float rotationXAxis = 0.0f;
    [SerializeField] private float velocityX = 0.0f;
    [SerializeField] private float velocityY = 0.0f;    
    private void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;
    }
    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f;
            velocityY += ySpeed * Input.GetAxis("Mouse Y") * distance * 0.02f;
        }
        rotationYAxis += velocityX;
        rotationXAxis -= velocityY;
        Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
        Quaternion rotation = toRotation;

        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 30, distanceMin, distanceMax);
        RaycastHit hit;
        if (Physics.Linecast(target.position, transform.position, out hit))
        {
            distance -= hit.distance;
        }
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + target.position;

        transform.rotation = rotation;
        transform.position = position;
        velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
        velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
    }   
}