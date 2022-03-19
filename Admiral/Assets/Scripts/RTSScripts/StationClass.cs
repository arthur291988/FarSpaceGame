using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationClass : MonoBehaviour
{
    //[HideInInspector]
    //public EnergonMoving energonOnScene;
    [HideInInspector]
    public Transform stationTransform;
    [HideInInspector]
    public Vector3 stationPosition;
    [HideInInspector]
    public float energonCatchDistance; //TO ASSIGN WHILE depending on the lvl of station
    [HideInInspector]
    public float speedOfBullet; //TO ASSIGN WHILE PULLLING depending on the lvl of station
    [HideInInspector]
    public float colorToEnergy; //TO ASSIGN WHILE PULLLING depending on the lvl of station (this is constant to transfer the color intensity to energy amount)
    [HideInInspector]
    public bool shotIsMade; //is managed by energon on scene 
    //public int CPUNumber; //TO ASSIGN WHILE PULLLING depending on the lvl of station
    [HideInInspector]
    public GameObject ObjectPulled;
    [HideInInspector]
    public List<GameObject> ObjectPulledList;

    [HideInInspector]
    public int energyOfStation;
    [HideInInspector]
    public float energyInscreaseTime; 
    [HideInInspector]
    public float energyInscreaseTimer;
    [HideInInspector]
    public float HPInscreaseTimer;
    [HideInInspector]
    public float stationShotTimer;
    [HideInInspector]
    public float stationShotTime;
    [HideInInspector]
    public int ShipsLimit; 
    [HideInInspector]
    public int ShipsAssigned; 
    [HideInInspector]
    public int energyRequiredToShot; 
    [HideInInspector]
    public int stationCurrentLevel; 
    [HideInInspector]
    public int upgradeCounts; 
    [HideInInspector]
    public int energyToNextUpgradeOfStation; 
    [HideInInspector]
    public int stationGunLevel; 
    [HideInInspector]
    public int GunUpgradeCounts; 
    [HideInInspector]
    public int energyToNextUpgradeOfGun;
    [HideInInspector]
    public int energyToConnection;

    [HideInInspector]
    public int energyOfStationToUPGradeGun;
    [HideInInspector]
    public int energyOfStationToUPGradeStation;
    [HideInInspector]
    public int energyOfStationToSetConnection;

    [HideInInspector]
    public int Cruis4;
    [HideInInspector]
    public int Cruis3;
    [HideInInspector]
    public int Cruis2;
    [HideInInspector]
    public int Cruis1; 
    [HideInInspector]
    public int Destr4;
    [HideInInspector]
    public int Destr3;
    [HideInInspector]
    public int Destr2;
    [HideInInspector]
    public int Destr2Par;
    [HideInInspector]
    public int Destr1;
    [HideInInspector]
    public int Destr1Par;

    [HideInInspector]
    public const float radiusOfShipsRingAroundStation = 6;
    //[HideInInspector]
    //public List<Vector3> squardPositions;
    [HideInInspector]
    public const float fleetGatherRadius = 14f;
    [HideInInspector]
    public float fillingSpeed; //TO ASSIGN WHILE PULLLING

    [HideInInspector]
    public int CPUNumber; //CPUNumber of player is always 0

    public Transform fillingLine;
    [HideInInspector]
    public float lifeLineAmount;

    [HideInInspector]
    public GameObject stationBullet;

    [HideInInspector]
    public float shotTimerTransformIndex;

    [HideInInspector]
    public EnergonMoving closestEnegon;

    [HideInInspector]
    public float attackDistance;
    [HideInInspector]
    public bool attackMode;
    [HideInInspector]
    public float attackTimeMax; //TO ASSIGN WHILE PULLLING
    [HideInInspector]
    public float attackTimeMin; //TO ASSIGN WHILE PULLLING
    [HideInInspector]
    public float harm; //TO ASSIGN WHILE PULLLING
    [HideInInspector]
    public LineRenderer attackLaserLine;
    [HideInInspector]
    public float attackTimerTime;
    [HideInInspector]
    public float shieldTimerTime;

    //Used by CPU statuin only
    [HideInInspector]
    public List<CPUBattleShip> shipsToGiveOrderCommandOfStation;

    public GameObject gunSphereVisible; //to disactivate or activate hole gun complex
    public GameObject gunSphereParent; //to rotate the gun
    [HideInInspector]
    public Transform gunSphereParentTransform;
    //public GameObject gun;

    [HideInInspector]
    public ParticleSystem energyGainEffect;
    [HideInInspector]
    public ParticleSystem.MainModule energyGainEffectMain;

    [HideInInspector]
    public SpriteRenderer territoryLine;

    //[HideInInspector]
    //public Dictionary<Vector3, StationClass> connectionsToStations;
    //[HideInInspector]
    //public byte connectionsCount;
    public List<StationClass> groupsWhereTheStationIs;
    public List<StationClass> ConnectedStations;

    [HideInInspector]
    public Color colorOfStationMat;

    public StationClass stationToConnect;

    public const float oneStepCloseStationsMaxDistance = 140f;
    private void Awake()
    {
        groupsWhereTheStationIs = new List<StationClass>();
        //ConnectedStations = new List<StationClass>();
           shotIsMade = false;
        stationTransform = transform;
        stationPosition = stationTransform.position;
        //connectionsToStations = new Dictionary<Vector3, StationClass>();
        territoryLine = stationTransform.GetChild(1).GetComponent<SpriteRenderer>();
        energyGainEffect = GetComponent<ParticleSystem>();
        energyGainEffectMain = energyGainEffect.main;
        //squardPositions = new List<Vector3>();
        //if (stationCurrentLevel>0) gunSphereParentTransform = gunSphereParent.transform;
        //fleetGatherRadius = 9f;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //radiusOfShipsRingAroundStation = 6;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //stationCurrentLevel = 0;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //upgradeCounts = 0;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //energyToNextUpgradeOfStation = 0;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //stationGunLevel = 0;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //energyToNextUpgradeOfGun = 0;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //GunUpgradeCounts = 0;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //Cruis4 = 0;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //Destr4 = 0;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //energyOfStation = 11;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //ShipsAssigned = 0;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //energyRequiredToShot = 10;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //energyInscreaseTime = 5f;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //energyInscreaseTimer = energyInscreaseTime;
        //energonCatchDistance = 30f; //TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //speedOfBullet = 10f;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //colorToEnergy = 25f;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //ShipsLimit = 16; //TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
        //fillingSpeed = 1;//TO DELETE CAUSE IS ASSIGNED WHILE INSTANTIATING
    }


    public virtual void  utilaizeTheEnergy(bool isRecursionCall)
    {
    }
    public virtual void utilaizeTheEnergyOfCPUGroup(int useOfEnergy)
    {
    }
    public virtual void checkIfStationCanConnect() { 
    
    }

    public float distanceToEnergon()
    {
        return (closestEnegon.energonTransform.position - stationPosition).magnitude;
    }


    public void disactivateThisStation(StationClass newStation)
    {
        //CPU station
        if (CPUNumber == 0)
        {
            for (int i = 0; i < CommonProperties.playerBattleShips.Count; i++)
                if (CommonProperties.playerBattleShips[i].maternalStation == this) CommonProperties.playerBattleShips[i].maternalStation = newStation;
            if (CommonProperties.stationPanelScript.station == this) CommonProperties.stationPanelScript.closeThePanel(true);
        }
        //player station with CPUNumber 0
        else
        {
            for (int i = 0; i < CommonProperties.CPUBattleShipsDictionary[CPUNumber - 1].Count; i++)
                if (CommonProperties.CPUBattleShipsDictionary[CPUNumber - 1][i].maternalStation == this) CommonProperties.CPUBattleShipsDictionary[CPUNumber - 1][i].maternalStation = newStation;
        }
        //sending the signal of cutting the connection with old station to other stations
        foreach (StationClass stations in ConnectedStations) stations.ConnectedStations.Remove(this);
        if (newStation != null) foreach (StationClass stations in ConnectedStations) stations.ConnectedStations.Add(newStation); // and adding new station to stations that were connected with previous station

        if (newStation == null)
        {
            ObjectPulledList = ObjectPullerRTS.current.GetStationBurstPull();
            ObjectPulled = ObjectPullerRTS.current.GetGameObjectFromPull(ObjectPulledList);
            ObjectPulled.transform.position = stationPosition;
            ObjectPulled.SetActive(true);

            ObjectPulledList = ObjectPullerRTS.current.GetStarPull(upgradeCounts);
            ObjectPulled = ObjectPullerRTS.current.GetGameObjectFromPull(ObjectPulledList);
            CommonProperties.stars.Add(ObjectPulled.GetComponent<StarController>());
            ObjectPulled.transform.position = stationPosition;
            ObjectPulled.SetActive(true);
            for (int i = 0; i < CommonProperties.CPUStations.Count; i++) CommonProperties.CPUStations[i].giveAnOrderToFleet();
            //reducing the energy of group of stations in case if this station is destroyed
            if (groupsWhereTheStationIs != null && groupsWhereTheStationIs.Count > 0)
            {
                CommonProperties.energyOfStationGroups[groupsWhereTheStationIs] -= CommonProperties.energyOfStationGroups[groupsWhereTheStationIs] / groupsWhereTheStationIs.Count;
                //updating the panel info if it is opened by player
                if (CPUNumber == 0 && CommonProperties.stationPanelIsActive) CommonProperties.stationPanelScript.updateVariablesAfterEnergyChanges(); 
                for (int i = 0; i < CommonProperties.connectionLines[CPUNumber].Count; i++)
                {
                    if (CommonProperties.connectionLines[CPUNumber][i].stations.Contains(this))
                    {
                        CommonProperties.connectionLines[CPUNumber][i].disactivateThisLine(CPUNumber, this);
                    }
                }
            }
            
        }
        else {
            if (groupsWhereTheStationIs != null && groupsWhereTheStationIs.Count > 0)
            {
                for (int i = 0; i < CommonProperties.connectionLines[CPUNumber].Count; i++)
                {
                    if (CommonProperties.connectionLines[CPUNumber][i].stations.Contains(this))
                    {
                        CommonProperties.connectionLines[CPUNumber][i].reassignStationAfterUpgrade(this, newStation);
                    }
                }
            }
        }
        if (gunSphereVisible != null) gunSphereVisible.SetActive(false);
        if (groupsWhereTheStationIs != null && groupsWhereTheStationIs.Count > 0)
        {
            groupsWhereTheStationIs.Remove(this);
            //deleting the group of stations if there left no any stations in group
            if (groupsWhereTheStationIs.Count < 1)
            {
                CommonProperties.StationGroups[CPUNumber].Remove(groupsWhereTheStationIs);
                CommonProperties.energyOfStationGroups.Remove(groupsWhereTheStationIs);
            }
            groupsWhereTheStationIs = null;
        }
        ConnectedStations.Clear();
        gameObject.SetActive(false);
        lifeLineAmount = 0;

        if (newStation == null) GameController.current.checkIfPlayerWinOrLost(); //win/lost conditions checked only if station is destroyed
    }

    public void increaseTheHPOfStation(float energyAmount)
    {
        lifeLineAmount += (energyAmount / 500)* (2-fillingSpeed);
        if (lifeLineAmount > 0)
        {
            lifeLineAmount = 0;
        }
        fillingLine.localPosition = new Vector3(lifeLineAmount, 0, 0);
    }
    public void resetTheClosestEnergon()
    {
        if (CommonProperties.energonsOnScene.Count > 1)
        {
            for (int i = 0; i < CommonProperties.energonsOnScene.Count; i++)
            {
                if (i == 0) closestEnegon = CommonProperties.energonsOnScene[i];
                else
                {
                    if (distanceToEnergon() > (CommonProperties.energonsOnScene[i].energonTransform.position - stationPosition).magnitude) closestEnegon = CommonProperties.energonsOnScene[i];
                }
            }
        }
        else if (CommonProperties.energonsOnScene.Count == 1) closestEnegon = CommonProperties.energonsOnScene[0];
    }


    public virtual int stationDefenceFleetPower()
    {
        return 0;
    }

    public virtual int stationDefenceFleetLeftByUnits()
    {
        return 0;
    }

    //used only by CPU Station
    public virtual void callForAHelp() { 
    
    }

    ////Used by CPU statuin only
    //public virtual void gatherTheReferencesToShipsOfStation() { 
    //}

    //Used by CPU statuin only
    public virtual void sendTheFleetToThePoint(Vector3 startPoint, Vector3 destinationPoint) { 
    }

    public void reduceTheHPOfStation(float fillAmount)
    {
        lifeLineAmount -= fillAmount * fillingSpeed;
        if (lifeLineAmount <= -6)
        {
            lifeLineAmount = -6;
            disactivateThisStation(null);
        }
        fillingLine.localPosition = new Vector3(lifeLineAmount, 0, 0);
    }
}
