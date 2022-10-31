using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DroidPortProduction : MonoBehaviour
{
    public Transform portOrigin;
    public GameObject sentryPrefab;
    public GameObject sentrySpawnEffect;
    public GameObject enforcerPrefab;
    public GameObject enforcerSpawnEffect;
    public GameObject guardianPrefab;
    public GameObject guardianSpawnEffect;
    public GameObject starWardenPrefab;
    public GameObject starWardenSpawnEffect;
    public GameObject callistoDroidPrefab;
    public GameObject callistoDroidSpawnEffect;
    public GameObject abyssRayPrefab;
    public GameObject abyssRaySpawnEffect;
    public GameObject disruptorPrefab;
    public GameObject disruptorSpawnEffect;
    public GameObject deceptorPrefab;
    public GameObject deceptorSpawnEffect;
    public GameObject nightHunterPrefab;
    public GameObject nightHunterSpawnEffect;

    public GameObject buildOptionMenu;
    public GameObject productionMenu;
    public GameObject buildingIndicator;

    public TextMeshProUGUI sentryCost;
    public int sentryBuildCount;
    public TextMeshProUGUI sentryCountText;
    public TextMeshProUGUI enforcerCost;
    public int enforcerBuildCount;
    public TextMeshProUGUI enforcerCountText;
    public TextMeshProUGUI guardianCost;
    public int guardianBuildCount;
    public TextMeshProUGUI guardianCountText;
    public TextMeshProUGUI starWardenCost;
    public int starWardenBuildCount;
    public TextMeshProUGUI starWardenCountText;
    public TextMeshProUGUI callistoDroidCost;
    public int callistoDroidBuildCount;
    public TextMeshProUGUI callistoDroidCountText;
    public TextMeshProUGUI abyssRayCost;
    public int abyssRayBuildCount;
    public TextMeshProUGUI abyssRayCountText;
    public TextMeshProUGUI disruptorCost;
    public TextMeshProUGUI disruptorArtifactCost;
    public int disruptorBuildCount;
    public TextMeshProUGUI disruptorCountText;
    public TextMeshProUGUI deceptorCost;
    public TextMeshProUGUI deceptorArtifactCost;
    public int deceptorBuildCount;
    public TextMeshProUGUI deceptorCountText;
    public TextMeshProUGUI nightHunterCost;
    public TextMeshProUGUI nightHunterArtifactCost;
    public int nightHunterBuildCount;
    public TextMeshProUGUI nightHunterCountText;

    private float cost;
    private int artifactCost;
    private bool notBuildingUnit = true;
    RaycastHit hit;
    private List<string> buildQueue = new List<string>();

    void Start()
    {
        sentryCost.text = sentryPrefab.GetComponent<SentryCost>().sentryCost.ToString();
        sentryBuildCount = 0;
        sentryCountText.text = "";
        enforcerCost.text = enforcerPrefab.GetComponent<EnforcerCost>().enforcerCost.ToString();
        enforcerBuildCount = 0;
        enforcerCountText.text = "";
        guardianCost.text = guardianPrefab.GetComponent<GuardianCost>().guardianCost.ToString();
        guardianBuildCount = 0;
        guardianCountText.text = "";
        starWardenCost.text = starWardenPrefab.GetComponent<StarWardenCost>().starWardenCost.ToString();
        starWardenBuildCount = 0;
        starWardenCountText.text = "";
        callistoDroidCost.text = callistoDroidPrefab.GetComponent<CallistoDroidCost>().callistoDroidCost.ToString();
        callistoDroidBuildCount = 0;
        callistoDroidCountText.text = "";
        abyssRayCost.text = abyssRayPrefab.GetComponent<AbyssRayCost>().abyssRayCost.ToString();
        abyssRayBuildCount = 0;
        abyssRayCountText.text = "";
        disruptorCost.text = disruptorPrefab.GetComponent<DisruptorCost>().disruptorCost.ToString();
        disruptorArtifactCost.text = disruptorPrefab.GetComponent<DisruptorCost>().disruptorArtifactCost.ToString();
        disruptorBuildCount = 0;
        disruptorCountText.text = "";
        deceptorCost.text = deceptorPrefab.GetComponent<DeceptorCost>().deceptorCost.ToString();
        deceptorArtifactCost.text = deceptorPrefab.GetComponent<DeceptorCost>().deceptorArtifactCost.ToString();
        deceptorBuildCount = 0;
        deceptorCountText.text = "";
        nightHunterCost.text = nightHunterPrefab.GetComponent<NightHunterCost>().nightHunterCost.ToString();
        nightHunterArtifactCost.text = nightHunterPrefab.GetComponent<NightHunterCost>().nightHunterArtifactCost.ToString();
        nightHunterBuildCount = 0;
        nightHunterCountText.text = "";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.GetComponent<Health>().health > 0)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if ((hit.collider.gameObject != gameObject && hit.collider.gameObject.tag == "EnemyTarget") || !BuildToggle.onProductionMenu)
                {
                    buildOptionMenu.SetActive(false);
                    productionMenu.SetActive(false);
                }
                if (BuildToggle.isBuilding == true && !BuildToggle.onPlayerInterface && ((hit.collider.gameObject == gameObject && !BuildToggle.onProductionMenu) || (BuildToggle.onProductionMenu && BuildToggle.currentProductionMenu == productionMenu)))
                {
                    buildOptionMenu.SetActive(true);
                    productionMenu.SetActive(true);
                    BuildToggle.currentProductionMenu = productionMenu;
                }
            }
        }

        if (BuildToggle.isBuilding == false || gameObject.GetComponent<Health>().health < 0 || TimeManager.isPaused)
        {
            buildOptionMenu.SetActive(false);
        }

        if (buildOptionMenu.activeSelf)
        {
            buildingIndicator.SetActive(true);
        }
        else
        {
            buildingIndicator.SetActive(false);
        }

        if (buildQueue.Count != 0)
        {
            ManageProduction();
        }
    }

    public void BuildSentry()
    {
        cost = sentryPrefab.GetComponent<SentryCost>().sentryCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            sentryBuildCount ++;
            sentryCountText.text = sentryBuildCount.ToString();
            buildQueue.Add("Sentry");
            ResourceManager.credits -= cost;
        }
        else if (cost > ResourceManager.credits)
        {
            NotificationManager.insufficientCredits = true;
        }
        else if (ResourceManager.insufficientWorkers)
        {
            NotificationManager.insufficientWorkers = true;
        }
    }

    IEnumerator SpawnSentry()
    {
        notBuildingUnit = false;
        Instantiate(sentrySpawnEffect, portOrigin.position, portOrigin.rotation);
        yield return new WaitForSeconds(sentryPrefab.GetComponent<SentryCost>().sentryProductionTime);
        notBuildingUnit = true;
        sentryBuildCount --;
        if (sentryBuildCount == 0)
        {
            sentryCountText.text = "";
        }
        else
        {
            sentryCountText.text = sentryBuildCount.ToString();
        }
        Instantiate(sentryPrefab, portOrigin.position, portOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildEnforcer()
    {
        cost = enforcerPrefab.GetComponent<EnforcerCost>().enforcerCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            enforcerBuildCount ++;
            enforcerCountText.text = enforcerBuildCount.ToString();
            buildQueue.Add("Enforcer");
            ResourceManager.credits -= cost;
        }
        else if (cost > ResourceManager.credits)
        {
            NotificationManager.insufficientCredits = true;
        }
        else if (ResourceManager.insufficientWorkers)
        {
            NotificationManager.insufficientWorkers = true;
        }
    }

    IEnumerator SpawnEnforcer()
    {
        notBuildingUnit = false;
        Instantiate(enforcerSpawnEffect, portOrigin.position, portOrigin.rotation);
        yield return new WaitForSeconds(enforcerPrefab.GetComponent<EnforcerCost>().enforcerProductionTime);
        notBuildingUnit = true;
        enforcerBuildCount --;
        if (enforcerBuildCount == 0)
        {
            enforcerCountText.text = "";
        }
        else
        {
            enforcerCountText.text = enforcerBuildCount.ToString();
        }
        Instantiate(enforcerPrefab, portOrigin.position, portOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildGuardian()
    {
        cost = guardianPrefab.GetComponent<GuardianCost>().guardianCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            guardianBuildCount ++;
            guardianCountText.text = guardianBuildCount.ToString();
            buildQueue.Add("Guardian");
            ResourceManager.credits -= cost;
        }
        else if (cost > ResourceManager.credits)
        {
            NotificationManager.insufficientCredits = true;
        }
        else if (ResourceManager.insufficientWorkers)
        {
            NotificationManager.insufficientWorkers = true;
        }
    }

    IEnumerator SpawnGuardian()
    {
        notBuildingUnit = false;
        Instantiate(guardianSpawnEffect, portOrigin.position, portOrigin.rotation);
        yield return new WaitForSeconds(guardianPrefab.GetComponent<GuardianCost>().guardianProductionTime);
        notBuildingUnit = true;
        guardianBuildCount --;
        if (guardianBuildCount == 0)
        {
            guardianCountText.text = "";
        }
        else
        {
            guardianCountText.text = guardianBuildCount.ToString();
        }
        Instantiate(guardianPrefab, portOrigin.position, portOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildStarWarden()
    {
        cost = starWardenPrefab.GetComponent<StarWardenCost>().starWardenCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            starWardenBuildCount ++;
            starWardenCountText.text = starWardenBuildCount.ToString();
            buildQueue.Add("StarWarden");
            ResourceManager.credits -= cost;
        }
        else if (cost > ResourceManager.credits)
        {
            NotificationManager.insufficientCredits = true;
        }
        else if (ResourceManager.insufficientWorkers)
        {
            NotificationManager.insufficientWorkers = true;
        }
    }

    IEnumerator SpawnStarWarden()
    {
        notBuildingUnit = false;
        Instantiate(starWardenSpawnEffect, portOrigin.position, portOrigin.rotation);
        yield return new WaitForSeconds(starWardenPrefab.GetComponent<StarWardenCost>().starWardenProductionTime);
        notBuildingUnit = true;
        starWardenBuildCount --;
        if (starWardenBuildCount == 0)
        {
            starWardenCountText.text = "";
        }
        else
        {
            starWardenCountText.text = starWardenBuildCount.ToString();
        }
        Instantiate(starWardenPrefab, portOrigin.position, portOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildCallistoDroid()
    {
        cost = callistoDroidPrefab.GetComponent<CallistoDroidCost>().callistoDroidCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            callistoDroidBuildCount ++;
            callistoDroidCountText.text = callistoDroidBuildCount.ToString();
            buildQueue.Add("CallistoDroid");
            ResourceManager.credits -= cost;
        }
        else if (cost > ResourceManager.credits)
        {
            NotificationManager.insufficientCredits = true;
        }
        else if (ResourceManager.insufficientWorkers)
        {
            NotificationManager.insufficientWorkers = true;
        }
    }

    IEnumerator SpawnCallistoDroid()
    {
        notBuildingUnit = false;
        Instantiate(callistoDroidSpawnEffect, portOrigin.position, portOrigin.rotation);
        yield return new WaitForSeconds(callistoDroidPrefab.GetComponent<CallistoDroidCost>().callistoDroidProductionTime);
        notBuildingUnit = true;
        callistoDroidBuildCount --;
        if (callistoDroidBuildCount == 0)
        {
            callistoDroidCountText.text = "";
        }
        else
        {
            callistoDroidCountText.text = callistoDroidBuildCount.ToString();
        }
        Instantiate(callistoDroidPrefab, portOrigin.position, portOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildAbyssRay()
    {
        cost = abyssRayPrefab.GetComponent<AbyssRayCost>().abyssRayCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            abyssRayBuildCount ++;
            abyssRayCountText.text = abyssRayBuildCount.ToString();
            buildQueue.Add("AbyssRay");
            ResourceManager.credits -= cost;
        }
        else if (cost > ResourceManager.credits)
        {
            NotificationManager.insufficientCredits = true;
        }
        else if (ResourceManager.insufficientWorkers)
        {
            NotificationManager.insufficientWorkers = true;
        }
    }

    IEnumerator SpawnAbyssRay()
    {
        notBuildingUnit = false;
        Instantiate(abyssRaySpawnEffect, portOrigin.position, portOrigin.rotation);
        yield return new WaitForSeconds(abyssRayPrefab.GetComponent<AbyssRayCost>().abyssRayProductionTime);
        notBuildingUnit = true;
        abyssRayBuildCount --;
        if (abyssRayBuildCount == 0)
        {
            abyssRayCountText.text = "";
        }
        else
        {
            abyssRayCountText.text = abyssRayBuildCount.ToString();
        }
        Instantiate(abyssRayPrefab, portOrigin.position, portOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildDisruptor()
    {
        cost = disruptorPrefab.GetComponent<DisruptorCost>().disruptorCost;
        artifactCost = disruptorPrefab.GetComponent<DisruptorCost>().disruptorArtifactCost;
        if (cost <= ResourceManager.credits && artifactCost <= ResourceManager.artifactOneCount && !ResourceManager.insufficientWorkers)
        {
            disruptorBuildCount ++;
            disruptorCountText.text = disruptorBuildCount.ToString();
            buildQueue.Add("Disruptor");
            ResourceManager.credits -= cost;
            ResourceManager.artifactOneCount -= artifactCost;
        }
        else if (cost > ResourceManager.credits)
        {
            NotificationManager.insufficientCredits = true;
        }
        else if (ResourceManager.insufficientWorkers)
        {
            NotificationManager.insufficientWorkers = true;
        }
        else if (artifactCost > ResourceManager.artifactOneCount)
        {
            NotificationManager.insufficientArtifacts = true;
        }
    }

    IEnumerator SpawnDisruptor()
    {
        notBuildingUnit = false;
        Instantiate(disruptorSpawnEffect, portOrigin.position, portOrigin.rotation);
        yield return new WaitForSeconds(disruptorPrefab.GetComponent<DisruptorCost>().disruptorProductionTime);
        notBuildingUnit = true;
        disruptorBuildCount --;
        if (disruptorBuildCount == 0)
        {
            disruptorCountText.text = "";
        }
        else
        {
            disruptorCountText.text = disruptorBuildCount.ToString();
        }
        Instantiate(disruptorPrefab, portOrigin.position, portOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildDeceptor()
    {
        cost = deceptorPrefab.GetComponent<DeceptorCost>().deceptorCost;
        artifactCost = deceptorPrefab.GetComponent<DeceptorCost>().deceptorArtifactCost;
        if (cost <= ResourceManager.credits && artifactCost <= ResourceManager.artifactTwoCount && !ResourceManager.insufficientWorkers)
        {
            deceptorBuildCount ++;
            deceptorCountText.text = deceptorBuildCount.ToString();
            buildQueue.Add("Deceptor");
            ResourceManager.credits -= cost;
            ResourceManager.artifactTwoCount -= artifactCost;
        }
        else if (cost > ResourceManager.credits)
        {
            NotificationManager.insufficientCredits = true;
        }
        else if (ResourceManager.insufficientWorkers)
        {
            NotificationManager.insufficientWorkers = true;
        }
        else if (artifactCost > ResourceManager.artifactTwoCount)
        {
            NotificationManager.insufficientArtifacts = true;
        }
    }

    IEnumerator SpawnDeceptor()
    {
        notBuildingUnit = false;
        Instantiate(deceptorSpawnEffect, portOrigin.position, portOrigin.rotation);
        yield return new WaitForSeconds(deceptorPrefab.GetComponent<DeceptorCost>().deceptorProductionTime);
        notBuildingUnit = true;
        deceptorBuildCount --;
        if (deceptorBuildCount == 0)
        {
            deceptorCountText.text = "";
        }
        else
        {
            deceptorCountText.text = deceptorBuildCount.ToString();
        }
        Instantiate(deceptorPrefab, portOrigin.position, portOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildNightHunter()
    {
        cost = nightHunterPrefab.GetComponent<NightHunterCost>().nightHunterCost;
        artifactCost = nightHunterPrefab.GetComponent<NightHunterCost>().nightHunterArtifactCost;
        if (cost <= ResourceManager.credits && artifactCost <= ResourceManager.artifactThreeCount && !ResourceManager.insufficientWorkers)
        {
            nightHunterBuildCount ++;
            nightHunterCountText.text = nightHunterBuildCount.ToString();
            buildQueue.Add("NightHunter");
            ResourceManager.credits -= cost;
            ResourceManager.artifactThreeCount -= artifactCost;
        }
        else if (cost > ResourceManager.credits)
        {
            NotificationManager.insufficientCredits = true;
        }
        else if (ResourceManager.insufficientWorkers)
        {
            NotificationManager.insufficientWorkers = true;
        }
        else if (artifactCost > ResourceManager.artifactThreeCount)
        {
            NotificationManager.insufficientArtifacts = true;
        }
    }

    IEnumerator SpawnNightHunter()
    {
        notBuildingUnit = false;
        Instantiate(nightHunterSpawnEffect, portOrigin.position, portOrigin.rotation);
        yield return new WaitForSeconds(nightHunterPrefab.GetComponent<NightHunterCost>().nightHunterProductionTime);
        notBuildingUnit = true;
        nightHunterBuildCount --;
        if (nightHunterBuildCount == 0)
        {
            nightHunterCountText.text = "";
        }
        else
        {
            nightHunterCountText.text = nightHunterBuildCount.ToString();
        }
        Instantiate(nightHunterPrefab, portOrigin.position, portOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    void ManageProduction()
    {
        if (buildQueue[0] == "Sentry" && notBuildingUnit)
        {
            StartCoroutine(SpawnSentry());
        }
        else if (buildQueue[0] == "Enforcer" && notBuildingUnit)
        {
            StartCoroutine(SpawnEnforcer());
        }
        else if (buildQueue[0] == "Guardian" && notBuildingUnit)
        {
            StartCoroutine(SpawnGuardian());
        }
        else if (buildQueue[0] == "StarWarden" && notBuildingUnit)
        {
            StartCoroutine(SpawnStarWarden());
        }
        else if (buildQueue[0] == "CallistoDroid" && notBuildingUnit)
        {
            StartCoroutine(SpawnCallistoDroid());
        }
        else if (buildQueue[0] == "AbyssRay" && notBuildingUnit)
        {
            StartCoroutine(SpawnAbyssRay());
        }
        else if (buildQueue[0] == "Disruptor" && notBuildingUnit)
        {
            StartCoroutine(SpawnDisruptor());
        }
        else if (buildQueue[0] == "Deceptor" && notBuildingUnit)
        {
            StartCoroutine(SpawnDeceptor());
        }
        else if (buildQueue[0] == "NightHunter" && notBuildingUnit)
        {
            StartCoroutine(SpawnNightHunter());
        }
    }

    public void CloseProductionMenu()
    {
        BuildToggle.currentProductionMenu = null;
    }
}