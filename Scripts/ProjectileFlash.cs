using UnityEngine;
using UnityEngine.VFX;
using System.Collections;


public class ProjectileFlash : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(PhaseOut());
    }

    IEnumerator PhaseOut()
    {
        yield return new WaitForSeconds(0.25f);
        GetComponent<VisualEffect>().Stop();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
