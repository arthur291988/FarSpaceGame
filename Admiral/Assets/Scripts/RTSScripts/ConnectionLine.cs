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
    [HideInInspector]
    public float transporterSpeed;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    //Debug.Log("Hey this one is called from start of line");
    //}

    private void OnEnable()
    {
        if (stations == null)
        {
            stations = new List<StationClass>();
        }
        enenrgyTransporterTransform = enenrgyTransporter.transform;
        lineIsSet = false;
        indexOfStation = 0;
    }

    public void disactivateThisLine(int CPUNumber/*, StationClass station*/)
    {
        CommonProperties.connectionLines[CPUNumber].Remove(this);
        //stations.Remove(station);
        ////if station to which was connected destroyed station has no other connections than it loses it's group belonging
        //if (stations[0].ConnectedStations.Count < 1)
        //{
        //    stations[0].groupWhereTheStationIs.Remove(stations[0]);
        //    //removing the station group if it does not contain any member any more
        //    if (stations[0].groupWhereTheStationIs.Count < 1)
        //    {
        //        CommonProperties.StationGroups[stations[0].CPUNumber].Remove(stations[0].groupWhereTheStationIs);
        //        CommonProperties.energyOfStationGroups.Remove(stations[0].groupWhereTheStationIs);
        //    }
        //    stations[0].groupWhereTheStationIs = null;
        //}
        stations.Clear();
        lineIsSet = false;
        enenrgyTransporter.SetActive(false);
        gameObject.SetActive(false);
    }

    public void setTheSpeedOfTransporter() {
        if (stations[0].stationCurrentLevel > stations[1].stationCurrentLevel) transporterSpeed = stations[0].stationCurrentLevel + 2;
        else if (stations[0].stationCurrentLevel < stations[1].stationCurrentLevel) transporterSpeed = stations[1].stationCurrentLevel + 2;
        else {
            transporterSpeed = stations[1].stationCurrentLevel == 0 ? 2 : stations[1].stationCurrentLevel == 1 ? 3 : stations[1].stationCurrentLevel == 2 ? 4 : 5;
        }
    }

    public void reassignStationAfterUpgrade(StationClass stationOld, StationClass stationNew) {
        lineIsSet = false;
        stations.Remove(stationOld);
        stations.Add(stationNew);
        lineIsSet = true;
        setTheSpeedOfTransporter();
    }
    
    private void turnBackAndPassTheEnergy()
    {
        /*if (stations[indexOfStation].groupWhereTheStationIs.Count > 0) */

        //some advantage for CPU stations
        if (stations[0].CPUNumber==0) CommonProperties.energyOfStationGroups[stations[indexOfStation].groupWhereTheStationIs] += stations[indexOfStation].energyRequiredToShot*4; //adding the energy to group of station
        else CommonProperties.energyOfStationGroups[stations[indexOfStation].groupWhereTheStationIs] += stations[indexOfStation].energyRequiredToShot * 6; //adding the energy to group of station

        /*else stations[indexOfStation].energyOfStation += stations[indexOfStation].energyRequiredToShot;//adding the energy to station only*/
        if (stations[indexOfStation].CPUNumber > 0) ConnectionCPUStations.distributeGroupEnergy(stations[indexOfStation].groupWhereTheStationIs);
        stations[indexOfStation].energyGainEffectMain.startSize = 10;
        stations[indexOfStation].energyGainEffect.Play();
        if (stations[indexOfStation].CPUNumber == 0) stations[indexOfStation].utilaizeTheEnergy(false);
        indexOfStation = indexOfStation == 0 ? 1 : 0; //switching the station to move towards another one

    }
    private void FixedUpdate()
    {
        if (lineIsSet)
        enenrgyTransporterTransform.Translate((stations[indexOfStation].stationPosition - enenrgyTransporterTransform.position).normalized * Time.fixedDeltaTime * transporterSpeed, Space.World);
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
