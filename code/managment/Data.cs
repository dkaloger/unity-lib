using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour
{
[SerializeField]
    List<float> values = new List<float>();
    public List<Slider> sliders;
    public Graph graph;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < sliders.Count; i++)
        {
            ColorBlock cb = sliders[i].colors;
            cb.normalColor = graph.wedgeColors[i];
            cb.highlightedColor = graph.wedgeColors[i];
            sliders[i].colors = cb;
            values.Add(0f);
        }
        SetValues();
    }

    public void SetValues()
    {
        for (int i = 0; i < sliders.Count; i++)
        {
            values[i] = sliders[i].value;
        }
        graph.MakeGraph(values);
    }
}