using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class letherrdisplay : MonoBehaviour
{
    public int leather;
    private TextMeshProUGUI textMesH;
    // Start is called before the first frame update
    void Start()
    {
        textMesH = GetComponent<TextMeshProUGUI>();
        leather = 1000;
    }
   
    // Update is called once per frame
    void Update()
    {
        textMesH.text = leather.ToString();
    }
}
