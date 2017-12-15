using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjetcsInSight : MonoBehaviour {
    public Text objeto;
	
	void Start () {
		objeto =  GetComponent<Text>();
    }
	

    public void SetText (string NombreObjeto=null)// Asigna nombre a el ui de texto para nombre, si no se recibe parametro el nombre es nulo
    {
        objeto.text = NombreObjeto;// asigna el texto el nombre del objeto
    }
}
