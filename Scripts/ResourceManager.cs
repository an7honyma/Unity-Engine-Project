using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public static float credits;
    public static float refineryOutputRate;
    public static float power;
    public static float powerUsage;
    public static float excessPower;
    public static int population;
    public static int workers;
    public static int surplusPopulation;
    public static int knowledge;
    public static int researchOutputRate;
    public static int commerceCentreCount = 0;
    public static float commerceCentreMultiplier = 1.5f;
    public static int multipliedPopulation;
    public static bool insufficientPower = false;
    public static bool insufficientWorkers = false;
    public static int artifactOneCount;
    public static int artifactTwoCount;
    public static int artifactThreeCount;
    public static int killCount;

    public PowerBar powerBar;
    public PopulationBar populationBar;
    public TextMeshProUGUI excessPowerValue;
    public TextMeshProUGUI excessPopulationValue;
    public TextMeshProUGUI creditsValue;
    public TextMeshProUGUI knowledgeValue;
    public TextMeshProUGUI researchMenuKnowledgeValue;
    public TextMeshProUGUI artifactOneCountText;
    public TextMeshProUGUI artifactTwoCountText;
    public TextMeshProUGUI artifactThreeCountText;
    public TextMeshProUGUI killCountText;

    void Start()
    {
        credits = 5000000f;
        power = 1000f;
        excessPower = power;
        population = 150;
        surplusPopulation = population;
        workers = 0;
        knowledge = 0;
        artifactOneCount = 0;
        artifactTwoCount = 0;
        artifactThreeCount = 0;
        UpdateResources();
        UpdateResourceDisplay();
        UpdateMaterialsDisplay();
        killCount = 0;
        InvokeRepeating("UpdateResourceDisplay", 0f, 0.25f);
        InvokeRepeating("UpdateMaterialsDisplay", 0f, 0.25f);
        InvokeRepeating("UpdateKillCount", 0f, 0.25f);
    }

    void Update()
    {
        creditsValue.text = credits.ToString();
        knowledgeValue.text = knowledge.ToString();
        researchMenuKnowledgeValue.text = "Research: " + knowledge.ToString();

        if (surplusPopulation <= 0)
        {
            insufficientWorkers = true;
        }
        else
        {
            insufficientWorkers = false;
        }

        if (excessPower <= 0)
        {
            insufficientPower = true;
            NotificationManager.lowPower = true;
        }
        else
        {
            NotificationManager.lowPower = false;
            insufficientPower = false;
        }
    }

    public static void UpdateResources()
    {
        if (commerceCentreCount == 0)
        {
            multipliedPopulation = population;
        }
        else if (commerceCentreCount > 0)
        {
            multipliedPopulation = (int)(population * commerceCentreCount * commerceCentreMultiplier);
        }
        excessPower = power - powerUsage;
        surplusPopulation = multipliedPopulation - workers;
    }

    void UpdateResourceDisplay()
    {
        powerBar.SetTotalPower(power);
        populationBar.SetTotalPopulation(multipliedPopulation);
        powerBar.SetExcessPower(excessPower);
        populationBar.SetExcessPopulation(surplusPopulation);
        excessPowerValue.text = excessPower.ToString();
        excessPopulationValue.text = surplusPopulation.ToString();
    }

    void UpdateMaterialsDisplay()
    {
        artifactOneCountText.text = artifactOneCount.ToString();
        artifactTwoCountText.text = artifactTwoCount.ToString();
        artifactThreeCountText.text = artifactThreeCount.ToString();
    }

    void UpdateKillCount()
    {
        killCountText.text = killCount.ToString();
    }
}
