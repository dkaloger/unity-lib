using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetomouse : MonoBehaviour
{
    [SerializeField] private Vector3 mousePosition;
    [SerializeField] private float moveSpeed = 0.1f;
    public bool pause;
    void Start()
    {
        pause = false;
    }

    void Update()
    {
        moveToMouseFunc();
    }

    void moveToMouseFunc()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = mousePosition;
    }
}