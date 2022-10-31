using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class SpaceDockProduction : MonoBehaviour
{
    public Transform spaceDockSpawnOrigin;
    public Transform spaceDockSpawnOriginHigher;
    public GameObject dragonheadPrefab;
    public GameObject dragonheadSpawnEffect;
    public GameObject phoenixPrefab;
    public GameObject phoenixSpawnEffect;
    public GameObject zephyrPrefab;
    public GameObject zephyrSpawnEffect;
    public GameObject galactisPrefab;
    public GameObject galactisSpawnEffect;
    public GameObject obeliskPrefab;
    public GameObject obeliskSpawnEffect;
    public GameObject hyperionPrefab;
    public GameObject hyperionSpawnEffect;
    public GameObject redOlympusPrefab;
    public GameObject redOlympusSpawnEffect;
    public GameObject etherealBladePrefab;
    public GameObject etherealBladeSpawnEffect;
    public GameObject skyOrchidPrefab;
    public GameObject skyOrchidSpawnEffect;


    public GameObject buildOptionMenu;
    public GameObject productionMenu;
    public GameObject buildingIndicator;

    public TextMeshProUGUI dragonheadCost;
    public int dragonheadBuildCount;
    public TextMeshProUGUI dragonheadCountText;
    public TextMeshProUGUI phoenixCost;
    public int phoenixBuildCount;
    public TextMeshProUGUI phoenixCountText;
    public TextMeshProUGUI zephyrCost;
    public int zephyrBuildCount;
    public TextMeshProUGUI zephyrCountText;
    public TextMeshProUGUI galactisCost;
    public int galactisBuildCount;
    public TextMeshProUGUI galactisCountText;
    public TextMeshProUGUI obeliskCost;
    public int obeliskBuildCount;
    public TextMeshProUGUI obeliskCountText;
    public TextMeshProUGUI hyperionCost;
    public int hyperionBuildCount;
    public TextMeshProUGUI hyperionCountText;
    public TextMeshProUGUI redOlympusCost;
    public TextMeshProUGUI redOlympusArtifactCost;
    public int redOlympusBuildCount;
    public TextMeshProUGUI redOlympusCountText;
    public TextMeshProUGUI etherealBladeCost;
    public TextMeshProUGUI etherealBladeArtifactCost;
    public int etherealBladeBuildCount;
    public TextMeshProUGUI etherealBladeCountText;
    public TextMeshProUGUI skyOrchidCost;
    public TextMeshProUGUI skyOrchidArtifactCost;
    public int skyOrchidBuildCount;
    public TextMeshProUGUI skyOrchidCountText;

    private float cost;
    private int artifactCost;
    private bool notBuildingUnit = true;
    private bool isProducing;
    RaycastHit hit;
    private List<string> buildQueue = new List<string>();

    void Start()
    {
        dragonheadCost.text = dragonheadPrefab.GetComponent<DragonheadCost>().dragonheadCost.ToString();
        dragonheadBuildCount = 0;
        dragonheadCountText.text = "";
        phoenixCost.text = phoenixPrefab.GetComponent<PhoenixCost>().phoenixCost.ToString();
        phoenixBuildCount = 0;
        phoenixCountText.text = "";
        zephyrCost.text = zephyrPrefab.GetComponent<ZephyrCost>().zephyrCost.ToString();
        zephyrBuildCount = 0;
        zephyrCountText.text = "";
        galactisCost.text = galactisPrefab.GetComponent<GalactisCost>().galactisCost.ToString();
        galactisBuildCount = 0;
        galactisCountText.text = "";
        obeliskCost.text = obeliskPrefab.GetComponent<ObeliskCost>().obeliskCost.ToString();
        obeliskBuildCount = 0;
        obeliskCountText.text = "";
        hyperionCost.text = hyperionPrefab.GetComponent<HyperionCost>().hyperionCost.ToString();
        hyperionBuildCount = 0;
        hyperionCountText.text = "";
        redOlympusCost.text = redOlympusPrefab.GetComponent<RedOlympusCost>().redOlympusCost.ToString();
        redOlympusArtifactCost.text = redOlympusPrefab.GetComponent<RedOlympusCost>().redOlympusArtifactCost.ToString();
        redOlympusBuildCount = 0;
        redOlympusCountText.text = "";
        etherealBladeCost.text = etherealBladePrefab.GetComponent<EtherealBladeCost>().etherealBladeCost.ToString();
        etherealBladeArtifactCost.text = etherealBladePrefab.GetComponent<EtherealBladeCost>().etherealBladeArtifactCost.ToString();
        etherealBladeBuildCount = 0;
        etherealBladeCountText.text = "";
        skyOrchidCost.text = skyOrchidPrefab.GetComponent<SkyOrchidCost>().skyOrchidCost.ToString();
        skyOrchidArtifactCost.text = skyOrchidPrefab.GetComponent<SkyOrchidCost>().skyOrchidArtifactCost.ToString();
        skyOrchidBuildCount = 0;
        skyOrchidCountText.text = "";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.GetComponent<Health>().health > 0 || TimeManager.isPaused)
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

        if (BuildToggle.isBuilding == false || gameObject.GetComponent<Health>().health < 0)
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

    public void BuildDragonhead()
    {
        cost = dragonheadPrefab.GetComponent<DragonheadCost>().dragonheadCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            dragonheadBuildCount ++;
            dragonheadCountText.text = dragonheadBuildCount.ToString();
            buildQueue.Add("Dragonhead");
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

    IEnumerator SpawnDragonhead()
    {
        notBuildingUnit = false;
        Instantiate(dragonheadSpawnEffect, spaceDockSpawnOrigin.position, spaceDockSpawnOrigin.rotation);
        yield return new WaitForSeconds(dragonheadPrefab.GetComponent<DragonheadCost>().dragonheadProductionTime);
        notBuildingUnit = true;
        dragonheadBuildCount --;
        if (dragonheadBuildCount == 0)
        {
            dragonheadCountText.text = "";
        }
        else
        {
            dragonheadCountText.text = dragonheadBuildCount.ToString();
        }
        Instantiate(dragonheadPrefab, spaceDockSpawnOrigin.position, spaceDockSpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildPhoenix()
    {
        cost = phoenixPrefab.GetComponent<PhoenixCost>().phoenixCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            phoenixBuildCount ++;
            phoenixCountText.text = phoenixBuildCount.ToString();
            buildQueue.Add("Phoenix");
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

    IEnumerator SpawnPhoenix()
    {
        notBuildingUnit = false;
        Instantiate(phoenixSpawnEffect, spaceDockSpawnOrigin.position, spaceDockSpawnOrigin.rotation);
        yield return new WaitForSeconds(phoenixPrefab.GetComponent<PhoenixCost>().phoenixProductionTime);
        notBuildingUnit = true;
        phoenixBuildCount --;
        if (phoenixBuildCount == 0)
        {
            phoenixCountText.text = "";
        }
        else
        {
            phoenixCountText.text = phoenixBuildCount.ToString();
        }
        Instantiate(phoenixPrefab, spaceDockSpawnOrigin.position, spaceDockSpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildZephyr()
    {
        cost = zephyrPrefab.GetComponent<ZephyrCost>().zephyrCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            zephyrBuildCount ++;
            zephyrCountText.text = zephyrBuildCount.ToString();
            buildQueue.Add("Zephyr");
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

    IEnumerator SpawnZephyr()
    {
        notBuildingUnit = false;
        Instantiate(zephyrSpawnEffect, spaceDockSpawnOrigin.position, spaceDockSpawnOrigin.rotation);
        yield return new WaitForSeconds(zephyrPrefab.GetComponent<ZephyrCost>().zephyrProductionTime);
        notBuildingUnit = true;
        zephyrBuildCount --;
        if (zephyrBuildCount == 0)
        {
            zephyrCountText.text = "";
        }
        else
        {
            zephyrCountText.text = zephyrBuildCount.ToString();
        }
        Instantiate(zephyrPrefab, spaceDockSpawnOrigin.position, spaceDockSpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildGalactis()
    {
        cost = galactisPrefab.GetComponent<GalactisCost>().galactisCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            galactisBuildCount ++;
            galactisCountText.text = galactisBuildCount.ToString();
            buildQueue.Add("Galactis");
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

    IEnumerator SpawnGalactis()
    {
        notBuildingUnit = false;
        Instantiate(galactisSpawnEffect, spaceDockSpawnOrigin.position, spaceDockSpawnOrigin.rotation);
        yield return new WaitForSeconds(galactisPrefab.GetComponent<GalactisCost>().galactisProductionTime);
        notBuildingUnit = true;
        galactisBuildCount --;
        if (galactisBuildCount == 0)
        {
            galactisCountText.text = "";
        }
        else
        {
            galactisCountText.text = galactisBuildCount.ToString();
        }
        Instantiate(galactisPrefab, spaceDockSpawnOrigin.position, spaceDockSpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildObelisk()
    {
        cost = obeliskPrefab.GetComponent<ObeliskCost>().obeliskCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            obeliskBuildCount ++;
            obeliskCountText.text = obeliskBuildCount.ToString();
            buildQueue.Add("Obelisk");
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

    IEnumerator SpawnObelisk()
    {
        notBuildingUnit = false;
        Instantiate(obeliskSpawnEffect, spaceDockSpawnOriginHigher.position, spaceDockSpawnOriginHigher.rotation);
        yield return new WaitForSeconds(obeliskPrefab.GetComponent<ObeliskCost>().obeliskProductionTime);
        notBuildingUnit = true;
        obeliskBuildCount --;
        if (obeliskBuildCount == 0)
        {
            obeliskCountText.text = "";
        }
        else
        {
            obeliskCountText.text = obeliskBuildCount.ToString();
        }
        Instantiate(obeliskPrefab, spaceDockSpawnOriginHigher.position, spaceDockSpawnOriginHigher.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildHyperion()
    {
        cost = hyperionPrefab.GetComponent<HyperionCost>().hyperionCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            hyperionBuildCount ++;
            hyperionCountText.text = hyperionBuildCount.ToString();
            buildQueue.Add("Hyperion");
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

    IEnumerator SpawnHyperion()
    {
        notBuildingUnit = false;
        Instantiate(hyperionSpawnEffect, spaceDockSpawnOriginHigher.position, spaceDockSpawnOriginHigher.rotation);
        yield return new WaitForSeconds(hyperionPrefab.GetComponent<HyperionCost>().hyperionProductionTime);
        notBuildingUnit = true;
        hyperionBuildCount --;
        if (hyperionBuildCount == 0)
        {
            hyperionCountText.text = "";
        }
        else
        {
            hyperionCountText.text = hyperionBuildCount.ToString();
        }
        Instantiate(hyperionPrefab, spaceDockSpawnOriginHigher.position, spaceDockSpawnOriginHigher.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildRedOlympus()
    {
        cost = redOlympusPrefab.GetComponent<RedOlympusCost>().redOlympusCost;
        artifactCost = redOlympusPrefab.GetComponent<RedOlympusCost>().redOlympusArtifactCost;
        if (cost <= ResourceManager.credits && artifactCost <= ResourceManager.artifactOneCount && !ResourceManager.insufficientWorkers)
        {
            redOlympusBuildCount ++;
            redOlympusCountText.text = redOlympusBuildCount.ToString();
            buildQueue.Add("RedOlympus");
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

    IEnumerator SpawnRedOlympus()
    {
        notBuildingUnit = false;
        Instantiate(redOlympusSpawnEffect, spaceDockSpawnOrigin.position, spaceDockSpawnOrigin.rotation);
        yield return new WaitForSeconds(redOlympusPrefab.GetComponent<RedOlympusCost>().redOlympusProductionTime);
        notBuildingUnit = true;
        redOlympusBuildCount --;
        if (redOlympusBuildCount == 0)
        {
            redOlympusCountText.text = "";
        }
        else
        {
            redOlympusCountText.text = redOlympusBuildCount.ToString();
        }
        Instantiate(redOlympusPrefab, spaceDockSpawnOrigin.position, spaceDockSpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildEtherealBlade()
    {
        cost = etherealBladePrefab.GetComponent<EtherealBladeCost>().etherealBladeCost;
        artifactCost = etherealBladePrefab.GetComponent<EtherealBladeCost>().etherealBladeArtifactCost;
        if (cost <= ResourceManager.credits && artifactCost <= ResourceManager.artifactTwoCount && !ResourceManager.insufficientWorkers)
        {
            etherealBladeBuildCount ++;
            etherealBladeCountText.text = etherealBladeBuildCount.ToString();
            buildQueue.Add("EtherealBlade");
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

    IEnumerator SpawnEtherealBlade()
    {
        notBuildingUnit = false;
        Instantiate(etherealBladeSpawnEffect, spaceDockSpawnOrigin.position, spaceDockSpawnOrigin.rotation);
        yield return new WaitForSeconds(etherealBladePrefab.GetComponent<EtherealBladeCost>().etherealBladeProductionTime);
        notBuildingUnit = true;
        etherealBladeBuildCount --;
        if (etherealBladeBuildCount == 0)
        {
            etherealBladeCountText.text = "";
        }
        else
        {
            etherealBladeCountText.text = etherealBladeBuildCount.ToString();
        }
        Instantiate(etherealBladePrefab, spaceDockSpawnOrigin.position, spaceDockSpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildSkyOrchid()
    {
        cost = skyOrchidPrefab.GetComponent<SkyOrchidCost>().skyOrchidCost;
        artifactCost = skyOrchidPrefab.GetComponent<SkyOrchidCost>().skyOrchidArtifactCost;
        if (cost <= ResourceManager.credits && artifactCost <= ResourceManager.artifactThreeCount && !ResourceManager.insufficientWorkers)
        {
            skyOrchidBuildCount ++;
            skyOrchidCountText.text = skyOrchidBuildCount.ToString();
            buildQueue.Add("SkyOrchid");
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

    IEnumerator SpawnSkyOrchid()
    {
        notBuildingUnit = false;
        Instantiate(skyOrchidSpawnEffect, spaceDockSpawnOriginHigher.position, spaceDockSpawnOriginHigher.rotation);
        yield return new WaitForSeconds(skyOrchidPrefab.GetComponent<SkyOrchidCost>().skyOrchidProductionTime);
        notBuildingUnit = true;
        skyOrchidBuildCount --;
        if (skyOrchidBuildCount == 0)
        {
            skyOrchidCountText.text = "";
        }
        else
        {
            skyOrchidCountText.text = skyOrchidBuildCount.ToString();
        }
        Instantiate(skyOrchidPrefab, spaceDockSpawnOriginHigher.position, spaceDockSpawnOriginHigher.rotation);
        buildQueue.RemoveAt(0);
    }

    void ManageProduction()
    {
        if (buildQueue[0] == "Dragonhead" && notBuildingUnit)
        {
            StartCoroutine(SpawnDragonhead());
        }
        else if (buildQueue[0] == "Phoenix" && notBuildingUnit)
        {
            StartCoroutine(SpawnPhoenix());
        }
        else if (buildQueue[0] == "Zephyr" && notBuildingUnit)
        {
            StartCoroutine(SpawnZephyr());
        }
        else if (buildQueue[0] == "Galactis" && notBuildingUnit)
        {
            StartCoroutine(SpawnGalactis());
        }
        else if (buildQueue[0] == "Obelisk" && notBuildingUnit)
        {
            StartCoroutine(SpawnObelisk());
        }
        else if (buildQueue[0] == "Hyperion" && notBuildingUnit)
        {
            StartCoroutine(SpawnHyperion());
        }
        else if (buildQueue[0] == "RedOlympus" && notBuildingUnit)
        {
            StartCoroutine(SpawnRedOlympus());
        }
        else if (buildQueue[0] == "EtherealBlade" && notBuildingUnit)
        {
            StartCoroutine(SpawnEtherealBlade());
        }
        else if (buildQueue[0] == "SkyOrchid" && notBuildingUnit)
        {
            StartCoroutine(SpawnSkyOrchid());
        }
    }

    public void CloseProductionMenu()
    {
        BuildToggle.currentProductionMenu = null;
    }
}