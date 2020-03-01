using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlipSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip blipSound;
    public AudioSource soundSource;

    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
        soundSource.PlayOneShot(blipSound);
    }
}
