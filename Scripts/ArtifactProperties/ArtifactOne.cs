using UnityEngine;
using System.Collections;
using UnityEngine.VFX;

public class ArtifactOne : MonoBehaviour
{

    public GameObject artifactFlash;

    void Start()
    {
        Destroy(gameObject, 60f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(artifactFlash, transform.position, transform.rotation);
        Destroy(gameObject);
        ResourceManager.artifactOneCount ++;
        ResourceManager.UpdateResources();
    }
}