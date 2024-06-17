using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float zoomStep, minCamsize, maxCamsize;
    //[SerializeField]
    //private SpriteRenderer mapRenderer;

    private float CamMinX, CamMaxX, CamMinY, CamMaxY;


    private Vector3 dragOrigin;

    void Update()
    {
        PanCamera();
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(2))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);



        if (Input.GetMouseButton(2))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += difference;
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            ZoomIn();
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ZoomOut();
        }


        //cam.transform.position = ClampCamera(cam.transform.position + difference);

    }
    public void ZoomIn()
    {
        float newSize = cam.orthographicSize + zoomStep;

        cam.orthographicSize = Mathf.Clamp(newSize, minCamsize, maxCamsize);
        //cam.transform.position = ClampCamera(cam.transform.position);

    }
    public void ZoomOut()
    {
        float newSize = cam.orthographicSize - zoomStep;

        cam.orthographicSize = Mathf.Clamp(newSize, minCamsize, maxCamsize);

        //cam.transform.position = ClampCamera(cam.transform.position);
    }



    
}

/*
 private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camheight = cam.orthographicSize;
        float camwidth = cam.orthographicSize * cam.aspect;

        float minX = CamMinX + camwidth;
        float maxX = CamMaxX + camwidth;

        float minY = CamMinY - camwidth;
        float maxY = CamMaxY - camwidth;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
 
 private void Awake()
    {
        CamMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        CamMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;
        CamMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        CamMinX = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
    }
 
 */