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

public class GameManager : MonoBehaviour
{
    public GameObject m_CubeManager;
    public GameObject m_PyramidManager;
    public GameObject m_SphereManager;

    private ShapeComms m_DDS;

    // Start is called before the first frame update
    void Start()
    {
        m_DDS = new ShapeComms();

        m_CubeManager.SetActive(true);
        m_CubeManager.GetComponent<CubeManager>().Setup(m_DDS);

        m_PyramidManager.SetActive(true);
        m_PyramidManager.GetComponent<PyramidManager>().Setup(m_DDS);

        m_SphereManager.SetActive(true);
        m_SphereManager.GetComponent<SphereManager>().Setup(m_DDS);
    }
}
