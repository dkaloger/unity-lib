using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class wooddisplay : MonoBehaviour
{
    int t;
    public int wood;
    private TextMeshProUGUI textMesH;

    // Start is called before the first frame update
    void Start()
    {
        textMesH = GetComponent<TextMeshProUGUI>();
        wood = PlayerPrefs.GetInt("wood"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            wood = 0;
        }
        textMesH.text = wood.ToString();
        t++;
        if (t > 100)
        {
            PlayerPrefs.SetInt("wood", wood);
            t = 0;
        }
    }
}
