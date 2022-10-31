using UnityEngine;
using UnityEngine.VFX;
using System.Collections;


public class ArtifactFlash : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(PhaseOut());
    }

    IEnumerator PhaseOut()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<VisualEffect>().Stop();
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
