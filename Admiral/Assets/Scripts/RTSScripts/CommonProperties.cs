using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonProperties : MonoBehaviour
{
    //public GameObject testSphere;

    public static List<StationClass> allStations;

    public static List<StarController> stars;

    public static List<PlayerBattleShip> playerBattleShips;
    public static List<PlayerGun> playerGuns;
    public static List<StationClass> playerStations;

    public static List<CPUBattleShip> CPUBattleShips;

    public static List<CPUBattleShip> CPU1Ships;
    public static List<CPUBattleShip> CPU2Ships;
    public static List<CPUBattleShip> CPU3Ships;
    public static List<CPUBattleShip> CPU4Ships;

    public static List<StationCPU> CPUStations;
    public static List<StationClass> CPU1Stations;
    public static List<StationClass> CPU2Stations;
    public static List<StationClass> CPU3Stations;
    public static List<StationClass> CPU4Stations;

    public static Dictionary<int, List<CPUBattleShip>> CPUBattleShipsDictionary;
    public static Dictionary<int, List<StationClass>> CPUStationsDictionary;

    public static List<CPUBattleShip> CPUMegaAttackBattleShips;
    public static bool CPUMegaAttackCoroutineIsOn;
    public static float CPUMegaAttackTimer;

    //public static EnergonMoving energonOnScene;
    public static List<EnergonMoving> energonsOnScene;

    public static Camera MainCameraOfRTS;
    public static Transform MainCameraOfRTSTransform;
    public static GameController gameController;

    //0-Red, 1-green, 2-blue, 3-yellow, 4-purple
    public static byte colorOfPlayer = 1;
    public static byte megaAttackTime = 40;
    public static byte enemyCount = 5;

    public static float cruiser4HP = 10;
    public static float destr4HP = 7;
    public static float cruiser3HP = 13;
    public static float destr3HP = 9;
    public static float cruiser2HP = 16;
    public static float destr2HP = 11;
    public static float cruiser1HP = 19;
    public static float destr1HP = 14;

    public static float Cruiser4Harm = 2;
    public static float Destr4Harm = 1;
    public static float Cruiser3Harm = 3;
    public static float Destr3Harm = 2;
    public static float Cruiser2Harm = 5;
    public static float Destr2Harm = 3;
    public static float Destr2ParHarm = 2.5f;
    public static float Cruiser1Harm = 7;
    public static float Destr1Harm = 5;
    public static float Destr1ParHarm = 4.5f;

    public static float Cruiser4StationHarm = 0.07f;
    public static float Destr4StationHarm = 0.05f;
    public static float Cruiser3StationHarm = 0.1f;
    public static float Destr3StationHarm = 0.07f;
    public static float Cruiser2StationHarm = 0.13f;
    public static float Destr2StationHarm = 0.09f;
    public static float Cruiser1StationHarm = 0.16f;
    public static float Destr1StationHarm = 0.11f;

    public static float cruiser4MaxAttackTime = 3.5f;
    public static float cruiser4MinAttackTime = 2.5f;
    public static float destr4MaxAttackTime = 4f;
    public static float destr4MinAttackTime = 3;
    public static float cruiser3MaxAttackTime = 3f;
    public static float cruiser3MinAttackTime = 2f;
    public static float destr3MaxAttackTime = 3.5f;
    public static float destr3MinAttackTime = 2.5f;
    public static float cruiser2MaxAttackTime = 2.5f;
    public static float cruiser2MinAttackTime = 1.5f;
    public static float destr2MaxAttackTime = 3f;
    public static float destr2MinAttackTime = 2f;
    public static float cruiser1MaxAttackTime = 2f;
    public static float cruiser1MinAttackTime = 1f;
    public static float destr1MaxAttackTime = 2.5f;
    public static float destr1MinAttackTime = 1.5f;

    public static float cruiser4MaxShieldPause = 6.5f;
    public static float cruiser4MinShieldPause = 5.5f;
    public static float destr4MinShieldPause = 7f;
    public static float destr4MaxShieldPause = 6;
    public static float cruiser3MaxShieldPause = 6f;
    public static float cruiser3MinShieldPause = 5f;
    public static float destr3MinShieldPause = 6.5f;
    public static float destr3MaxShieldPause = 5.5f;
    public static float cruiser2MaxShieldPause = 5f;
    public static float cruiser2MinShieldPause = 4f;
    public static float destr2MinShieldPause = 6f;
    public static float destr2MaxShieldPause = 5f;
    public static float cruiser1MaxShieldPause = 4f;
    public static float cruiser1MinShieldPause = 3f;
    public static float destr1MinShieldPause = 5f;
    public static float destr1MaxShieldPause = 4f;

    public static float cruiser4ShieldOnTime = 1.5f;
    public static float destr4ShieldOnTime = 1f;
    public static float cruiser3ShieldOnTime = 2f;
    public static float destr3ShieldOnTime = 1.5f;
    public static float cruiser2ShieldOnTime = 3f;
    public static float destr2ShieldOnTime = 2f;
    public static float cruiser1ShieldOnTime = 4f;
    public static float destr1ShieldOnTime = 3f;

    public static float attackDistanceForAll = 15;
    public static float attackDistanceForStations = 16;
    public static float attackDistanceForGuns = 18;

    public static float moveSpeedFor0 = 0.07f;
    public static float moveSpeedFor1 = 0.09f;
    public static float moveSpeedFor2 = 0.11f;
    public static float moveSpeedFor3 = 0.13f;

    public static byte C1ProdEnergy = 80;
    public static byte C2ProdEnergy = 60;
    public static byte C3ProdEnergy = 40;
    public static byte C4ProdEnergy = 25;
    public static byte D1ProdEnergy = 58;
    public static byte D1PProdEnergy = 55;
    public static byte D2ProdEnergy = 45;
    public static byte D2PProdEnergy = 40;
    public static byte D3ProdEnergy = 20;
    public static byte D4ProdEnergy = 10;

    //ship's power multiplyer index 
    public static byte Destr4Index = 1;
    public static byte Destr3Index = 2;
    public static byte Destr2Index = 3;
    public static byte Destr1Index = 4;
    public static byte Cruis4Index = 2;
    public static byte Cruis3Index = 3;
    public static byte Cruis2Index = 5;
    public static byte Cruis1Index = 7;
    public static byte Gun3Index = 7;
    public static byte Gun2Index = 5;
    public static byte Gun1Index = 3;

    public static int enrgy0to1Upgrd = 250;
    public static int enrgy1to2Upgrd = 400;
    public static int enrgy2to3Upgrd = 600;

    public static int gun0to1Upgrd = 200;
    public static int gun1to2Upgrd = 350;
    public static int gun2to3Upgrd = 500;

    public static float gun1MaxAttackTime = 5.5f;
    public static float gun1MinAttackTime = 4.5f;
    public static float gun2MaxAttackTime = 4.5f;
    public static float gun2MinAttackTime = 3.5f;
    public static float gun3MaxAttackTime = 3.5f;
    public static float gun3MinAttackTime = 2.5f;


    public static bool stationPanelIsActive;
    public GameObject stationPanel;
    public static PanelStation stationPanelScript;

    //for star with 0 upgrades there is no reducer of filling line
    public static float star1FillingReducer = 0.9f;
    public static float star2FillingReducer = 0.8f;
    public static float star3FillingReducer = 0.7f;

    public static int Station0EnergytoShot = 5; //10
    public static int Station1EnergytoShot = 10; //20
    public static int Station2EnergytoShot = 15; //35
    public static int Station3EnergytoShot = 20; //50

    public static int Station0EnergyToConnection = 100;
    public static int Station1EnergyToConnection = 150;
    public static int Station2EnergyToConnection = 200;
    public static int Station3EnergyToConnection = 250;

    public static float Station0EnergyProduceTime = 7;
    public static float Station1EnergyProduceTime = 6;
    public static float Station2EnergyProduceTime = 5;
    public static float Station3EnergyProduceTime = 4;

    public static float Station0EnergonCatchDistance = 30f;
    public static float Station1EnergonCatchDistance = 35f;
    public static float Station2EnergonCatchDistance = 40f;
    public static float Station3EnergonCatchDistance = 45f;

    public static float Station0BulletSpeed = 10f;
    public static float Station1BulletSpeed = 13f;
    public static float Station2BulletSpeed = 16f;
    public static float Station3BulletSpeed = 20f;

    public static float Station0ColorToEnergyMultiplyer = 5f; //15
    public static float Station1ColorToEnergyMultiplyer = 10f; //20
    public static float Station2ColorToEnergyMultiplyer = 15f; //25
    public static float Station3ColorToEnergyMultiplyer = 20f; //30

    public static float Station0ShotTime = 20f;
    public static float Station1ShotTime = 17f;
    public static float Station2ShotTime = 15f;
    public static float Station3ShotTime = 12f;

    public static byte Station0ShipsLimit = 16;
    public static byte Station1ShipsLimit = 18;
    public static byte Station2ShipsLimit = 20;
    public static byte Station3ShipsLimit = 23;

    public static List<LineRenderer> stationsConnectionLines;


    public static float gunBulletHarm = 2.5f; //cause there are 2 and 3 bullets at once on Gun2 and 3 lvls the gun bullet harm is one for all types of guns. Total harm will be more for higher level guns


    public static AudioSource UIButtonSound;
    public static AudioSource UpgradeSound;

    //is used by CPU battle ships to avoid the ather stations on way to attack
    public static List <Vector3> HexBorderDots;

    public static Dictionary<int, List<ConnectionLine>> connectionLines;

    public static Dictionary<int, List<List<StationClass>>>  StationGroups;

    public static Dictionary<List<StationClass>, int> energyOfStationGroups;

    //public static List<Transform> enenrgyBalls;
    //private static GameObject ObjectPulled;
    //private static List<GameObject> ObjectPulledList;
    //private static int firstRingMax;
    //private static float radiusGroup;

    //public void removeDisabledFromLists(string objectName) {
    //    if (objectName.Contains("gun")) {
    //        List<PlayerGun> removeList = new List<PlayerGun>();
    //        for (int i = 0; i < playerGuns.Count; i++)
    //        {
    //            if (!playerGuns[i].isActiveAndEnabled) removeList.Add(playerGuns[i]);
    //        }
    //        foreach (PlayerGun PG in removeList) playerGuns.Remove(PG);
    //    }

    //}


    private void Awake()
    {
        StationGroups = new Dictionary<int, List<List<StationClass>>>();
        energyOfStationGroups = new Dictionary<List<StationClass>, int>();
        connectionLines = new Dictionary<int, List<ConnectionLine>>();
        HexBorderDots = new List<Vector3>();
            //firstRingMax = 20;
            //radiusGroup = 30;
            UIButtonSound = GetComponent<AudioSource>();
        UpgradeSound = transform.GetChild(0).GetComponent<AudioSource>();
        CPUMegaAttackCoroutineIsOn = false;
        allStations = new List<StationClass>();

        playerBattleShips = new List<PlayerBattleShip>();
        playerStations = new List<StationClass>();
        playerGuns = new List<PlayerGun>();

        CPUBattleShips = new List<CPUBattleShip>();
        CPU1Ships = new List<CPUBattleShip>();
        CPU2Ships = new List<CPUBattleShip>();
        CPU3Ships = new List<CPUBattleShip>();
        CPU4Ships = new List<CPUBattleShip>();

        CPUStations = new List<StationCPU>();
        CPU1Stations = new List<StationClass>();
        CPU2Stations = new List<StationClass>();
        CPU3Stations = new List<StationClass>();
        CPU4Stations = new List<StationClass>();
        //enenrgyBalls = new List<Transform>();
        stationsConnectionLines = new List<LineRenderer>();
        stars = new List<StarController>();
        energonsOnScene = new List<EnergonMoving>();
        CPUBattleShipsDictionary = new Dictionary<int, List<CPUBattleShip>>();
        CPUStationsDictionary = new Dictionary<int, List<StationClass>>();

        CPUMegaAttackBattleShips = new List<CPUBattleShip>();

        //populating the dictionary of CPU battle ships collections
        for (int i = 0; i < 4; i++) {
            if (i==0) CPUBattleShipsDictionary.Add(i, CPU1Ships);
            if (i == 1) CPUBattleShipsDictionary.Add(i, CPU2Ships);
            if (i == 2) CPUBattleShipsDictionary.Add(i, CPU3Ships);
            if (i == 3) CPUBattleShipsDictionary.Add(i, CPU4Ships);
        }

        for (int i = 0; i < 4; i++)
        {
            if (i == 0) CPUStationsDictionary.Add(i, CPU1Stations);
            if (i == 1) CPUStationsDictionary.Add(i, CPU2Stations);
            if (i == 2) CPUStationsDictionary.Add(i, CPU3Stations);
            if (i == 3) CPUStationsDictionary.Add(i, CPU4Stations);
        }
    }

    private void OnEnable()
    {
        stationPanelScript = stationPanel.GetComponent<PanelStation>();
        //Debug.Log(0%2);
        MainCameraOfRTS = Camera.main;
        MainCameraOfRTSTransform = MainCameraOfRTS.transform;
        gameController = FindObjectOfType<GameController>();
        Invoke("populateTheCoordinatesBaseOfHexBordersDots", 0.5f);
    }

    public static IEnumerator CPUMegaAttack() {
        CPUMegaAttackCoroutineIsOn = true;
        yield return new WaitForSeconds(Random.Range(1.5f, 5f));

        CPUMegaAttackCoroutineIsOn = false;

        if (CPUMegaAttackBattleShips.Count == 1) CPUMegaAttackBattleShips[0].MegaAttackOfShip();
        else if (CPUMegaAttackBattleShips.Count > 0)
        {
            CPUBattleShip chousenCruiser = null;
            for (int i = 0; i < CPUMegaAttackBattleShips.Count; i++)
            {
                if (i == 0) chousenCruiser = CPUMegaAttackBattleShips[i];
                else if (chousenCruiser.countOfEnemyShipsNear() < CPUMegaAttackBattleShips[i].countOfEnemyShipsNear()) chousenCruiser = CPUMegaAttackBattleShips[i];
            }
            chousenCruiser.MegaAttackOfShip();
        }
        CPUMegaAttackTimer = megaAttackTime;
    }

    //is used by CPU battle ships to avoid the other stations on way to attack
    private void populateTheCoordinatesBaseOfHexBordersDots()
    {
        //5 dots on left border of map where only 2 hexes ar one on top of other
        int x = 5;
        float xCoorPrev = 0;
        float zCoorPrev = 0;
        float xCoor = 0;
        float zCoor = 0;
        for (int i = 0; i < 6; i++)
        {
            if (i == 0)
            {
                xCoor = 200.2f;
                zCoor = -100;
                xCoorPrev = xCoor;
                zCoorPrev = zCoor;
            }
            else if (i == 3)
            {
                xCoor = -28.4f;
                zCoor = -200;
                xCoorPrev = xCoor;
                zCoorPrev = zCoor;
            }
            for (int y = 0; y < x; y++)
            {
                if (y != 0)
                {
                    if (i < 3)
                    {
                        if (y % 2 > 0) xCoor += 29.1f;
                        else xCoor -= 29.1f;
                    }
                    else
                    {
                        if (y % 2 > 0) xCoor -= 29.1f;
                        else xCoor += 29.1f;
                    }
                    zCoor += 50;
                }
                HexBorderDots.Add(new Vector3 (xCoor,0, zCoor));
            }

                xCoor = xCoorPrev - 85.9f;
                xCoorPrev = xCoor;
                if (i < 2)
                {
                    x += 2; //increasing or decrasing the dots depending how many hexes are on top of each other while moving from left to right of map
                    zCoor = zCoorPrev - 50;
                }
                else if (i == 2) zCoor = zCoorPrev;
                else if (i > 2)
                {
                    x -= 2; //increasing or decrasing the dots depending how many hexes are on top of each other while moving from left to right of map 
                    zCoor = zCoorPrev + 50;
                }
                zCoorPrev = zCoor;
        }

        //foreach (Vector3 pos in HexBorderDots) Instantiate(testSphere, pos, Quaternion.identity);
    }



    //public static void distributeEnergy(int energyBallsCount)
    //{

    //    float stepForOuterRadius = 1;
    //    for (int i = 0; i < energyBallsCount; i++)
    //    {
    //        if (i == 0)
    //        {
    //            ObjectPulledList = ObjectPullerRTS.current.GetEnergyPulls(Random.Range(0, 3));
    //            ObjectPulled = ObjectPullerRTS.current.GetGameObjectFromPull(ObjectPulledList);
    //            ObjectPulled.transform.position = Vector3.zero;
    //            enenrgyBalls.Add(ObjectPulled.transform);
    //            ObjectPulled.SetActive(true);
    //        }
    //        else if (i <= firstRingMax)
    //        {
    //            if (radiusGroup != 20) radiusGroup = 20;
    //            Vector3 newPos;
    //            float step = (Mathf.PI * 2) / firstRingMax; // отступ
    //            newPos.x = Vector3.zero.x + Mathf.Sin(step * i) * radiusGroup + Random.Range(-10f, 10f); // по оси X
    //            newPos.z = Vector3.zero.z + Mathf.Cos(step * i) * radiusGroup + Random.Range(-10f, 10f); // по оси Z
    //            newPos.y = 0; // по оси Y всегда 0

    //            ObjectPulledList = ObjectPullerRTS.current.GetEnergyPulls(2);
    //            ObjectPulled = ObjectPullerRTS.current.GetGameObjectFromPull(ObjectPulledList);
    //            ObjectPulled.transform.position = newPos;
    //            enenrgyBalls.Add(ObjectPulled.transform);
    //            ObjectPulled.SetActive(true);

    //            if (i == firstRingMax)
    //            {
    //                if ((energyBallsCount - enenrgyBalls.Count) > firstRingMax * 2) stepForOuterRadius = firstRingMax * 2;
    //                else stepForOuterRadius = energyBallsCount - enenrgyBalls.Count;
    //            }
    //        }
    //        else if (i <= (firstRingMax * 3))
    //        {



    //            if (radiusGroup != 60) radiusGroup = 60;
    //            Vector3 newPos;
    //            float step = (Mathf.PI * 2) / firstRingMax; // отступ
    //            newPos.x = Vector3.zero.x + Mathf.Sin(step * i) * radiusGroup + Random.Range(-15f, 15f); // по оси X
    //            newPos.z = Vector3.zero.z + Mathf.Cos(step * i) * radiusGroup + Random.Range(-15f, 15f); // по оси Z
    //            newPos.y = 0; // по оси Y всегда 0

    //            ObjectPulledList = ObjectPullerRTS.current.GetEnergyPulls(Random.Range(0, 3));
    //            ObjectPulled = ObjectPullerRTS.current.GetGameObjectFromPull(ObjectPulledList);
    //            ObjectPulled.transform.position = newPos;
    //            enenrgyBalls.Add(ObjectPulled.transform);
    //            ObjectPulled.SetActive(true);

    //            if (i == firstRingMax)
    //            {
    //                if ((energyBallsCount - enenrgyBalls.Count) > firstRingMax * 3) stepForOuterRadius = firstRingMax * 3;
    //                else stepForOuterRadius = energyBallsCount - enenrgyBalls.Count;
    //            }




    //        }
    //        else if (i <= (firstRingMax * 7))
    //        {


    //            if (radiusGroup != 100) radiusGroup = 100;
    //            Vector3 newPos;
    //            float step = (Mathf.PI * 2) / firstRingMax; // отступ
    //            newPos.x = Vector3.zero.x + Mathf.Sin(step * i) * radiusGroup + Random.Range(-15f, 15f); // по оси X
    //            newPos.z = Vector3.zero.z + Mathf.Cos(step * i) * radiusGroup + Random.Range(-15f, 15f); // по оси Z
    //            newPos.y = 0; // по оси Y всегда 0

    //            ObjectPulledList = ObjectPullerRTS.current.GetEnergyPulls(Random.Range(0, 3));
    //            ObjectPulled = ObjectPullerRTS.current.GetGameObjectFromPull(ObjectPulledList);
    //            ObjectPulled.transform.position = newPos;
    //            enenrgyBalls.Add(ObjectPulled.transform);
    //            ObjectPulled.SetActive(true);

    //            if (i == firstRingMax)
    //            {
    //                if ((energyBallsCount - enenrgyBalls.Count) > firstRingMax * 4) stepForOuterRadius = firstRingMax * 4;
    //                else stepForOuterRadius = energyBallsCount - enenrgyBalls.Count;
    //            }


    //        }
    //        else if (i <= (firstRingMax * 15))
    //        {


    //            if (radiusGroup != 200) radiusGroup = 200;
    //            Vector3 newPos;
    //            float step = (Mathf.PI * 2) / firstRingMax; // отступ
    //            newPos.x = Vector3.zero.x + Mathf.Sin(step * i) * radiusGroup + Random.Range(-15f, 15f); // по оси X
    //            newPos.z = Vector3.zero.z + Mathf.Cos(step * i) * radiusGroup + Random.Range(-15f, 15f); // по оси Z
    //            newPos.y = 0; // по оси Y всегда 0

    //            ObjectPulledList = ObjectPullerRTS.current.GetEnergyPulls(Random.Range(0, 3));
    //            ObjectPulled = ObjectPullerRTS.current.GetGameObjectFromPull(ObjectPulledList);
    //            ObjectPulled.transform.position = newPos;
    //            enenrgyBalls.Add(ObjectPulled.transform);

    //            if (i == firstRingMax)
    //            {
    //                if ((energyBallsCount - enenrgyBalls.Count) > firstRingMax * 4) stepForOuterRadius = firstRingMax * 4;
    //                else stepForOuterRadius = energyBallsCount - enenrgyBalls.Count;
    //            }



    //        }
    //    }

    //}
    private void Update()
    {
        if (CPUMegaAttackTimer > 0)
        {
            CPUMegaAttackTimer -= Time.deltaTime;
            if (CPUMegaAttackTimer <= 0) {
                CPUMegaAttackTimer = 0;
                if (CPUMegaAttackBattleShips.Count > 0 && !CPUMegaAttackCoroutineIsOn) StartCoroutine(CPUMegaAttack());
            }
        }
    }

}
