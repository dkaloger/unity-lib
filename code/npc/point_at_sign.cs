using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class point_at_sign : MonoBehaviour
{
 public   Renderer m_Renderer;
    public binocular b;
    public int progress =0;
    public Text dialog;
    public string my_lines;
    public int delay1;
  public  int t;
    public string reply;
    public int delay2;
    public string my_lines2;
    public int delay3;
    public string my_lines3;

    public string my_lines_exit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(progress == 0)
        {
            dialog.text = my_lines;
            progress = 1;
        }
 

    }
    private void OnTriggerStay(Collider other)
    {
        t++;
        if (t > delay1 && progress == 1)
        {
            dialog.text = reply;
            t = 0;
            progress = 2;
        }

        if (t > delay2 && progress == 2)
        {
            dialog.text = my_lines2;
            t = 0;
            progress = 3;
        }
        if (t > delay3 && progress == 3)
        {
         
            if (b.FOV < 5f && m_Renderer.isVisible ==true)
            {
                t = 0;
                progress = 4;
            }

        }
        if (progress == 4  )
        {
            dialog.text = my_lines3;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(progress != 4) {
            dialog.text = my_lines_exit;
        }

         
      

    }
    void Update()
    {

    }
}
