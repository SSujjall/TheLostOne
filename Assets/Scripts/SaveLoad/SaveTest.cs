using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    public PlayerData PD;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            SaveManager.Save(PD);
        }
        
        if (Input.GetKey(KeyCode.U))
        {
            PD = SaveManager.Load();
        }
    }
}
