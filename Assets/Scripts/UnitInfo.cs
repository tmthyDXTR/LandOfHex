using System.Collections.Generic;
using UnityEngine;

public class UnitInfo : MonoBehaviour
{
    private Selection selection;
    public GameObject tilePos;
    public GameObject radius;

    public List<GameObject> moveArea = new List<GameObject>();
    void Start()
    {
        selection = GameObject.Find("Selection").GetComponent<Selection>();
        radius = this.transform.Find("Radius").gameObject;
    }


    public void ShowEffectRadius(bool value)
    {
        radius.SetActive(value);
        if (value == false)
        {
            selection.DeselectAll();
        }
        Debug.Log("Show effect radius of " + this.gameObject.name + " : " + value.ToString());
    }

}
