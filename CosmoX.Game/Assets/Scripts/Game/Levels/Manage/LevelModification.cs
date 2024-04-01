using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelModification : Button, IPointerClickHandler
{
    [SerializeField]
    private GameObject selectedUI;

#pragma warning disable CS0114
    public void OnPointerClick(PointerEventData eventData)
#pragma warning restore CS0114
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            selectedUI.SetActive(true);

            Debug.Log("Right mouse button clicked on the button");
        }
    }
}
