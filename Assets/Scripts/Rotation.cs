using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed;
    static bool zoomedIn;
    bool zoomIn;
    public Transform sun;
    public GameObject mainCamera;
    public GameObject planetUI;
    public Transform viewPos;
    Vector3 cameraPos;
    Quaternion cameraRot;
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = mainCamera.transform.position;
        cameraRot = mainCamera.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(sun.position, Vector3.up, speed * Time.deltaTime);

        if(zoomIn)
        {
            planetUI.SetActive(true);
            mainCamera.transform.position = Vector3.Lerp(viewPos.position, mainCamera.transform.position, 0.1f * Time.deltaTime);
            mainCamera.transform.LookAt(transform.position);
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                zoomIn = false;
                zoomedIn = false;
                planetUI.SetActive(false);
                mainCamera.transform.position = Vector3.Lerp(cameraPos, mainCamera.transform.position, 0.1f);
                mainCamera.transform.rotation = cameraRot;
            }
        }
    }

    void OnMouseOver() 
    {
        if(!zoomedIn)
        {
            if(Input.GetMouseButton(0))
            {
                zoomIn = true;
                zoomedIn = true;
            }
        }
    }
}
