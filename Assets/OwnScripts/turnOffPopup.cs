using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOffPopup : MonoBehaviour
{
    public Canvas popup;
    public void OnPointerClickXR()
    {
        popup.gameObject.SetActive(false);
    }
}
