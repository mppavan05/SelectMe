using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageChanger : MonoBehaviour
{
    [SerializeField] private Material[] displayMaterials;

    private Renderer _renderer;
    private int _num;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.enabled = true;
    }

    private void Update()
    {
        ChangeImage();
    }

    public void GetNumber(int index)
    {
        _num = index;
    }

    private void ChangeImage()
    {
        _renderer.sharedMaterial = displayMaterials[_num];
    }
}
