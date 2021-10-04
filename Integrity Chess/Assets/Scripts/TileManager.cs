using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Collider holdingPiece;
    GameObject globalManager;

    // Start is called before the first frame update
    void Start()
    {
        globalManager = GameObject.Find("GlobalManager");
        globalManager.GetComponent<GlobalManager>().startingPiece.GetComponent<PiecesManager>().isTraveling = true;
        globalManager.GetComponent<GlobalManager>().startingPiece.GetComponent<MeshRenderer>().material = globalManager.GetComponent<GlobalManager>().startingPiece.GetComponent<PiecesManager>().transparent;
        globalManager.GetComponent<GlobalManager>().startingPiece.GetComponent<SphereCollider>().enabled = false;
        globalManager.GetComponent<GlobalManager>().movingPiece = globalManager.GetComponent<GlobalManager>().startingPiece.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().enabled = true;
        globalManager.GetComponent<GlobalManager>().setHere = new Vector3(GetComponent<Transform>().position.x, 0, GetComponent<Transform>().position.z);
    }

    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnMouseDown()
    {
        /* 
         * play particles
         * set down moving piece
         * make moving piece opaque
         * pick up new piece
         * make new piece transparent
         * remove new piece collision
         * add moving piece collison
         * make new piece moving piece
         */
        if (globalManager.GetComponent<GlobalManager>().movingPiece.GetComponent<ParticleSystem>() != null)
        {
            globalManager.GetComponent<GlobalManager>().movingPiece.GetComponent<ParticleSystem>().Play();
        }
        if (globalManager.GetComponent<GlobalManager>().movingPiece != null)
        {
            if(globalManager.GetComponent<GlobalManager>().movingPiece.GetComponent<AudioSource>() != null)
            {
                globalManager.GetComponent<GlobalManager>().movingPiece.GetComponent<AudioSource>().Play(0);
            }
            globalManager.GetComponent<GlobalManager>().movingPiece.GetComponent<PiecesManager>().isTraveling = false;
            globalManager.GetComponent<GlobalManager>().movingPiece.GetComponent<MeshRenderer>().material = globalManager.GetComponent<GlobalManager>().movingPiece.GetComponent<PiecesManager>().opaque;
        }
        holdingPiece.GetComponent<PiecesManager>().isTraveling = true;
        holdingPiece.GetComponent<MeshRenderer>().material = holdingPiece.GetComponent<PiecesManager>().transparent;
        holdingPiece.GetComponent<SphereCollider>().enabled = false;
        if (globalManager.GetComponent<GlobalManager>().movingPiece != null)
        {
            globalManager.GetComponent<GlobalManager>().movingPiece.GetComponent<SphereCollider>().enabled = true;
        }
        globalManager.GetComponent<GlobalManager>().movingPiece = holdingPiece.gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        holdingPiece = other;
    }
}
