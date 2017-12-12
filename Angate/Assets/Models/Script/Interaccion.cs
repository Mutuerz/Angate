using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Interaccion : MonoBehaviour {
    public Image Mira;
    bool contacto = false;
    string Objetcname;//nombre del objeto que se tiene seleccionado
    public GameObject Generator;// objeto interactuable
    GeneradorEncendido Encender;



    void Start () {
        Encender = Generator.GetComponent<GeneradorEncendido>();
    }


    void Update()
    {
       
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
        { 
           
            if (hit.collider.tag.Equals("Interactuable")) 
            {
                contacto = true;// indica que se esta seleccionando un objeto interactuable
                Objetcname = hit.collider.name;// //Se le asigna el string del nombre del objeto que se tiene seleccionado
                print((hit.collider.name));
                Mira.GetComponent<Image>().color = Color.green; // Cambiar tonalidad de la mira para indicar que esta colisionando con un objeto interactuable
            }
            else
            {
                contacto = false;// no se esta seleccionando un objeto interactuable 
            }
        }
        else
        {
            contacto = false;// no se esta seleccionando un objeto interactuable 
            Mira.GetComponent<Image>().color = Color.white; // Reseteo del color de la mira
        }
        if (contacto)
        {
            Encender.EncenderLuces();//Enciende las luces
        }
        Debug.DrawRay(transform.position, transform.forward * 1f, Color.green); // dibujo de raycast como prueba

    }



}
