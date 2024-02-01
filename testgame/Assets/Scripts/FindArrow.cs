using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindArrow : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Arrow"))
        {
            Debug.Log("sdaf");
            Debug.Log(other.transform.GetChild(4));
            other.transform.GetChild(4).GetComponent<ArrowMove>().ShowArrow();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Arrow"))
        {
            other.transform.GetChild(4).GetComponent<ArrowMove>().HideArrow();
        }
    }
}
