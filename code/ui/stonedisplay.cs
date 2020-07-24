using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class stonedisplay : MonoBehaviour
{

    public int stone;
    private TextMeshProUGUI textMesH;
    int t;

    // Start is called before the first frame update
    void Start()
    {
        textMesH = GetComponent<TextMeshProUGUI>();
        stone = PlayerPrefs.GetInt("stone");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            stone = 0;
        }
        textMesH.text = stone.ToString();
 
        t++;
        if (t > 1000)
        {
            PlayerPrefs.SetInt("stone", stone);
            t = 0;
        }
    }



}

