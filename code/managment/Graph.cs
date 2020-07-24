using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Graph : MonoBehaviour
{

    public Image wedgePrefab;
    public List<Color> wedgeColors;
    public List<Image> wedges = new List<Image>(6);
    public Text warning;

    void Start()
    {
        for (int i = 0; i < wedges.Count; i++)
        {
            wedges[i].color = wedgeColors[i];
        }
    }

    public void MakeGraph(List<float> values)
    {
        float sum = 0f;
        float zRot = 0f;
        foreach (float value in values)
        {
            sum += value;
        }
        if (sum == 0f)
        {
            foreach (Image wedge in wedges)
            {
                wedge.fillAmount = 0f;
                warning.gameObject.SetActive(true);
            }
            return;
        }
        warning.gameObject.SetActive(false);
        for (int i = 0; i < values.Count; i++)
        {
            wedges[i].fillAmount = values[i] / sum;
            wedges[i].rectTransform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRot));
            zRot -= values[i] / sum * 360;
        }
    }



}
