using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM2_comboText : MonoBehaviour
{
    public Text GM2comboText;
    public static int maxCombo=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int combo = Activator.GM2ActivatorComboCount;
        if(combo> maxCombo)
        {
            maxCombo = combo;
        }
        string comboShow = combo.ToString();
        GM2comboText.text = "Combo\n" + comboShow + " X";
    }
}
