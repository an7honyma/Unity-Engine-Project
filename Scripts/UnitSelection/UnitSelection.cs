using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    SelectedUnits selectedUnits;
    RaycastHit hit;

    bool dragSelect;

    MeshCollider selectionBox;
    Mesh selectionMesh;

    Vector3 p1;
    Vector3 p2;

    // Corners of 2D selection box:
    Vector2[] corners;

    // Vertices of mesh collider:
    Vector3[] verts;
    Vector3[] vecs;

    void Start()
    {
        selectedUnits = GetComponent<SelectedUnits>();
        dragSelect = false;
    }

    void Update()
    {
        // If in unit selection mode and not in build mode:
        if (SelectedUnits.selectUnits)
        {
            // When left mouse is clicked:
            if (Input.GetMouseButtonDown(0))
            {
                p1 = Input.mousePosition;
            }

            // When left mouse is held:
            if (Input.GetMouseButton(0))
            {
                if((p1 - Input.mousePosition).magnitude > 40)
                {
                    dragSelect = true;
                }
            }

            // When left mouse is lifted:
            if (Input.GetMouseButtonUp(0))
            {
                // Single select:
                if(dragSelect == false)
                {
                    Ray ray = Camera.main.ScreenPointToRay(p1);

                    if(Physics.Raycast(ray, out hit, 50000f, (1 << 8)))
                    {
                        // Inclusive select:
                        if (Input.GetKey(KeyCode.LeftControl))
                        {
                            selectedUnits.addSelected(hit.transform.gameObject);
                        }
                        // Exclusive select:
                        else
                        {
                            selectedUnits.deselectAll();
                            selectedUnits.addSelected(hit.transform.gameObject);
                        }
                    }
                    // Nothing selected:
                    else
                    {
                        if (Input.GetKey(KeyCode.LeftControl))
                        {
                            // Do nothing else for now.
                        }
                        else
                        {
                            selectedUnits.deselectAll();
                        }
                    }
                }
                // Marquee select:
                else
                {
                    verts = new Vector3[4];
                    vecs = new Vector3[4];
                    int i = 0;
                    p2 = Input.mousePosition;
                    corners = getBoundingBox(p1, p2);

                    foreach (Vector2 corner in corners)
                    {
                        Ray ray = Camera.main.ScreenPointToRay(corner);

                        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 31)))
                        {
                            verts[i] = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                            vecs[i] = ray.origin - hit.point;
                            Debug.DrawLine(Camera.main.ScreenToWorldPoint(corner), hit.point, Color.red, 1.0f);
                        }
                        i++;
                    }

                    // Generate mesh:
                    selectionMesh = generateSelectionMesh(verts,vecs);
                    selectionBox = gameObject.AddComponent<MeshCollider>();
                    selectionBox.sharedMesh = selectionMesh;
                    selectionBox.convex = true;
                    selectionBox.isTrigger = true;

                    if (!Input.GetKey(KeyCode.LeftControl))
                    {
                        selectedUnits.deselectAll();
                    }

                Destroy(selectionBox, 0.02f);

                }

                dragSelect = false;
            }
        }
        // No longer in not selection mode:
        else
        {
            selectedUnits.deselectAll();
        }
    }

    private void OnGUI()
    {
        if(dragSelect == true)
        {
            var rect = UnitSelectionUtils.GetScreenRect(p1, Input.mousePosition);
            UnitSelectionUtils.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            UnitSelectionUtils.DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }

    // Create bounding box (4 corners in order) from the start and end mouse positions:
    Vector2[] getBoundingBox(Vector2 p1,Vector2 p2)
    {
        // Min and Max to get 2 corners of rectangle regardless of drag direction:
        var bottomLeft = Vector3.Min(p1, p2);
        var topRight = Vector3.Max(p1, p2);

        // 0 = top left; 1 = top right; 2 = bottom left; 3 = bottom right:
        Vector2[] corners =
        {
            new Vector2(bottomLeft.x, topRight.y),
            new Vector2(topRight.x, topRight.y),
            new Vector2(bottomLeft.x, bottomLeft.y),
            new Vector2(topRight.x, bottomLeft.y)
        };
        return corners;

    }

    // Generte mesh from 4 blowest points:
    Mesh generateSelectionMesh(Vector3[] corners, Vector3[] vecs)
    {
        Vector3[] verts = new Vector3[8];
        // Map of tris for cube:
        int[] tris = { 0, 1, 2, 2, 1, 3, 4, 6, 0, 0, 6, 2, 6, 7, 2, 2, 7, 3, 7, 5, 3, 3, 5, 1, 5, 0, 1, 1, 4, 0, 4, 5, 6, 6, 5, 7 };

        for(int i = 0; i < 4; i++)
        {
            verts[i] = corners[i];
        }

        for(int j = 4; j < 8; j++)
        {
            verts[j] = corners[j - 4] + vecs[j - 4];
        }

        Mesh selectionMesh = new Mesh();
        selectionMesh.vertices = verts;
        selectionMesh.triangles = tris;

        return selectionMesh;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            selectedUnits.addSelected(other.gameObject);
        }
    }

}