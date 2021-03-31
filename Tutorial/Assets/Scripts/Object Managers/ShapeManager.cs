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

public class ShapeManager : MonoBehaviour
{
    public GameObject m_ShapePrefab;

    protected ShapeComms m_DDS;
    private Dictionary<Color, GameObject> m_Shapes;

    protected virtual void Awake()
    {
        m_Shapes = new Dictionary<Color, GameObject>();
        enabled = false;
    }

    public void Setup(ShapeComms comms)
    {
        m_DDS = comms;

        enabled = true;
    }

    private void AddInstance(Shape3D shape)
    {
        m_Shapes.Add(shape.color, Instantiate(m_ShapePrefab, new Vector3(shape.x, shape.y, shape.z), new Quaternion()));
        m_Shapes[shape.color].GetComponent<MeshRenderer>().material.color = shape.color;
        m_Shapes[shape.color].transform.localScale = new Vector3(shape.shapesize, shape.shapesize, shape.shapesize);
    }

    private void MoveShape(Shape3D shape)
    {
        m_Shapes[shape.color].GetComponent<Rigidbody>().MovePosition(new Vector3(shape.x, shape.y, shape.z));
    }

    protected void UpdateShape(List<Shape3D> shapes)
    {
        foreach (var shape in shapes)
        {
            if (m_Shapes.ContainsKey(shape.color))
                MoveShape(shape);
            else
                AddInstance(shape);
        }
    }
}
