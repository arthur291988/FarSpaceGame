﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionCPUStations : MonoBehaviour
{
    private const int BASE_STATION_DEFENCE_SHIPS_COUNT = 6;
    private const int MINIMUM_ENENRGY_TO_START_STATION_UPGRADE_LOOP = 250;
    private const int MINIMUM_ENENRGY_TO_START_GUN_UPGRADE_LOOP = 200;
    private const int MINIMUM_ENENRGY_TO_START_SHIP_PRODUCE_LOOP = 100;

    [HideInInspector]
    public static GameObject ObjectPulled;
    [HideInInspector]
    public static List<GameObject> ObjectPulledList;
    private static LineRenderer lineToDragFromStation;
    private static StationClass stationConnectionStartFrom;
    private static StationClass stationToConnect;
    //// Start is called before the first frame update
    //void Start()
    //{
    //}
    public static void instantiateConnectionLine()
    {
        ObjectPulledList = ObjectPullerRTS.current.GetConnectionLinePull();
        ObjectPulled = ObjectPullerRTS.current.GetGameObjectFromPull(ObjectPulledList);
        lineToDragFromStation = ObjectPulled.GetComponent<LineRenderer>();
        lineToDragFromStation.SetPosition(0, stationConnectionStartFrom.stationPosition);
        ObjectPulled.SetActive(true);
    }

    public static void setConnections(StationClass stationConnectionStartFromParam, StationClass stationToConnectParam) {

        ObjectPulled = null;

        stationConnectionStartFrom = stationConnectionStartFromParam;
        stationToConnect = stationToConnectParam;
        instantiateConnectionLine();
        lineToDragFromStation.SetPosition(1, stationToConnect.stationPosition);
        lineToDragFromStation.endColor = new Color(stationConnectionStartFrom.colorOfStationMat.r, stationToConnect.colorOfStationMat.g, stationToConnect.colorOfStationMat.b, 0.3f);
        lineToDragFromStation.startColor = new Color(stationConnectionStartFrom.colorOfStationMat.r, stationToConnect.colorOfStationMat.g, stationToConnect.colorOfStationMat.b, 0.3f);
        GameObject energyTransporter = lineToDragFromStation.gameObject.transform.GetChild(0).gameObject;
        ConnectionLine lineScript = lineToDragFromStation.gameObject.GetComponent<ConnectionLine>();
        lineScript.stations.Add(stationToConnect);
        lineScript.stations.Add(stationConnectionStartFrom);
        //if there is no connection line collection yet in dictionary we create it first
        if (!CommonProperties.connectionLines.ContainsKey(stationConnectionStartFrom.CPUNumber)) CommonProperties.connectionLines.Add(stationConnectionStartFrom.CPUNumber, new List<ConnectionLine>());
        CommonProperties.connectionLines[stationConnectionStartFrom.CPUNumber].Add(lineScript);
        energyTransporter.transform.position = stationConnectionStartFrom.stationPosition;
        energyTransporter.transform.rotation = Quaternion.LookRotation(stationToConnect.stationPosition - stationConnectionStartFrom.stationPosition, Vector3.up);
        energyTransporter.GetComponent<MeshRenderer>().material.SetColor("_Color", stationConnectionStartFrom.colorOfStationMat);
        energyTransporter.SetActive(true);
        lineScript.lineIsSet = true;
        setStationGroupForCPU();
        if (stationConnectionStartFrom.groupsWhereTheStationIs != null && stationConnectionStartFrom.groupsWhereTheStationIs.Count > 0)
        {
            CommonProperties.energyOfStationGroups[stationConnectionStartFrom.groupsWhereTheStationIs] -= stationConnectionStartFrom.energyToConnection;
        }
        else stationConnectionStartFrom.energyOfStation -= stationConnectionStartFrom.energyToConnection;
        //foreach (StationPlayerRTS stationPlayer in CommonProperties.playerStations) stationPlayer.checkIfStationCanConnect();
    }
    private static void setStationGroupForCPU()
    {
        //creating new connection group
        if (stationConnectionStartFrom.ConnectedStations.Count < 1 && stationToConnect.ConnectedStations.Count < 1)
        {
            List<List<StationClass>> newGroup = new List<List<StationClass>>();
            List<StationClass> newConnection = new List<StationClass>();
            CommonProperties.StationGroups.Add(stationToConnect.CPUNumber, newGroup);
            newGroup.Add(newConnection);
            newConnection.Add(stationConnectionStartFrom);
            stationConnectionStartFrom.ConnectedStations.Add(stationToConnect);
            //stationConnectionStartFrom.connectionsCount++;
            stationConnectionStartFrom.groupsWhereTheStationIs = newConnection;
            newConnection.Add(stationToConnect);
            stationToConnect.ConnectedStations.Add(stationConnectionStartFrom);
            stationToConnect.groupsWhereTheStationIs = newConnection;
            CommonProperties.energyOfStationGroups.Add(newConnection, 0);
            CommonProperties.energyOfStationGroups[newConnection] = stationToConnect.energyOfStation + stationToConnect.energyOfStationToUPGradeStation + stationToConnect.energyOfStationToUPGradeGun + stationToConnect.energyOfStationToSetConnection +
                stationConnectionStartFrom.energyOfStation + stationConnectionStartFrom.energyOfStationToUPGradeStation + stationConnectionStartFrom.energyOfStationToUPGradeGun + stationConnectionStartFrom.energyOfStationToSetConnection;
        }
        //connecting one station to the connection group
        else if (stationConnectionStartFrom.ConnectedStations.Count < 1)
        {
            stationConnectionStartFrom.groupsWhereTheStationIs = stationToConnect.groupsWhereTheStationIs;
            stationToConnect.groupsWhereTheStationIs.Add(stationConnectionStartFrom);
            stationToConnect.ConnectedStations.Add(stationConnectionStartFrom);
            stationConnectionStartFrom.ConnectedStations.Add(stationToConnect);
            CommonProperties.energyOfStationGroups[stationToConnect.groupsWhereTheStationIs] += stationConnectionStartFrom.energyOfStation;
            CommonProperties.energyOfStationGroups[stationToConnect.groupsWhereTheStationIs] += stationConnectionStartFrom.energyOfStationToUPGradeStation;
            CommonProperties.energyOfStationGroups[stationToConnect.groupsWhereTheStationIs] += stationConnectionStartFrom.energyOfStationToUPGradeGun;
            CommonProperties.energyOfStationGroups[stationToConnect.groupsWhereTheStationIs] += stationConnectionStartFrom.energyOfStationToSetConnection;
        }
        //connecting one station to the connection group
        else if (stationToConnect.ConnectedStations.Count < 1)
        {
            stationToConnect.groupsWhereTheStationIs = stationConnectionStartFrom.groupsWhereTheStationIs;
            stationConnectionStartFrom.groupsWhereTheStationIs.Add(stationToConnect);
            stationToConnect.ConnectedStations.Add(stationConnectionStartFrom);
            stationConnectionStartFrom.ConnectedStations.Add(stationToConnect);
            CommonProperties.energyOfStationGroups[stationConnectionStartFrom.groupsWhereTheStationIs] += stationToConnect.energyOfStation;
            CommonProperties.energyOfStationGroups[stationToConnect.groupsWhereTheStationIs] += stationToConnect.energyOfStationToUPGradeStation;
            CommonProperties.energyOfStationGroups[stationToConnect.groupsWhereTheStationIs] += stationToConnect.energyOfStationToUPGradeGun;
            CommonProperties.energyOfStationGroups[stationToConnect.groupsWhereTheStationIs] += stationToConnect.energyOfStationToSetConnection;
            //stationConnectionStartFrom.connectionsCount++;
            //stationToConnect.connectionsCount++;
        }
        //connecting one connection group to other connection group
        else if (stationConnectionStartFrom.ConnectedStations.Count > 0 && stationToConnect.ConnectedStations.Count > 0)
        {

            if (stationConnectionStartFrom.groupsWhereTheStationIs != stationToConnect.groupsWhereTheStationIs)
            {
                List<StationClass> tempClass = stationToConnect.groupsWhereTheStationIs;
                foreach (StationClass station in tempClass)
                {
                    stationConnectionStartFrom.groupsWhereTheStationIs.Add(station);
                    station.groupsWhereTheStationIs = stationConnectionStartFrom.groupsWhereTheStationIs;
                    CommonProperties.energyOfStationGroups[stationConnectionStartFrom.groupsWhereTheStationIs] += station.energyOfStation;
                    CommonProperties.energyOfStationGroups[stationToConnect.groupsWhereTheStationIs] += station.energyOfStationToUPGradeStation;
                    CommonProperties.energyOfStationGroups[stationToConnect.groupsWhereTheStationIs] += station.energyOfStationToUPGradeGun;
                    CommonProperties.energyOfStationGroups[stationToConnect.groupsWhereTheStationIs] += station.energyOfStationToSetConnection;
                }
                stationToConnect.ConnectedStations.Add(stationConnectionStartFrom);
                stationConnectionStartFrom.ConnectedStations.Add(stationToConnect);
                //stationConnectionStartFrom.connectionsCount++;
                //stationToConnect.connectionsCount++;
                CommonProperties.StationGroups[stationToConnect.CPUNumber].Remove(tempClass);
                CommonProperties.energyOfStationGroups.Remove(tempClass);
                tempClass = null;
            }
            else
            {
                stationToConnect.ConnectedStations.Add(stationConnectionStartFrom);
                stationConnectionStartFrom.ConnectedStations.Add(stationToConnect);
                //stationConnectionStartFrom.connectionsCount++;
                //stationToConnect.connectionsCount++;
            }
        }
    }

    public static void distributeGroupEnergy(List<StationClass> groupsWhereTheStationIs)
    {
        //first is tho provide all stations with defence minimum ships
        for (int i = 0; i < groupsWhereTheStationIs.Count; i++)
        {
            if (groupsWhereTheStationIs[i].ShipsAssigned < BASE_STATION_DEFENCE_SHIPS_COUNT) groupsWhereTheStationIs[i].utilaizeTheEnergyOfCPUGroup(1);
        }

        //second is to capture as more as possible stars
        if (CommonProperties.stars.Count > 0)
        {
            for (int i = 0; i < groupsWhereTheStationIs.Count; i++)
            {
                if (groupsWhereTheStationIs[i].ShipsAssigned < groupsWhereTheStationIs[i].ShipsLimit) groupsWhereTheStationIs[i].utilaizeTheEnergyOfCPUGroup(2);
            }
        }

        //third is connections, upgrades, and guns
        else {
            //if there will be any possiable connections and even if there is no enough energy yet, the goup accumulate the energy
            int possibleConnections = 0;
            for (int i = 0; i < groupsWhereTheStationIs.Count; i++)
            {
                groupsWhereTheStationIs[i].checkIfStationCanConnect();
                if (groupsWhereTheStationIs[i].stationToConnect != null)
                {
                    if (groupsWhereTheStationIs[i].energyToConnection <= CommonProperties.energyOfStationGroups[groupsWhereTheStationIs])
                    {
                        CommonProperties.energyOfStationGroups[groupsWhereTheStationIs] -= groupsWhereTheStationIs[i].energyToConnection;
                        setConnections(groupsWhereTheStationIs[i], groupsWhereTheStationIs[i].stationToConnect);
                    }
                    else possibleConnections++;
                }
            }

            if (possibleConnections == 0)
            {
                if (Random.Range(0, 5) > 0)
                {
                    if (CommonProperties.energyOfStationGroups[groupsWhereTheStationIs] >= MINIMUM_ENENRGY_TO_START_STATION_UPGRADE_LOOP)
                    {
                        for (int i = 0; i < groupsWhereTheStationIs.Count; i++)
                        {
                            if (groupsWhereTheStationIs[i].energyToNextUpgradeOfStation <= CommonProperties.energyOfStationGroups[groupsWhereTheStationIs] && groupsWhereTheStationIs[i].stationCurrentLevel < groupsWhereTheStationIs[i].upgradeCounts)
                            {
                                groupsWhereTheStationIs[i].utilaizeTheEnergyOfCPUGroup(3);
                            }
                        }
                    }
                    if (CommonProperties.energyOfStationGroups[groupsWhereTheStationIs] >= MINIMUM_ENENRGY_TO_START_GUN_UPGRADE_LOOP)
                    {
                        for (int i = 0; i < groupsWhereTheStationIs.Count; i++)
                        {
                            if (groupsWhereTheStationIs[i].energyToNextUpgradeOfGun <= CommonProperties.energyOfStationGroups[groupsWhereTheStationIs] && groupsWhereTheStationIs[i].stationGunLevel < groupsWhereTheStationIs[i].GunUpgradeCounts)
                            {
                                groupsWhereTheStationIs[i].utilaizeTheEnergyOfCPUGroup(4);
                            }
                        }
                    }
                }
                else 
                {
                    if (CommonProperties.energyOfStationGroups[groupsWhereTheStationIs] >= MINIMUM_ENENRGY_TO_START_SHIP_PRODUCE_LOOP)
                    {
                        for (int i = 0; i < groupsWhereTheStationIs.Count; i++)
                        {
                            if (groupsWhereTheStationIs[i].ShipsAssigned < groupsWhereTheStationIs[i].ShipsLimit) groupsWhereTheStationIs[i].utilaizeTheEnergyOfCPUGroup(2);
                        }
                    }
                }
            }
            
        }

    }

}
