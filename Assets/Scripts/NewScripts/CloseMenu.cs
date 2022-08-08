using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    [SerializeField] GameObject _menu;

    public void DeactivateMenu()
    {
        if (_menu.activeInHierarchy)
        {
            _menu.SetActive(false);
        }
    }
}
