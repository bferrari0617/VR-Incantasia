using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapTexture : MonoBehaviour
{
    MeshFilter cubeMesh;
    Mesh mesh;
    void Start()
    {
        cubeMesh = GetComponent<MeshFilter>();
        mesh = cubeMesh.mesh;
        Vector2[]uvMap = mesh.uv;

        //front
        uvMap[0] = new Vector2(0,0);
        uvMap[1] = new Vector2(0.333f, 0);
        uvMap[2] = new Vector2(0, 0.333f);
        uvMap[3] = new Vector2(0.333f, 0.333f);

        //top
        uvMap[4] = new Vector2(0.334f, 0.333f);
        uvMap[5] = new Vector2(0.666f, 0.333f);
        uvMap[8] = new Vector2(0.334f, 0);
        uvMap[9] = new Vector2(0.666f, 0);


    }

}
