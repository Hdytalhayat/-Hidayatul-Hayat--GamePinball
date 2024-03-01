using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBasic : MonoBehaviour
{
    public Camera mainCam;
    public Camera scndCam;
    int toggle = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if(toggle == 0)
            {
                mainCam.gameObject.SetActive(true);
                scndCam.gameObject.SetActive(false);
                toggle = 1;
            }
            else if (toggle == 1)
            {
                mainCam.gameObject.SetActive(false);
                scndCam.gameObject.SetActive(true);
                toggle = 0;

            }
        }
    }
}
