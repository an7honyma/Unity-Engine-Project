using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class AssemblyYardProduction : MonoBehaviour
{
    public Transform assemblyYardSpawnOrigin;
    public GameObject herculesPrefab;
    public GameObject herculesSpawnEffect;
    public GameObject hydraPrefab;
    public GameObject hydraSpawnEffect;
    public GameObject rangerPrefab;
    public GameObject rangerSpawnEffect;
    public GameObject spectrePrefab;
    public GameObject spectreSpawnEffect;
    public GameObject chargerPrefab;
    public GameObject chargerSpawnEffect;
    public GameObject vengeancePrefab;
    public GameObject vengeanceSpawnEffect;
    public GameObject decimatorPrefab;
    public GameObject decimatorSpawnEffect;
    public GameObject moonWraithPrefab;
    public GameObject moonWraithSpawnEffect;
    public GameObject darkNebulaPrefab;
    public GameObject darkNebulaSpawnEffect;

    public GameObject buildOptionMenu;
    public GameObject productionMenu;
    public GameObject buildingIndicator;

    public TextMeshProUGUI herculesCost;
    public int herculesBuildCount;
    public TextMeshProUGUI herculesCountText;
    public TextMeshProUGUI hydraCost;
    public int hydraBuildCount;
    public TextMeshProUGUI hydraCountText;
    public TextMeshProUGUI rangerCost;
    public int rangerBuildCount;
    public TextMeshProUGUI rangerCountText;
    public TextMeshProUGUI spectreCost;
    public int spectreBuildCount;
    public TextMeshProUGUI spectreCountText;
    public TextMeshProUGUI chargerCost;
    public int chargerBuildCount;
    public TextMeshProUGUI chargerCountText;
    public TextMeshProUGUI vengeanceCost;
    public int vengeanceBuildCount;
    public TextMeshProUGUI vengeanceCountText;
    public TextMeshProUGUI decimatorCost;
    public TextMeshProUGUI decimatorArtifactCost;
    public int decimatorBuildCount;
    public TextMeshProUGUI decimatorCountText;
    public TextMeshProUGUI moonWraithCost;
    public TextMeshProUGUI moonWraithArtifactCost;
    public int moonWraithBuildCount;
    public TextMeshProUGUI moonWraithCountText;
    public TextMeshProUGUI darkNebulaCost;
    public TextMeshProUGUI darkNebulaArtifactCost;
    public int darkNebulaBuildCount;
    public TextMeshProUGUI darkNebulaCountText;

    private float cost;
    private int artifactCost;
    private bool notBuildingUnit = true;
    RaycastHit hit;
    private List<string> buildQueue = new List<string>();

    void Start()
    {
        herculesCost.text = herculesPrefab.GetComponent<HerculesCost>().herculesCost.ToString();
        herculesBuildCount = 0;
        herculesCountText.text = "";
        hydraCost.text = hydraPrefab.GetComponent<HydraCost>().hydraCost.ToString();
        hydraBuildCount = 0;
        hydraCountText.text = "";
        rangerCost.text = rangerPrefab.GetComponent<RangerCost>().rangerCost.ToString();
        rangerBuildCount = 0;
        rangerCountText.text = "";
        spectreCost.text = spectrePrefab.GetComponent<SpectreCost>().spectreCost.ToString();
        spectreBuildCount = 0;
        spectreCountText.text = "";
        chargerCost.text = chargerPrefab.GetComponent<ChargerCost>().chargerCost.ToString();
        chargerBuildCount = 0;
        chargerCountText.text = "";
        vengeanceCost.text = vengeancePrefab.GetComponent<VengeanceCost>().vengeanceCost.ToString();
        vengeanceBuildCount = 0;
        vengeanceCountText.text = "";
        decimatorCost.text = decimatorPrefab.GetComponent<DecimatorCost>().decimatorCost.ToString();
        decimatorArtifactCost.text = decimatorPrefab.GetComponent<DecimatorCost>().decimatorArtifactCost.ToString();
        decimatorBuildCount = 0;
        decimatorCountText.text = "";
        moonWraithCost.text = moonWraithPrefab.GetComponent<MoonWraithCost>().moonWraithCost.ToString();
        moonWraithArtifactCost.text = moonWraithPrefab.GetComponent<MoonWraithCost>().moonWraithArtifactCost.ToString();
        moonWraithBuildCount = 0;
        moonWraithCountText.text = "";
        darkNebulaCost.text = darkNebulaPrefab.GetComponent<DarkNebulaCost>().darkNebulaCost.ToString();
        darkNebulaArtifactCost.text = darkNebulaPrefab.GetComponent<DarkNebulaCost>().darkNebulaArtifactCost.ToString();
        darkNebulaBuildCount = 0;
        darkNebulaCountText.text = "";
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

    public void BuildHercules()
    {
        cost = herculesPrefab.GetComponent<HerculesCost>().herculesCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            herculesBuildCount ++;
            herculesCountText.text = herculesBuildCount.ToString();
            buildQueue.Add("Hercules");
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

    IEnumerator SpawnHercules()
    {
        notBuildingUnit = false;
        Instantiate(herculesSpawnEffect, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        yield return new WaitForSeconds(herculesPrefab.GetComponent<HerculesCost>().herculesProductionTime);
        notBuildingUnit = true;
        herculesBuildCount --;
        if (herculesBuildCount == 0)
        {
            herculesCountText.text = "";
        }
        else
        {
            herculesCountText.text = herculesBuildCount.ToString();
        }
        Instantiate(herculesPrefab, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildHydra()
    {
        cost = hydraPrefab.GetComponent<HydraCost>().hydraCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            hydraBuildCount ++;
            hydraCountText.text = hydraBuildCount.ToString();
            buildQueue.Add("Hydra");
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

    IEnumerator SpawnHydra()
    {
        notBuildingUnit = false;
        Instantiate(hydraSpawnEffect, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        yield return new WaitForSeconds(hydraPrefab.GetComponent<HydraCost>().hydraProductionTime);
        notBuildingUnit = true;
        hydraBuildCount --;
        if (hydraBuildCount == 0)
        {
            hydraCountText.text = "";
        }
        else
        {
            hydraCountText.text = hydraBuildCount.ToString();
        }
        Instantiate(hydraPrefab, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildRanger()
    {
        cost = rangerPrefab.GetComponent<RangerCost>().rangerCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            rangerBuildCount ++;
            rangerCountText.text = rangerBuildCount.ToString();
            buildQueue.Add("Ranger");
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

    IEnumerator SpawnRanger()
    {
        notBuildingUnit = false;
        Instantiate(rangerSpawnEffect, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        yield return new WaitForSeconds(rangerPrefab.GetComponent<RangerCost>().rangerProductionTime);
        notBuildingUnit = true;
        rangerBuildCount --;
        if (rangerBuildCount == 0)
        {
            rangerCountText.text = "";
        }
        else
        {
            rangerCountText.text = rangerBuildCount.ToString();
        }
        Instantiate(rangerPrefab, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildSpectre()
    {
        cost = spectrePrefab.GetComponent<SpectreCost>().spectreCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            spectreBuildCount ++;
            spectreCountText.text = spectreBuildCount.ToString();
            buildQueue.Add("Spectre");
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

    IEnumerator SpawnSpectre()
    {
        notBuildingUnit = false;
        Instantiate(spectreSpawnEffect, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        yield return new WaitForSeconds(spectrePrefab.GetComponent<SpectreCost>().spectreProductionTime);
        notBuildingUnit = true;
        spectreBuildCount --;
        if (spectreBuildCount == 0)
        {
            spectreCountText.text = "";
        }
        else
        {
            spectreCountText.text = spectreBuildCount.ToString();
        }
        Instantiate(spectrePrefab, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildCharger()
    {
        cost = chargerPrefab.GetComponent<ChargerCost>().chargerCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            chargerBuildCount ++;
            chargerCountText.text = chargerBuildCount.ToString();
            buildQueue.Add("Charger");
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

    IEnumerator SpawnCharger()
    {
        notBuildingUnit = false;
        Instantiate(chargerSpawnEffect, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        yield return new WaitForSeconds(chargerPrefab.GetComponent<ChargerCost>().chargerProductionTime);
        notBuildingUnit = true;
        chargerBuildCount --;
        if (chargerBuildCount == 0)
        {
            chargerCountText.text = "";
        }
        else
        {
            chargerCountText.text = chargerBuildCount.ToString();
        }
        Instantiate(chargerPrefab, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildVengeance()
    {
        cost = vengeancePrefab.GetComponent<VengeanceCost>().vengeanceCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            vengeanceBuildCount ++;
            vengeanceCountText.text = vengeanceBuildCount.ToString();
            buildQueue.Add("Vengeance");
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

    IEnumerator SpawnVengeance()
    {
        notBuildingUnit = false;
        Instantiate(vengeanceSpawnEffect, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        yield return new WaitForSeconds(vengeancePrefab.GetComponent<VengeanceCost>().vengeanceProductionTime);
        notBuildingUnit = true;
        vengeanceBuildCount --;
        if (vengeanceBuildCount == 0)
        {
            vengeanceCountText.text = "";
        }
        else
        {
            vengeanceCountText.text = vengeanceBuildCount.ToString();
        }
        Instantiate(vengeancePrefab, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildDecimator()
    {
        cost = decimatorPrefab.GetComponent<DecimatorCost>().decimatorCost;
        artifactCost = decimatorPrefab.GetComponent<DecimatorCost>().decimatorArtifactCost;
        if (cost <= ResourceManager.credits && artifactCost <= ResourceManager.artifactOneCount && !ResourceManager.insufficientWorkers)
        {
            decimatorBuildCount ++;
            decimatorCountText.text = decimatorBuildCount.ToString();
            buildQueue.Add("Decimator");
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

    IEnumerator SpawnDecimator()
    {
        notBuildingUnit = false;
        Instantiate(decimatorSpawnEffect, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        yield return new WaitForSeconds(decimatorPrefab.GetComponent<DecimatorCost>().decimatorProductionTime);
        notBuildingUnit = true;
        decimatorBuildCount --;
        if (decimatorBuildCount == 0)
        {
            decimatorCountText.text = "";
        }
        else
        {
            decimatorCountText.text = decimatorBuildCount.ToString();
        }
        Instantiate(decimatorPrefab, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildMoonWraith()
    {
        cost = moonWraithPrefab.GetComponent<MoonWraithCost>().moonWraithCost;
        artifactCost = moonWraithPrefab.GetComponent<MoonWraithCost>().moonWraithArtifactCost;
        if (cost <= ResourceManager.credits && artifactCost <= ResourceManager.artifactTwoCount && !ResourceManager.insufficientWorkers)
        {
            moonWraithBuildCount ++;
            moonWraithCountText.text = moonWraithBuildCount.ToString();
            buildQueue.Add("MoonWraith");
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

    IEnumerator SpawnMoonWraith()
    {
        notBuildingUnit = false;
        Instantiate(moonWraithSpawnEffect, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        yield return new WaitForSeconds(moonWraithPrefab.GetComponent<MoonWraithCost>().moonWraithProductionTime);
        notBuildingUnit = true;
        moonWraithBuildCount --;
        if (moonWraithBuildCount == 0)
        {
            moonWraithCountText.text = "";
        }
        else
        {
            moonWraithCountText.text = moonWraithBuildCount.ToString();
        }
        Instantiate(moonWraithPrefab, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildDarkNebula()
    {
        cost = darkNebulaPrefab.GetComponent<DarkNebulaCost>().darkNebulaCost;
        artifactCost = darkNebulaPrefab.GetComponent<DarkNebulaCost>().darkNebulaArtifactCost;
        if (cost <= ResourceManager.credits && artifactCost <= ResourceManager.artifactThreeCount && !ResourceManager.insufficientWorkers)
        {
            darkNebulaBuildCount ++;
            darkNebulaCountText.text = darkNebulaBuildCount.ToString();
            buildQueue.Add("DarkNebula");
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

    IEnumerator SpawnDarkNebula()
    {
        notBuildingUnit = false;
        Instantiate(darkNebulaSpawnEffect, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        yield return new WaitForSeconds(darkNebulaPrefab.GetComponent<DarkNebulaCost>().darkNebulaProductionTime);
        notBuildingUnit = true;
        darkNebulaBuildCount --;
        if (darkNebulaBuildCount == 0)
        {
            darkNebulaCountText.text = "";
        }
        else
        {
            darkNebulaCountText.text = darkNebulaBuildCount.ToString();
        }
        Instantiate(darkNebulaPrefab, assemblyYardSpawnOrigin.position, assemblyYardSpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    void ManageProduction()
    {
        if (buildQueue[0] == "Hercules" && notBuildingUnit)
        {
            StartCoroutine(SpawnHercules());
        }
        else if (buildQueue[0] == "Hydra" && notBuildingUnit)
        {
            StartCoroutine(SpawnHydra());
        }
        else if (buildQueue[0] == "Ranger" && notBuildingUnit)
        {
            StartCoroutine(SpawnRanger());
        }
        else if (buildQueue[0] == "Spectre" && notBuildingUnit)
        {
            StartCoroutine(SpawnSpectre());
        }
        else if (buildQueue[0] == "Charger" && notBuildingUnit)
        {
            StartCoroutine(SpawnCharger());
        }
        else if (buildQueue[0] == "Vengeance" && notBuildingUnit)
        {
            StartCoroutine(SpawnVengeance());
        }
        else if (buildQueue[0] == "Decimator" && notBuildingUnit)
        {
            StartCoroutine(SpawnDecimator());
        }
        else if (buildQueue[0] == "MoonWraith" && notBuildingUnit)
        {
            StartCoroutine(SpawnMoonWraith());
        }
        else if (buildQueue[0] == "DarkNebula" && notBuildingUnit)
        {
            StartCoroutine(SpawnDarkNebula());
        }
    }

    public void CloseProductionMenu()
    {
        BuildToggle.currentProductionMenu = null;
    }
}