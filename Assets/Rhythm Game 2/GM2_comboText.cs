using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM2_comboText : MonoBehaviour
{
    Text m_Text;
    public Text GM2comboText;
    public static int maxCombo=0;
    public Font m_Font;
    // Start is called before the first frame update
    void Start()
    {
        m_Text = GetComponent<Text>();
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
        GM2comboText.font = m_Font;
        GM2comboText.text = "Combo\n" + comboShow + " X";
    }
}
