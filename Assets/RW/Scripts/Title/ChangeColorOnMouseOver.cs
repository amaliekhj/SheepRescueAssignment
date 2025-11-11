using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColorOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MeshRenderer model; // A reference to the mesh renderer that needs its color changed.
    public Color normalColor; // The default color of the model.
    public Color hoverColor; // The color that should be applied on the model when the pointer is hovering over it.
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        model.material.color = normalColor;
    }

    // Update is called once per frame
    public void OnPointerEnter(PointerEventData eventData) // This gets called when the pointer enters the GameObject and changes the color of the model's material.
    {
        model.material.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData) // Called when the pointer exits the GameObject. This resets the color of the material to its normal value.
    {
        model.material.color = normalColor;
    }
}
