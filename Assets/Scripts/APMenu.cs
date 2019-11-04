using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class APMenu : MonoBehaviour
{
    private TextMeshProUGUI apText;
    void Start()
    {
        apText = this.transform.Find("PanelAP").GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        apText.text = GameState.GState.p1_AP.ToString();
    }
}
