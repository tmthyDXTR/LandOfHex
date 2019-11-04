using UnityEngine;

public class SelectTile : MonoBehaviour
{
    private Selectable selectable;
    private Vector3 originalPos;
    void Start()
    {
        selectable = GetComponent<Selectable>();
        originalPos = this.transform.position;
    }

    void Update()
    {
        if (selectable.isSelected)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(originalPos.x, 0.225f, originalPos.z), 2 * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPos, 2 * Time.deltaTime);
        }
    }
}
