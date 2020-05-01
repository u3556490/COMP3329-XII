using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM2_Panel_pop : MonoBehaviour
{
    public GameObject Panel;
    public KeyCode hidePanelKey;
    public static bool gameStart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hidePanel();
    }
    public void hidePanel()
    {
        if (Input.GetKeyDown(hidePanelKey))
        {
            gameStart = true;
            Panel.gameObject.SetActive(false);
        }
    }
}
