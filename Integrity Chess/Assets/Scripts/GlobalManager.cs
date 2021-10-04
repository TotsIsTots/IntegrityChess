using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour
{
    public Vector3 setHere;
    public GameObject movingPiece;
    public GameObject startingPiece;
    public GameObject musicSlider;
    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Find("Main Camera").GetComponent<CameraController>().perspectiveButtonClicked = true;
        }

        GetComponent<AudioSource>().volume = musicSlider.GetComponent<Slider>().value;
    }
}
