using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosInteractuables: MonoBehaviour
{
    public GameObject WhiteLight;// referencia a una luz direccional blanca para toda la escena
    public GameObject EmergencyLight;// referencia a las luces rojas del pasillo principal
    public GameObject DarkScreen;// referencia al UI negro transparente que da sensacion de oscuridad
   
    public GameObject SecurityDoor; // referencia al objeto de la puerta de seguridad para poder ejecutar la animacion de abrirla

  
    OpenSecurityDoor door;// referencia al script para abrir puerta de seguridad

    private void Start()
    {
        door = SecurityDoor.GetComponent<OpenSecurityDoor>();
     
    }

    public void EncenderLuces() // cambios en objetos para aparentar encendida de luces
    {
        
        WhiteLight.SetActive(true);
        EmergencyLight.SetActive(false);
        DarkScreen.SetActive(false);
      
    }

    public void OpenSecurityDoor()// call the script of the security door to open
    {
        door.OpenDoor();
    }
}

