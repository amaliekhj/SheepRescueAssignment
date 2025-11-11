using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class HayMachineSwitcher : MonoBehaviour, IPointerClickHandler
{

    // These variables reference each of the colored hay machine models you added as children of Hay Machines earlier.
    public GameObject blueHayMachine;
    public GameObject yellowHayMachine;
    public GameObject redHayMachine;

    private int selectedIndex; // This is an index that will be incremented whenever the hay machine selector is clicked

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void OnPointerClick(PointerEventData eventData) 
    {
        selectedIndex++; 
        selectedIndex %= Enum.GetValues(typeof(HayMachineColor)).Length; 

        GameSettings.hayMachineColor = (HayMachineColor)selectedIndex; 

        
        switch (GameSettings.hayMachineColor)
        {
            case HayMachineColor.Blue:
                blueHayMachine.SetActive(true);
                yellowHayMachine.SetActive(false);
                redHayMachine.SetActive(false);
            break;

            case HayMachineColor.Yellow:
                blueHayMachine.SetActive(false);
                yellowHayMachine.SetActive(true);
                redHayMachine.SetActive(false);
            break;

            case HayMachineColor.Red:
                blueHayMachine.SetActive(false);
                yellowHayMachine.SetActive(false);
                redHayMachine.SetActive(true);
            break;
        }
    }
}
