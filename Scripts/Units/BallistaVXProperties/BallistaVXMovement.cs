using UnityEngine;
using System.Collections.Generic;

public class BallistaVXMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float originalSpeed;
    public float range = 40f;
    public Transform target;
    private float lookSpeed = 10f;
    public bool inRange = false;
    public float targetRange = 100f;
    private List<GameObject> allocatedTargets = new List<GameObject>();
    RaycastHit hit;

    void Start()
    {
        originalSpeed = moveSpeed;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            allocatedTargets.Clear();
        }

        if (SelectedUnits.selectUnits && Input.GetMouseButtonDown(1) && SelectedUnits.selectedUnits.Contains(gameObject))
        {
            Ray ray  = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 50000f, (1 << 9)) || Physics.Raycast(ray, out hit, 50000f, (1 << 20)))
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    allocatedTargets.Add(hit.transform.gameObject);
                }
                else
                {
                    allocatedTargets.Clear();
                    allocatedTargets.Add(hit.transform.gameObject);
                }
            }
        }
    }

    public Transform UpdateTarget()
    {
        if (allocatedTargets.Count == 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            // Update target enemy:
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance && distanceToEnemy < targetRange)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy != null)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
        else
        {
            if (allocatedTargets[0] != null && allocatedTargets[0].tag == "Enemy")
            {
                target = allocatedTargets[0].transform;
            }
            else
            {
                allocatedTargets.RemoveAt(0);
            }
        }
        return target;
    }

    void FixedUpdate()
    {
        if (gameObject.tag == "Vehicle")
        {
            Move();
        }
    }

    void Move()
    {
        if (target != null)
        {
            // Calculate distance between enemy and target:
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToTarget <= range)
            {
                transform.position = transform.position;
                inRange = true;
            }
            else
            {
                inRange = false;
                // Move towards target:
                var modifiedTargetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
                transform.position = Vector3.MoveTowards(transform.position, modifiedTargetPosition, moveSpeed * Time.deltaTime);
                // Rotate towards target:
                if (target.transform.position - transform.position != Vector3.zero)
                {
                    Vector3 dir = target.transform.position - transform.position;
                    Quaternion lookRotation = Quaternion.LookRotation(dir);
                    Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;
                    transform.rotation = Quaternion.Euler(0, rotation.y, 0);
                }
            }
        }
    }
}