using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;
public class jobsystem : MonoBehaviour
{
    [SerializeField]
    Image wedg1;
    [SerializeField]
    Image wedg2;
    [SerializeField]
    Text d;
   
    public Slider choptrees;

    //for a weird   reason they are inverted it doesnt cause problems but be careful
    public Slider mines;
    public int choptreei;
    public int minei;
    private void Start()
    {
        mines.value = PlayerPrefs.GetInt("mine");
        choptrees.value = PlayerPrefs.GetInt("chop");
    }
    void Update() {

    minei = Mathf.RoundToInt(mines.value);
        choptreei = Mathf.RoundToInt(choptrees.value);
        PlayerPrefs.SetInt("mine",minei);
           PlayerPrefs.SetInt("chop",choptreei);
       
  
        wedg1.fillAmount = choptrees.value / 100f;
        wedg2.fillAmount = mines.value / 100f;


       // d.text = Input.mousePosition.y.ToString();
         if ( Input.mousePosition.y <935 )
            {


            mines.value = 100 - choptrees.value;
            }
         else
        {
            choptrees.value = 100 - mines.value;
        }
    }


}
