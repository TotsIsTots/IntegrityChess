using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesManager : MonoBehaviour
{
    public Material opaque;
    public Material transparent;
    public bool isTraveling;
    bool canPlay = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTraveling)
        {
            GetComponent<Transform>().position = GameObject.Find("GlobalManager").GetComponent<GlobalManager>().setHere;
        }
    }

    void FixedUpdate()
    {
        if(transform.position != new Vector3(transform.position.x, 0, transform.position.z)) {
            transform.position -= new Vector3(0, .2f, 0);
            return;
        }
        if (canPlay)
        {
            if(GetComponent<ParticleSystem>() != null)
            {
                GetComponent<ParticleSystem>().Play();
            }

        }
        canPlay = false;
    }
}
