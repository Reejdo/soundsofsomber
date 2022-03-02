using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private bool isZoomed;
    [SerializeField] private float zoom;
    [SerializeField] private float normal = 11.68882f;
    [SerializeField] private float smooth = 5;
    [SerializeField] private DialogueManager dManager;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("DialogueManager") != null)
        {
            dManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        }
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (dManager != null)
        {
            if (dManager.talking)
            {
                isZoomed = true;
            }
            else
            {
                isZoomed = false;
            }
        }

        if (isZoomed)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * smooth);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, normal, Time.deltaTime * smooth);
        }
    }
}
