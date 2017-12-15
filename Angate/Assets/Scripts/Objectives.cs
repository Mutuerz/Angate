using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using UnityEngine;

public class Objectives : MonoBehaviour {
    public Text objetivo;
	short line = 1;
	void Start () {
		
		objetivo =  GetComponent<Text>();
    }
	

    public void NextObjetive ()// Asigna el objetivo a el UI de texto para objetivo, si no se recibe parametro el nombre es nulo
    {
        string path = "Assets/Readables/Objectives.txt"; // direccion del txt con los objetivos
        StreamReader reader = new StreamReader(path);

        //Este ciclo permite que se muestren solamente la linea del numero del objetivo por el cual va el jugador
        for (short i = 1; i <= line; i++)
        {        
            if (i==line)
            {
                objetivo.text = reader.ReadLine();// SE lee el texto
                line += 1;// aumentamos la linea, lo que sirve tambien para indicar porque numero de objetivo va el jugador
                return; 
            }
            reader.ReadLine();
        }
        reader.Close();
    }
}
