using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class fooddipslay : MonoBehaviour
{
    public int food;
    public int unfood;
    private TextMeshProUGUI textMesH;

    public TextMeshProUGUI textMesH1;
    int t;
    public GameObject sfood;
    // Start is called before the first frame update
    void Start()
    {
        textMesH = GetComponent<TextMeshProUGUI>();
  
       
     food =   PlayerPrefs.GetInt("food");
        unfood = PlayerPrefs.GetInt("unfood");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            food = 500;
            unfood = 0;
        }
        textMesH.text = food.ToString();
        textMesH1.text = unfood.ToString();
        t++;
            if (t > 100)
        {
            PlayerPrefs.SetInt("food", food);
            PlayerPrefs.SetInt("unfood", unfood);
        }
    
    }
    void OnMouseOver()
    {
        sfood.SetActive(true);
    }
    void OnMouseExit()
    {
        sfood.SetActive(false);
    }
}