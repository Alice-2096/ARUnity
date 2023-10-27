using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class buttonTab : MonoBehaviour
{
    public Button round, square;
    void Start()
    {
        round.onClick.AddListener(() => ButtonClicked("round"));
        square.onClick.AddListener(() => ButtonClicked("square"));
    }
    void ButtonClicked(string treeName)
    {
        Debug.Log("TREE IS : " + treeName);
        //update global variable inside GameObject
        GameManager.Instance.SelectedTree = treeName;
        Debug.Log("TREE in Gamemanager IS : " + GameManager.Instance.SelectedTree);
        GameManager.Instance.spawnMode = true;
        Debug.Log("spawnMode is : " + GameManager.Instance.spawnMode);
    }
}
