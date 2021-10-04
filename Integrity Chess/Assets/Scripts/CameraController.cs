using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public GameObject target;
    public bool perspectiveButtonClicked;
    public bool rotating;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (perspectiveButtonClicked)
        {
            perspectiveButtonClicked = false;
            rotating = true;
        
        }
    }

    void FixedUpdate()
    {
        if (rotating)
        {
            Rotate();
            if (gameObject.transform.position == new Vector3(3.5f, 7, -3) || gameObject.transform.position == new Vector3(3.5f, 7, 10))
            {
                rotating = false;
            }
        }
    }
    void Rotate()
    {
        rotating = true;
        transform.LookAt(target.transform.position);
        transform.RotateAround(target.transform.position, Vector3.up, 180 * Time.deltaTime);
    }

    public void PerspectiveButtonClicked()
    {
        perspectiveButtonClicked = true;
    }
}
