using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*[SerializeField] private Transform targetObject;

    [SerializeField] private Vector3 cameraOffSet;
    [SerializeField] private float smooth = 0.5f;
    [SerializeField] private bool lookAtTarget = false;

    private void Start()
    {
        cameraOffSet = transform.position - targetObject.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffSet;
        transform.position = Vector3.Slerp(transform.position, newPosition, smooth);

        if (lookAtTarget)
        {
            transform.LookAt(targetObject);
        }
    }*/

    [SerializeField] private int zoom = 20;
    [SerializeField] private int normal = 60;
    [SerializeField] private float smooth = 5;

    public bool isZoomed = false;
    private bool notZoomed = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            print("clicked");
            isZoomed = !isZoomed;
        }

        if (isZoomed)
        {
            GetComponent<Camera>().fieldOfView =
                Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
        }

        if (Input.GetMouseButtonUp(1))
        {
            print("messahe");
            isZoomed = !notZoomed;
        }
        if(notZoomed)
        {
            GetComponent<Camera>().fieldOfView =
                Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
    }
}
