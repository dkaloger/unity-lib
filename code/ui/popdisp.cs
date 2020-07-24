using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class popdisp : MonoBehaviour
{
    int t;
    public int pop;
   public int maxpop = 10;
    public TextMeshProUGUI textMesH;
    public TextMeshProUGUI textMesH1;
    public GameObject spop;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("pop") == 0)
        {
            PlayerPrefs.SetInt("pop", 2);
     
        }
        pop = PlayerPrefs.GetInt("pop");
        maxpop = PlayerPrefs.GetInt("maxpop");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            pop = 2;
            maxpop = 10;
        }
        if (pop > 500)
        {
            pop = 2;
            PlayerPrefs.SetInt("pop", pop);
        }
        textMesH.text = pop.ToString();
        textMesH1.text = maxpop.ToString();
        t++;
        if (t > 100)
        {
            PlayerPrefs.SetInt("pop", pop);
            PlayerPrefs.SetInt("maxpop", maxpop);
            t = 0;
        }
    }
    void OnMouseOver()
    {
        spop.SetActive(true);
    }
    void OnMouseExit()
    {
        spop.SetActive(false);
    }
}
