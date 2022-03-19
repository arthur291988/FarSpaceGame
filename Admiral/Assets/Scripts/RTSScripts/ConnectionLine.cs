using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionLine : MonoBehaviour
{
    public GameObject enenrgyTransporter;
    public List<StationClass> stations;
    private Transform enenrgyTransporterTransform;
    private int indexOfStation;
    [HideInInspector]
    public bool lineIsSet;

    // Start is called before the first frame update
    void Start()
    {
        lineIsSet = false;
        indexOfStation = 0;
        enenrgyTransporterTransform = enenrgyTransporter.transform;
        stations = new List<StationClass>();
    }

    public void disactivateThisLine(int CPUNumber, StationClass station)
    {
        CommonProperties.connectionLines[CPUNumber].Remove(this);
        stations.Remove(station);
        //if station to which was connected destroyed station has no other connections than it loses it's group belonging
        if (stations[0].ConnectedStations.Count < 1)
        {
            stations[0].groupsWhereTheStationIs.Remove(stations[0]);
            stations[0].groupsWhereTheStationIs = null;
        }
        stations.Clear();
        lineIsSet = false;
        enenrgyTransporter.SetActive(false);
        gameObject.SetActive(false);
    }

    public void reassignStationAfterUpgrade(StationClass stationOld, StationClass stationNew) {
        lineIsSet = false;
        stations.Remove(stationOld);
        stations.Add(stationNew);
        lineIsSet = true;
    }

    private void turnBackAndPassTheEnergy()
    {
        /*if (stations[indexOfStation].groupsWhereTheStationIs.Count > 0) */CommonProperties.energyOfStationGroups[stations[indexOfStation].groupsWhereTheStationIs] += stations[indexOfStation].energyRequiredToShot; //adding the energy to group of station
        /*else stations[indexOfStation].energyOfStation += stations[indexOfStation].energyRequiredToShot;//adding the energy to station only*/
        if (stations[indexOfStation].CPUNumber > 0) ConnectionCPUStations.distributeGroupEnergy(stations[indexOfStation].groupsWhereTheStationIs);
        stations[indexOfStation].energyGainEffectMain.startSize = 10;
        stations[indexOfStation].energyGainEffect.Play();
        if (stations[indexOfStation].CPUNumber == 0) stations[indexOfStation].utilaizeTheEnergy(false);
        indexOfStation = indexOfStation == 0 ? 1 : 0;
    }
    private void FixedUpdate()
    {
        if (lineIsSet)
        enenrgyTransporterTransform.Translate((stations[indexOfStation].stationPosition - enenrgyTransporterTransform.position).normalized * Time.fixedDeltaTime * 2f, Space.World);
    }
    // Update is called once per frame
    void Update()
    {
        if (lineIsSet)
        {
            if ((stations[indexOfStation].stationPosition - enenrgyTransporterTransform.position).magnitude < 5) turnBackAndPassTheEnergy();
            //if (!stations[indexOfStation].isActiveAndEnabled) gameObject.SetActive(false); //if station is destroyed
        }
    }
}
