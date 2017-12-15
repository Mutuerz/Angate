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
    public GameObject GlobalEvents;// referencia al objeto que keeptrack de los eventos del juego
    public GameObject Objetivos;// referencia al objeto con la lista de objetivos


    GlobalEvents Global; // referencia a la clase que administra los eventos ejecutados
    ObjetosInteractuables Action;// referencia a la clase de las acciones de objetos interactuables
    ObjetcsInSight objeto;//referencia a la clase que se esta seleccionando con la mira
    Objectives objetivos; // referencia al script de objetivos

    void Start () {
        Global = GlobalEvents.GetComponent<GlobalEvents>();
        Action = InteractiveObjects.GetComponent<ObjetosInteractuables>();
        objeto = nombre.GetComponent<ObjetcsInSight>();
        objetivos = Objetivos.GetComponent<Objectives>();
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
            if (Input.GetButtonDown("Fire1"))// si el usuario presiona click izquierdo 
            {
                AccionObjetoActivado(); // acciones en algun objeto
            }
        }
        Debug.DrawRay(transform.position, transform.forward * 2.5f, Color.green); // dibujo de raycast como prueba

    }


    // SUBRUTINAS
    void ResetUI() // resetea cambios en el UI del jugador
    {
        objeto.SetText();// limpia el nombre del objeto
        contacto = false;// no se esta seleccionando un objeto interactuable 
        Mira.GetComponent<Image>().color = Color.white; // Reseteo del color de la mira
    }

    void AccionObjetoActivado()// acciones en algun objeto
    {
        if (Objetcname == "Generador") // si el nombre del objeto es generador
        {
           Action.EncenderLuces();//Enciende las luces
            if (!Global.PowerOn)
            {
                objetivos.NextObjetive(); // llamamos a la fucion para avanzar objetivos
            }     
           Global.PowerOn = true;
        }
        if (Objetcname == "Security Door")// si el nobmre del objeto es security door
        {
            if (Global.PowerOn) // valida si ya se encendieron las luces
            {
                Action.OpenSecurityDoor();// abre la puerta
                if (!Global.SecurityDoorOpened)
                {
                    objetivos.NextObjetive(); // llamamos a la fucion para avanzar objetivos
                }               
                Global.SecurityDoorOpened = true;
            }
           
        }
    }



}
