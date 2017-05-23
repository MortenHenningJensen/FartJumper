using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    private MeshRenderer myMesh;

    void Start()
    {
        myMesh = GetComponent<MeshRenderer>();
        myMesh.enabled = false;
    }

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 1, 0));
    }

    
}
