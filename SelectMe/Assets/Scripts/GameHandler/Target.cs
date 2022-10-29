using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
  [SerializeField] private Camera mainCamera;
  [SerializeField] private GameObject slider;
  [SerializeField] private Button closeButton;


 
  private int zoom = 20;
  private int normal = 60;
  private float smooth = 2;
  



  private Transform targetObject;
  public bool isZoomed = false;

  private void Start()
  {
    closeButton.onClick.AddListener(CloseButtonFunction);
  }

  private void Update()
  {
    ObjectSelection();
  }


  private void ObjectSelection()
  {
    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit))
    {
      var selection = hit.transform;
      targetObject = selection;
      var selectionRender = selection.GetComponent<ImageChanger>();
      if (selectionRender != null)
      {
        //Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 0.5f);
        StartCoroutine(ZoomIn());
        selectionRender.transform.GetChild(0).gameObject.SetActive(true);
        mainCamera.transform.LookAt(targetObject);
        slider.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
        
      }
      else
      {
        //Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red, 0.5f);
      }
    }
  }

  public void GetNumber(int index)
  {
    if (targetObject.CompareTag("Middle"))
    {
      print("Middle");
      StoredValue.MiddleTv = index;
    }
    else if (targetObject.CompareTag("Left"))
    {
      print("Left");
      StoredValue.LeftTv = index;
    }
    else if (targetObject.CompareTag("Right"))
    {
      print("Right");
      StoredValue.RightTV = index;
    }
    
  }
  

  private void CloseButtonFunction()
  {
    StartCoroutine(ZoomOut());
  }


  private IEnumerator ZoomIn()
  {
    mainCamera.fieldOfView =
      Mathf.Lerp(mainCamera.fieldOfView, zoom, Time.deltaTime * smooth);
    yield return new WaitForSeconds(3f);
  }

  private IEnumerator ZoomOut()
  {
    mainCamera.fieldOfView =
        Mathf.Lerp(mainCamera.fieldOfView, normal, Time.deltaTime * 100);
    yield return new WaitForSeconds(1f);
    slider.gameObject.SetActive(false);
    closeButton.gameObject.SetActive(false);
    
  }
}
