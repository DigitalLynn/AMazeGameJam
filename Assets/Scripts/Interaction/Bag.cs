using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    public GameObject slotGroup;
    private bool bagOpen = false;

    public void OpenBag()
    {
        bagOpen = !bagOpen;
    }

    public void MoveBag()
    {
        if (!bagOpen)
        {
            slotGroup.transform.position = new Vector3(slotGroup.transform.position.x, slotGroup.transform.position.y - 1000, slotGroup.transform.position.z);
            OpenBag();
        }
        else
        {
            slotGroup.transform.position = new Vector3(slotGroup.transform.position.x, slotGroup.transform.position.y + 1000, slotGroup.transform.position.z);
            OpenBag();
        }
    }
}
