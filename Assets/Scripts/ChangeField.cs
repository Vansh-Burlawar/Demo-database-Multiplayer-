using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.VersionControl;

public class ChangeField : MonoBehaviour
{
    EventSystem system;
    public Button submitbutton;
    public Selectable firstInput;
 
    void Start()
    {
        system = EventSystem.current;
        firstInput.Select();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            Selectable pervious = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if(pervious != null)
            {
                pervious.Select();
            }
        }else if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if(next != null)
            {
                next.Select();
            } 
        }else if (Input.GetKeyDown(KeyCode.Return)){
            submitbutton.onClick.Invoke();
        }
    }
}
