using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void TreeSelectedEventHandler(string selectedTree);
    public static event TreeSelectedEventHandler OnTreeSelected;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
