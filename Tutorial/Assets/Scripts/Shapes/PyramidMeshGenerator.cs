/*
 * (c) 2021 Copyright, Real-Time Innovations, Inc. (RTI) All rights reserved.
 *
 * RTI grants Licensee a license to use, modify, compile, and create derivative
 * works of the software solely for use with RTI Connext DDS.  Licensee may
 * redistribute copies of the software provided that all such copies are
 * subject to this license. The software is provided "as is", with no warranty
 * of any type, including any warranty for fitness for any purpose. RTI is
 * under no obligation to maintain or support the software.  RTI shall not be
 * liable for any incidental or consequential damages arising out of the use or
 * inability to use the software.
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidMeshGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();

        Vector3 p0 = new Vector3(0, 0, 0);
        Vector3 p1 = new Vector3(1, 0, 0);
        Vector3 p2 = new Vector3(0.5f, 0, Mathf.Sqrt(0.75f));
        Vector3 p3 = new Vector3(0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3);

        mesh.Clear();

        mesh.vertices = new Vector3[]{
            p0,p1,p2,
            p0,p2,p3,
            p2,p1,p3,
            p0,p3,p1};

        mesh.triangles = new int[]{
            0,1,2,
            3,4,5,
            6,7,8,
            9,10,11};

        Vector2 uv3a = new Vector2(0, 0);
        Vector2 uv1 = new Vector2(0.5f, 0);
        Vector2 uv0 = new Vector2(0.25f, Mathf.Sqrt(0.75f) / 2);
        Vector2 uv2 = new Vector2(0.75f, Mathf.Sqrt(0.75f) / 2);
        Vector2 uv3b = new Vector2(0.5f, Mathf.Sqrt(0.75f));
        Vector2 uv3c = new Vector2(1, 0);

        mesh.uv = new Vector2[]{
            uv0,uv1,uv2,
            uv0,uv2,uv3b,
            uv0,uv1,uv3a,
            uv1,uv2,uv3c};

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
}
