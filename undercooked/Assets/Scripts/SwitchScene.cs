using UnityEngine; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class SwitchScene : MonoBehaviour {
    public GameObject offCanvas;
    public GameObject onCanvas;
    public GameObject FirstObject;


    public void Switch()

    {
        offCanvas.SetActive(true);
        onCanvas.SetActive(false);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(FirstObject, null);
    }
}
