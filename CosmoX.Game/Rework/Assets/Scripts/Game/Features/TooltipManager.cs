using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Unity.VisualScripting;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager _instanse;

    public TextMeshProUGUI textComponent;
    private void Awake()
    {
        if(_instanse != null && _instanse != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instanse = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetAndShowToolTip(string message)
    {
        gameObject.SetActive(true);
        textComponent.text = message;
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty;
    }
}
