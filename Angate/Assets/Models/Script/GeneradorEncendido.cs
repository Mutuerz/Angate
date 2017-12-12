using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEncendido : MonoBehaviour {
   public GameObject WhiteLight;
   public GameObject EmergencyLight;
   public GameObject DarkScreen;
	
	
    public void EncenderLuces()
    {
        WhiteLight.SetActive(true);
        EmergencyLight.SetActive(false);
        DarkScreen.SetActive(false);
    }
}
