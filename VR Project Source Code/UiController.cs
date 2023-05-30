using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class UiController : MonoBehaviour
{
    public Volume volume;

    public Vignette vignette;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
        
    
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void showDamage()
    {
        StartCoroutine(damaged());
 
    }

    IEnumerator damaged()
    {
        if (volume.profile.TryGet<Vignette>(out vignette))
        {
            vignette.intensity.value = Mathf.PingPong(Time.time, .8f);
        }

        audioSource.Play();

        yield return new WaitForSeconds(1);

        if (volume.profile.TryGet<Vignette>(out vignette))
        {
            vignette.intensity.value = .1f;
        }

    }



}
