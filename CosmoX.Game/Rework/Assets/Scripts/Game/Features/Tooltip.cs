using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public string message;
    private void OnMouseEnter()
    {
        TooltipManager._instanse.SetAndShowToolTip(message);
    }
    private void OnMouseExit()
    {
        TooltipManager._instanse.HideToolTip();
    }
}
