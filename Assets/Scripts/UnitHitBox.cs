using UnityEngine;

public class UnitHitBox : MonoBehaviour
{
    private UnitInfo unit;
    void Start()
    {
        unit = this.transform.parent.GetComponent<UnitInfo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8) // Tile Layer
        {
            unit.tilePos = other.gameObject;
            other.gameObject.GetComponent<TileInfo>().hasUnit = true;
            other.gameObject.GetComponent<TileInfo>().localUnit = this.transform.parent.gameObject;
            Debug.Log(unit.gameObject.name + " entered " + other.gameObject.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8) // Tile Layer
        {
            other.gameObject.GetComponent<TileInfo>().hasUnit = false;
            other.gameObject.GetComponent<TileInfo>().localUnit = null;
            Debug.Log(unit.gameObject.name + " exited " + other.gameObject.name);
        }
    }
}
