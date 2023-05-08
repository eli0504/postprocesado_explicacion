using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessing : MonoBehaviour
{
    //acceso a la componente volume, vignette
    private Volume volume;
    private Vignette vignette;

    //cuando se cargue el game object se cargan todas las componentes
    private void Awake()
    {
        volume = GetComponent<Volume>();
    }

    private void Start()
    {
        volume.profile.TryGet(out vignette); //encontrar y enchufar la vi�eta
        //modificar la vi�eta
        vignette.intensity.value = 0.5f;
        vignette.color.value = Color.red;


        StartCoroutine(Desactive()); //LLAMAR CORRUTINA
    }

    private IEnumerator Desactive() //corrutina para cambiar color y desactivar vi�eta
    {
        yield return new WaitForSeconds(3);
        vignette.intensity.value = 1f;
        vignette.color.value = Color.yellow;

        yield return new WaitForSeconds(2);
        vignette.active = false;
    }
}
