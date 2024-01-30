using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SaveTest : MonoBehaviour
{
    public PlayerData PD;
    // Start is called before the first frame update
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SaveManager.Save(PD);
        }
    }
}
