using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject scoutPrefab;
    public GameObject cruiserPrefab;
    public GameObject dreadnoughtPrefab;
    public GameObject frigatePrefab;
    public GameObject interceptorPrefab;
    public GameObject battleshipPrefab;
    public GameObject carrierPrefab;
    public GameObject annihilatorPrefab;
    public GameObject reaperPrefab;
    public GameObject titanPrefab;
    public GameObject eclipsePrefab;
    public GameObject executorPrefab;
    public GameObject vandalPrefab;
    public GameObject phantomPrefab;
    public GameObject tormenterPrefab;
    public GameObject swarmerPrefab;
    public GameObject pulveriserPrefab;
    public GameObject tempestPrefab;

    public GameObject scoutSpaceGatePrefab;
    public GameObject cruiserSpaceGatePrefab;
    public GameObject dreadnoughtSpaceGatePrefab;
    public GameObject frigateSpaceGatePrefab;
    public GameObject interceptorSpaceGatePrefab;
    public GameObject battleshipSpaceGatePrefab;

    public static int spaceGateCountLimit = 25;
    public static int spaceGateCount = 0;

    private float lateralBounds = 400f;
    private float lowerLimit = 40f;
    private float upperLimit = 75f;
    private int direction;
    private float xVal;
    private float yVal;
    private float zVal;
    private int zValPick;
    private Vector3 randSpawnPoint;
    private float startingDelay = 0f;

    void Start()
    {
        InvokeRepeating("SpawnScout", startingDelay, 10f);
        InvokeRepeating("SpawnCruiser", startingDelay + 120f, 20f);
        InvokeRepeating("SpawnDreadnought", startingDelay + 240f, 40f);
        InvokeRepeating("SpawnFrigate", startingDelay + 360f, 60f);
        InvokeRepeating("SpawnInterceptor", startingDelay + 480f, 80f);
        InvokeRepeating("SpawnBattleship", startingDelay + 600f, 100f);
        InvokeRepeating("SpawnCarrier", startingDelay + 720f, 120f);
        InvokeRepeating("SpawnAnnihilator", startingDelay + 840f, 140f);
        InvokeRepeating("SpawnReaper", startingDelay + 960f, 160f);
        InvokeRepeating("SpawnTitan", startingDelay + 1080f, 180f);
        InvokeRepeating("SpawnEclipse", startingDelay + 1200f, 200f);
        InvokeRepeating("SpawnExecutor", startingDelay + 2040f, 220f);
        InvokeRepeating("SpawnVandal", startingDelay + 2160f, 240f);
        InvokeRepeating("SpawnPhantom", startingDelay + 2280f, 260f);
        InvokeRepeating("SpawnTormenter", startingDelay + 2400f, 280f);
        InvokeRepeating("SpawnSwarmer", startingDelay + 2520f, 300f);
        InvokeRepeating("SpawnPulveriser", startingDelay + 2640f, 320f);
        InvokeRepeating("SpawnTempest", startingDelay + 2760f, 340f);

        InvokeRepeating("SpawnScoutSpaceGate", startingDelay + 1320f, 220f);
        InvokeRepeating("SpawnCruiserSpaceGate", startingDelay + 1440f, 240f);
        InvokeRepeating("SpawnDreadnoughtSpaceGate", startingDelay + 1560f, 260f);
        InvokeRepeating("SpawnFrigateSpaceGate", startingDelay + 1680f, 280f);
        InvokeRepeating("SpawnInterceptorSpaceGate", startingDelay + 1800f, 300f);
        InvokeRepeating("SpawnBattleshipSpaceGate", startingDelay + 1920f, 320f);
    }

    public Vector3 GenerateSpawnPoint()
    {
        direction = Random.Range(0, 4);
        if (direction == 0)
        {
            // North:
            zVal = lateralBounds;
            xVal = Random.Range(-lateralBounds, lateralBounds + 1);
        }
        else if (direction == 1)
        {
            // East:
            zVal = Random.Range(-lateralBounds, lateralBounds + 1);
            xVal = lateralBounds;
        }
        else if (direction == 2)
        {
            // South:
            zVal = -lateralBounds;
            xVal = Random.Range(-lateralBounds, lateralBounds + 1);
        }
        else
        {
            // West:
            zVal = Random.Range(-lateralBounds, lateralBounds + 1);
            xVal = -lateralBounds;
        }
        yVal = Random.Range(lowerLimit, upperLimit);
        randSpawnPoint = new Vector3(xVal, yVal, zVal);
        return randSpawnPoint;
    }

    Quaternion CalculateRotation(Vector3 spawnPoint)
    {
        Vector3 dir = Vector3.zero - spawnPoint;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        return lookRotation;
    }
    
    void SpawnScout()
    {
        GenerateSpawnPoint();
        Instantiate(scoutPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnCruiser()
    {
        GenerateSpawnPoint();
        Instantiate(cruiserPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnDreadnought()
    {
        GenerateSpawnPoint();
        Instantiate(dreadnoughtPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnFrigate()
    {
        GenerateSpawnPoint();
        Instantiate(frigatePrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnInterceptor()
    {
        GenerateSpawnPoint();
        Instantiate(interceptorPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnBattleship()
    {
        GenerateSpawnPoint();
        Instantiate(battleshipPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnCarrier()
    {
        GenerateSpawnPoint();
        Instantiate(carrierPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnAnnihilator()
    {
        GenerateSpawnPoint();
        Instantiate(annihilatorPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnReaper()
    {
        GenerateSpawnPoint();
        Instantiate(reaperPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }
    void SpawnTitan()
    {
        GenerateSpawnPoint();
        Instantiate(titanPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnEclipse()
    {
        GenerateSpawnPoint();
        Instantiate(eclipsePrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnExecutor()
    {
        GenerateSpawnPoint();
        Instantiate(executorPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnVandal()
    {
        GenerateSpawnPoint();
        Instantiate(vandalPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnPhantom()
    {
        GenerateSpawnPoint();
        Instantiate(phantomPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnTormenter()
    {
        GenerateSpawnPoint();
        Instantiate(tormenterPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnSwarmer()
    {
        GenerateSpawnPoint();
        Instantiate(swarmerPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnPulveriser()
    {
        GenerateSpawnPoint();
        Instantiate(pulveriserPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnTempest()
    {
        GenerateSpawnPoint();
        Instantiate(tempestPrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
    }

    void SpawnScoutSpaceGate()
    {
        if (spaceGateCount < spaceGateCountLimit)
        {
            GenerateSpawnPoint();
            Instantiate(scoutSpaceGatePrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
            spaceGateCount ++;
        }
    }

    void SpawnCruiserSpaceGate()
    {
        if (spaceGateCount < spaceGateCountLimit)
        {
            GenerateSpawnPoint();
            Instantiate(cruiserSpaceGatePrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
            spaceGateCount ++;
        }
    }

    void SpawnDreadnoughtSpaceGate()
    {
        if (spaceGateCount < spaceGateCountLimit)
        {
            GenerateSpawnPoint();
            Instantiate(dreadnoughtSpaceGatePrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
            spaceGateCount ++;
        }
    }

    void SpawnFrigateSpaceGate()
    {
        if (spaceGateCount < spaceGateCountLimit)
        {
            GenerateSpawnPoint();
            Instantiate(frigateSpaceGatePrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
            spaceGateCount ++;
        }
    }

    void SpawnInterceptorSpaceGate()
    {
        if (spaceGateCount < spaceGateCountLimit)
        {
            GenerateSpawnPoint();
            Instantiate(interceptorSpaceGatePrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
            spaceGateCount ++;
        }
    }

    void SpawnBattleshipSpaceGate()
    {
        if (spaceGateCount < spaceGateCountLimit)
        {
            GenerateSpawnPoint();
            Instantiate(battleshipSpaceGatePrefab, randSpawnPoint, CalculateRotation(randSpawnPoint));
            spaceGateCount ++;
        }
    }
}
