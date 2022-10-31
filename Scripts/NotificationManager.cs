using UnityEngine;
using System.Collections;

public class NotificationManager : MonoBehaviour
{
    public static bool insufficientCredits = false;
    public static bool cannotBuildHere = false;
    public static bool insufficientPower = false;
    public static bool lowPower = false;
    public static bool insufficientWorkers = false;
    public static bool insufficientArtifacts = false;
    public GameObject insufficientCreditsNotification;
    public GameObject insufficientPowerNotification;
    public GameObject insufficientWorkersNotification;
    public GameObject insufficientArtifactsNotification;
    public GameObject cannotBuildHereNotification;

    void Update()
    {
        if (insufficientCredits)
        {
            StartCoroutine(DisplayInsufficientCreditsNotification());
        }
        if (cannotBuildHere)
        {
            StartCoroutine(DisplayCannotBuildHereNotification());
        }
        if (insufficientPower)
        {
            StartCoroutine(DisplayInsufficientPowerNotification());
        }
        if (insufficientWorkers)
        {
            StartCoroutine(DisplayInsufficientWorkersNotification());
        }
        if (insufficientArtifacts)
        {
            StartCoroutine(DisplayInsufficientArtifactsNotification());
        }
        if (lowPower)
        {
            insufficientPowerNotification.SetActive(true);
        }
        else if (!lowPower && !insufficientPower)
        {
            insufficientPowerNotification.SetActive(false);
        }
    }

    IEnumerator DisplayInsufficientCreditsNotification()
    {
        insufficientCreditsNotification.SetActive(true);
        yield return new WaitForSeconds(3f);
        insufficientCreditsNotification.SetActive(false);
        insufficientCredits = false;
    }

    IEnumerator DisplayInsufficientPowerNotification()
    {
        insufficientPowerNotification.SetActive(true);
        yield return new WaitForSeconds(3f);
        if (!lowPower)
        {
            insufficientPowerNotification.SetActive(false);
            insufficientPower = false;
        }
    }

    IEnumerator DisplayCannotBuildHereNotification()
    {
        cannotBuildHereNotification.SetActive(true);
        yield return new WaitForSeconds(3f);
        cannotBuildHereNotification.SetActive(false);
        cannotBuildHere = false;
    }

    IEnumerator DisplayInsufficientWorkersNotification()
    {
        insufficientWorkersNotification.SetActive(true);
        yield return new WaitForSeconds(3f);
        insufficientWorkersNotification.SetActive(false);
        insufficientWorkers = false;
    }

    IEnumerator DisplayInsufficientArtifactsNotification()
    {
        insufficientArtifactsNotification.SetActive(true);
        yield return new WaitForSeconds(3f);
        insufficientArtifactsNotification.SetActive(false);
        insufficientArtifacts = false;
    }
}
