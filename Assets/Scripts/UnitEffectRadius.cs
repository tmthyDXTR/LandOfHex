using UnityEngine;

public class UnitEffectRadius : MonoBehaviour
{
    private Selection selection;
    private UnitInfo unit;


    void Start()
    {
        selection = GameObject.Find("Selection").GetComponent<Selection>();
        unit = this.transform.parent.GetComponent<UnitInfo>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8) // Tile Layer
        {
            if (!unit.moveArea.Contains(other.gameObject) && other.gameObject != unit.tilePos)
            {
                unit.moveArea.Add(other.gameObject);
                //if (other.gameObject.GetComponent<Selectable>() != null)
                //{
                //    other.gameObject.GetComponent<Selectable>().isSelected = true;
                //}
                Debug.Log("Added " + other.gameObject.name + " to Selection");
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8) // Tile Layer
        {
            if (!unit.moveArea.Contains(other.gameObject) && other.gameObject != unit.tilePos)
            {
                unit.moveArea.Add(other.gameObject);
                //if (other.gameObject.GetComponent<Selectable>() != null)
                //{
                //    other.gameObject.GetComponent<Selectable>().isSelected = true;
                //}
                Debug.Log("Added " + other.gameObject.name + " to Selection");
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8) // Tile Layer
        {
            if (unit.moveArea.Contains(other.gameObject))
            {
                unit.moveArea.Remove(other.gameObject);
                //if (other.gameObject.GetComponent<Selectable>() != null)
                //{
                //    other.gameObject.GetComponent<Selectable>().isSelected = false;
                //}
                Debug.Log("Removed " + other.gameObject.name + " from Selection");
            }
        }
    }
}