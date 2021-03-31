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
 
using Rti.Dds.Subscription;
using Rti.Types.Dynamic;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ShapeComms : DDSHandler
{
    private DynamicData d_CubeData;
    private DynamicData d_SphereData;
    private DynamicData d_PyramidData;

    public ShapeComms() : base()
    {
        try
        {
            d_CubeData = DataWriterCube.CreateData();
            d_SphereData = DataWriterSphere.CreateData();
            d_PyramidData = DataWriterPyramid.CreateData();
        }
        catch (Exception exc)
        {
            Debug.Log(exc);
        }
    }

    public void WriteCube(Shape3D shape, String color)
    {
        SetShapeData(ref d_CubeData, shape, color);

        DataWriterCube.Write(d_CubeData);
    }

    public void WriteSphere(Shape3D shape, String color)
    {
        SetShapeData(ref d_SphereData, shape, color);

        DataWriterSphere.Write(d_SphereData);
    }

    public void WritePyramid(Shape3D shape, String color)
    {
        SetShapeData(ref d_PyramidData, shape, color);

        DataWriterPyramid.Write(d_PyramidData);
    }

    private void SetShapeData(ref DynamicData data, Shape3D shape, String color)
    {
        data.ClearAllMembers();

        data.SetValue("color", color);
        data.SetValue("x", shape.x);
        data.SetValue("y", shape.y);
        data.SetValue("z", shape.z);
        data.SetValue("shapesize", shape.shapesize);
    }

    public List<Shape3D> GetCubes()
    {
        return ParseShapes(DataReaderCube.Take());
    }

    public List<Shape3D> GetSpheres()
    {
        return ParseShapes(DataReaderSphere.Take());
    }

    public List<Shape3D> GetPyramids()
    {
        return ParseShapes(DataReaderPyramid.Take());
    }

    private List<Shape3D> ParseShapes(LoanedSamples<DynamicData> shapes)
    {
        List<Shape3D> returnList = new List<Shape3D>();

        foreach (var shape in shapes)
        {
            returnList.Add(new Shape3D()
            {
                color = ConvertStringToColor((string)shape.Data.GetAnyValue("color")),
                x = (Int32)shape.Data.GetAnyValue("x"),
                y = -(Int32)shape.Data.GetAnyValue("y"),
                z = (Int32)shape.Data.GetAnyValue("z"),
                shapesize = (Int32)shape.Data.GetAnyValue("shapesize")
            });
        }

        return returnList;
    }


    private Color ConvertStringToColor(string color)
    {
        switch (color)
        {
            case "PURPLE": return new Color(0.5f, 0.0f, 0.5f);
            case "BLUE": return Color.blue;
            case "RED": return Color.red;
            case "GREEN": return Color.green;
            case "YELLOW": return Color.yellow;
            case "CYAN": return Color.cyan;
            case "MAGENTA": return Color.magenta;
            case "ORANGE": return new Color(1.0f, 0.647f, 0.0f);
            default: return Color.clear;
        }
    }
}
