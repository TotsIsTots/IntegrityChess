using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerspectiveButtonColorToggle : MonoBehaviour
{
    public Button whitePerspectiveButton;
    public Button blackPerspectiveButton;
    public Button thisButton;

    public void ToggleColor()
    {
        if(!GameObject.Find("Main Camera").GetComponent<CameraController>().rotating && thisButton == whitePerspectiveButton)
        {
            thisButton.transform.position = new Vector3(96, 1176, 0);
            blackPerspectiveButton.transform.position = new Vector3(96, 984, 0);
        }

        if (!GameObject.Find("Main Camera").GetComponent<CameraController>().rotating && thisButton == blackPerspectiveButton)
        {
            thisButton.transform.position = new Vector3(96, 1176, 0);
            whitePerspectiveButton.transform.position = new Vector3(96, 984, 0);
        }
    }
}