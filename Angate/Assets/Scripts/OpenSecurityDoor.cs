using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSecurityDoor : MonoBehaviour {
    public Animator anim;

	
    public void OpenDoor()
    {
        anim.SetBool("OpenDoor", true);
        StartCoroutine(ResetBool());
    }

    IEnumerator ResetBool()
    {
        yield return new WaitForSeconds(14f);// Tiempo de espera antes de volver a colocar el valor booleano de la puerta como cerrada ->
                                             //para que no se abra de nuevo si el jugador spamea el click
        anim.SetBool("OpenDoor", false);
    }
}
