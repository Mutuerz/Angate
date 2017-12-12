using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Interaccion : MonoBehaviour {
    public Image Mira;// referencia a la mira del jugador
    bool contacto = false;// indica si se esta seleccionando un objeto interactuable
    string Objetcname;//nombre del objeto que se tiene seleccionado
    public GameObject InteractiveObjects;// acciones objetos
    public GameObject nombre;// Nombre objetos
    ObjetosInteractuables Action;// referencia a la clase de las acciones de objetos interactuables
    ObjetcsInSight objeto;//referencia al objeto que se esta seleccionando con la mira


    void Start () {
        Action = InteractiveObjects.GetComponent<ObjetosInteractuables>();
        objeto = nombre.GetComponent<ObjetcsInSight>();
    }


    void Update()
    {
       
        RaycastHit hit; // variable hit del raycast
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2.5f))// si algo se encuentra a cierta distancia
        {        
            if (hit.collider.tag.Equals("Interactuable")) 
            {
                contacto = true;// indica que se esta seleccionando un objeto interactuable
                Objetcname = hit.collider.name;// //Se le asigna el string del nombre del objeto que se tiene seleccionado
                objeto.SetText(Objetcname);// asignamos el nombre del objeto al que vemos
                Mira.GetComponent<Image>().color = Color.green; // Cambiar tonalidad de la mira para indicar que esta colisionando con un objeto interactuable
            }
            else
            {
                contacto = false;// no se esta seleccionando un objeto interactuable 
            }
        }
        else
        {
            ResetUI();
        }

        if (contacto) // si esta en contacto con un objeto interactuable
        {
            AccionObjetoActivado(); // acciones de algun objeto
        }
        Debug.DrawRay(transform.position, transform.forward * 2.5f, Color.green); // dibujo de raycast como prueba

    }
    void ResetUI() // resetea cambios en el UI del jugador
    {
        objeto.SetText();// limpia el nombre del objeto
        contacto = false;// no se esta seleccionando un objeto interactuable 
        Mira.GetComponent<Image>().color = Color.white; // Reseteo del color de la mira
    }
    void AccionObjetoActivado()// acciones de algun objeto
    {
        if (Input.GetButtonDown("Fire1"))// si el usuario presiona click izquierdo 
        {
            if (Objetcname == "Generador") // si el nombre del objeto es generador
            {
                Action.EncenderLuces();//Enciende las luces
            }
        }
    }



}
