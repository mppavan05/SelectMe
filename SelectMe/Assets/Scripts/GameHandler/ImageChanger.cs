using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageChanger : MonoBehaviour
{
    [SerializeField] private Material[] displayMaterials;

    private Renderer _renderer;

    public int number;
    

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
        _renderer.sharedMaterial = displayMaterials[number];
    }
}
