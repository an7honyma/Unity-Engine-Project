using UnityEngine;
using System.Collections;
using UnityEngine.VFX;

public class SpawnEffect : MonoBehaviour
{
    public float productionTime;

    public IEnumerator StopEffect()
    {
        yield return new WaitForSeconds(productionTime);
        GetComponent<VisualEffect>().Stop();
    }
}
