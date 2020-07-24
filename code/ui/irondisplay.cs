using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class irondisplay : MonoBehaviour

{
    int t;
    public int iron;
    public int unrefinediron;
    private TextMeshProUGUI textMesH;
    public TextMeshProUGUI textMesH1;
    public GameObject siron;

    // Start is called before the first frame update
    void Start()
    {
        textMesH = GetComponent<TextMeshProUGUI>();

        iron = PlayerPrefs.GetInt("iron");
        unrefinediron = PlayerPrefs.GetInt("uniron");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            iron = 0;
            unrefinediron = 0;
        }
        textMesH.text = iron.ToString();
        textMesH1.text = unrefinediron.ToString();
          t++;
        if (t > 100)
        {
            PlayerPrefs.SetInt("iron", iron);
            PlayerPrefs.SetInt("uniron", unrefinediron);
            t = 0;
        }
    }
    
    void OnMouseOver()
    {
        siron.SetActive(true);
    }
    void OnMouseExit()
    {
        siron.SetActive(false);
    }

}
