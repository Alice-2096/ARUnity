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
    // private Button pine = GameObject.Find("pine").GetComponent<Button>();
    // private Button palm = GameObject.Find("palm").GetComponent<Button>();
    // private Button poplar = GameObject.Find("poplar").GetComponent<Button>();
    // private Button willow = GameObject.Find("willow").GetComponent<Button>();
    // private Button oak = GameObject.Find("oak").GetComponent<Button>();

    // private Button maple = GameObject.Find("maple").GetComponent<Button>();
    public Button pine, palm, poplar, willow, oak, maple;
    public Button delete, deleteAll;

    void Start()
    {
        delete.onClick.AddListener(() => DeleteClicked());
        deleteAll.onClick.AddListener(() => DeleteAllClicked());
        // pine.onClick.AddListener(() => ButtonClicked("pine"));
        // palm.onClick.AddListener(() => ButtonClicked("palm"));
        // poplar.onClick.AddListener(() => ButtonClicked("poplar"));
        // willow.onClick.AddListener(() => ButtonClicked("willow"));
        // oak.onClick.AddListener(() => ButtonClicked("oak"));
        // maple.onClick.AddListener(() => ButtonClicked("maple"));
        pine.onClick.AddListener(() => ButtonClicked("round"));
        palm.onClick.AddListener(() => ButtonClicked("square"));
        poplar.onClick.AddListener(() => ButtonClicked("round"));
        willow.onClick.AddListener(() => ButtonClicked("square"));
        oak.onClick.AddListener(() => ButtonClicked("round"));
        maple.onClick.AddListener(() => ButtonClicked("square"));
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
