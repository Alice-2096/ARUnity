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
    public Button delete, deleteAll;

    void Start()
    {
        delete.onClick.AddListener(() => DeleteClicked());
        deleteAll.onClick.AddListener(() => DeleteAllClicked());
        round.onClick.AddListener(() => ButtonClicked("round"));
        square.onClick.AddListener(() => ButtonClicked("square"));
        // Text text = button.getComponentInChildren<Text>();
    }
    void ButtonClicked(string treeName)
    {
        Debug.Log("TREE IS : " + treeName);
        //update global variable inside GameObject
        GameManager.Instance.SelectedTree = treeName;
        Debug.Log("TREE in Gamemanager IS : " + GameManager.Instance.SelectedTree);
        GameManager.Instance.spawnMode = true;
        GameManager.Instance.DeleteTree = false;
        Debug.Log("spawnMode is : " + GameManager.Instance.spawnMode);
    }

    void DeleteClicked()
    {
        GameManager.Instance.DeleteTree = true;
        Debug.Log("DeleteTree is : " + GameManager.Instance.DeleteTree);
    }

    void DeleteAllClicked()
    {
        //find all trees and delete them
        GameObject[] trees = GameObject.FindGameObjectsWithTag("tree");
        foreach (GameObject tree in trees)
        {
            Destroy(tree);
        }
        Debug.Log("Delete all trees");
    }
}
