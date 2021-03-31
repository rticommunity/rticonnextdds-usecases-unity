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
 
using Rti.Dds.Core;
using Rti.Dds.Domain;
using Rti.Dds.Publication;
using Rti.Dds.Subscription;
using Rti.Types.Dynamic;
using System;
using UnityEngine;

public class DDSHandler
{
    private readonly QosProvider provider;
    private readonly DomainParticipant participant;
    private readonly Publisher publisher;
    private readonly Subscriber subscriber;

    protected DataReader<DynamicData> DataReaderSphere { get; private set; }
    protected DataReader<DynamicData> DataReaderCube { get; private set; }
    protected DataReader<DynamicData> DataReaderPyramid { get; private set; }
    protected DataWriter<DynamicData> DataWriterSphere { get; private set; }
    protected DataWriter<DynamicData> DataWriterCube { get; private set; }
    protected DataWriter<DynamicData> DataWriterPyramid { get; private set; }



    protected DDSHandler()
    {
        try
        {
            provider = new QosProvider("Shapes.xml");

            participant = provider.CreateParticipantFromConfig("ShapeParticipantLibrary::ShapeParticipant");

            publisher = participant.LookupPublisher("publisher");
            subscriber = participant.LookupSubscriber("subscriber");

            DataReaderSphere = (DataReader<DynamicData>)subscriber.LookupDataReaderByName("SphereReader");
            DataReaderCube = (DataReader<DynamicData>)subscriber.LookupDataReaderByName("CubeReader");
            DataReaderPyramid = (DataReader<DynamicData>)subscriber.LookupDataReaderByName("PyramidReader");

            DataWriterSphere = (DataWriter<DynamicData>)publisher.LookupDataWriterByName("SphereWriter");
            DataWriterCube = (DataWriter<DynamicData>)publisher.LookupDataWriterByName("CubeWriter");
            DataWriterPyramid = (DataWriter<DynamicData>)publisher.LookupDataWriterByName("PyramidWriter");
        }
        catch (Exception exc)
        {
            Debug.Log(exc);
        }
    }
}
