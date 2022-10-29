using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageChanger : MonoBehaviour
{
    [SerializeField] private Material[] displayMaterials;

    private Renderer _renderer;
    
    

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.enabled = true;
    }

    private void Update()
    {
        ChangeImage();
    }
    

    private void ChangeImage()
    {
        if (CompareTag("Middle"))
        {
            _renderer.sharedMaterial = displayMaterials[StoredValue.MiddleTv];
        }
        else if (CompareTag("Left"))
        {
            _renderer.sharedMaterial = displayMaterials[StoredValue.LeftTv];
        }
        else if (CompareTag("Right"))
        {
            _renderer.sharedMaterial = displayMaterials[StoredValue.RightTV];
        }
        
    }
}
