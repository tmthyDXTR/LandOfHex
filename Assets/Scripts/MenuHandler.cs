using UnityEngine;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    private RectTransform menu;
    private Selection selection;

    private TextMeshProUGUI selectionText;

    public bool menuIsOpen;

    private Vector3 hiddenPos;
    private Vector3 showPos;
    [SerializeField] float speed = 300f;
    void Start()
    {
        menu = this.transform.Find("PanelMenu").GetComponent<RectTransform>();
        selection = GameObject.Find("Selection").GetComponent<Selection>();
        selectionText = this.transform.Find("PanelMenu").transform.Find("TextSelected").GetComponent<TextMeshProUGUI>();
        hiddenPos = menu.position;
        showPos = new Vector3(hiddenPos.x, 0, hiddenPos.z);
    }

    void Update()
    {
        if (menuIsOpen)
        {
            OpenMenu();
        }
        else
        {
            CloseMenu();
        }

        if (selection.selected.Count > 0)
        {
            selectionText.text = selection.selected[0].gameObject.name;
        }
        else
        {
            selectionText.text = "";
        }
    }

    private void CloseMenu()
    {
        //Debug.Log("Menu closed");
        menu.position = Vector3.MoveTowards(menu.position, hiddenPos, speed * Time.deltaTime);
    }

    private void OpenMenu()
    {
        //Debug.Log("Menu opened");
        menu.position = Vector3.MoveTowards(menu.position, showPos, speed * Time.deltaTime);
    }

    // private IEnumerator WaitForMenuAnim() 
}
