using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public bool isActive = true;

    private MenuHandler menuHandler;
    public List<GameObject> selected = new List<GameObject>();
    public bool menuIsOpen;

    [SerializeField] private float touchTimer = 0.0001f;
    void Start()
    {
        menuHandler = GameObject.Find("Canvas").GetComponent<MenuHandler>();
    }

    private void Update()
    {
        if (selected.Count > 1 && !menuIsOpen)
        {
            isActive = false;
            menuIsOpen = true;
            menuHandler.menuIsOpen = true;
        }
        if (selected.Count <= 1 && menuIsOpen)
        {
            isActive = true;
            menuIsOpen = false;
            menuHandler.menuIsOpen = false;
        }

        if (Input.GetMouseButton(0))
        {
            touchTimer += Time.deltaTime;
            if (touchTimer >= 0.2f)
            {
                isActive = false;
            }
        }

        if (isActive)
        {
            // Handle screen touches.
            if (Input.GetMouseButtonUp(0))
            {
                touchTimer = 0.0001f;
                // Check if already something selected
                //if (selected.Count != 0)
                //{
                //    DeselectAll();
                //}

                //Touch touch = Input.GetTouch(0);
                //Debug.Log("Mouse is down");

                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                if (hit)
                {
                    GameObject hitObj = hitInfo.transform.gameObject;
                    Debug.Log("Hit " + hitObj.name);
                    if (hitInfo.transform.gameObject.layer == 8) // Tile Layer
                    {
                        //Debug.Log("HexTile clicked");
                        
                        // Select Tile
                        if (hitObj.GetComponent<Selectable>() != null)
                        {
                            Selectable selectable = hitObj.GetComponent<Selectable>();
                            if (selectable.isSelected)
                            {
                                DeselectAll();
                                return;
                            }
                            else
                            {
                                DeselectAll();
                                selected.Add(hitObj);
                                selectable.isSelected = true;

                                if (hitObj.GetComponent<TileInfo>() != null)
                                {
                                    TileInfo tileInfo = hitObj.GetComponent<TileInfo>();
                                    // Show effect radius tiles if unit present on the selected tile
                                    if (tileInfo.hasUnit)
                                    {
                                        if (tileInfo.localUnit.GetComponent<UnitInfo>() != null)
                                        {
                                            if (tileInfo.localUnit.GetComponent<UnitInfo>().moveArea.Count > 0)
                                            {
                                                foreach (GameObject tile in tileInfo.localUnit.GetComponent<UnitInfo>().moveArea)
                                                {
                                                    tile.GetComponent<Selectable>().isSelected = true;
                                                    selected.Add(tile);
                                                }
                                            }
                                        }
                                    }
                                }
                            }                            
                        }
                    }
                }
                else
                {
                    Debug.Log("No hit");
                    DeselectAll();
                }
            }
        }
        if (!isActive)
        {
            if (Input.GetMouseButtonUp(0))
            {
                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                if (hit)
                {
                    GameObject hitObj = hitInfo.transform.gameObject;
                    Debug.Log("Hit " + hitObj.name);
                    if (hitInfo.transform.gameObject.layer == 8) // Tile Layer
                    {
                        if (selected.Contains(hitObj))
                        {
                            Debug.Log("Selcted a effected Tile");
                        }
                        else
                        {
                            Debug.Log("Invalid Tile");
                            DeselectAll();
                        }
                    }
                    
                }
                touchTimer = 0.0001f;
                isActive = true;
            }
        }
    }

    public void DeselectAll()
    {
        foreach (GameObject obj in selected)
        {
            if (obj.GetComponent<Selectable>() != null)
            {
                obj.GetComponent<Selectable>().isSelected = false;
            }
        }
        selected.Clear();
    }
}