using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosInteractuables: MonoBehaviour
{
    public GameObject WhiteLight;
    public GameObject EmergencyLight;
    public GameObject DarkScreen;
    public GameObject Objetivos;

    Objectives objetivos;

    private void Start()
    {
        objetivos = Objetivos.GetComponent<Objectives>();
    }

    public void EncenderLuces() // cambios en objetos para aparentar encendida de luces
    {
        
        WhiteLight.SetActive(true);
        EmergencyLight.SetActive(false);
        DarkScreen.SetActive(false);
        objetivos.NextObjetive(); // llamamos a la fucion para avanzar objetivos
    }
}

