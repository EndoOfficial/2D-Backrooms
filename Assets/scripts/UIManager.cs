using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text tutorialtxt;
    private void OnEnable()
    {
        Events.onSpacePressed += removeText;
    }
    private void OnDisable()
    {
    }
    private void removeText(bool spacePressed)
    {
        tutorialtxt.text = " ";
    }
    
}
