using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellScript : MonoBehaviour, Iinteractable
{
    [SerializeField] Item water;
    [SerializeField] int waterTime;

    AudioSource audioSource;
    public AudioClip interactingSound;
    public GameObject particles;
    
    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    public void OnInteract()
    {
        if(Inventory.instance.items.Count < DataManager.instance.inventorySpace)
        {
            audioSource.PlayOneShot(interactingSound);
            particles.SetActive(true);

            var newWater = Instantiate(water);

            Inventory.instance.Add(newWater);

            PlayerMovment.freePlayer = false;

            Invoke("finishWater", waterTime * DataManager.instance.pocoVel);
        }
    }

    void finishWater()
    {
        PlayerMovment.freePlayer = true;
        particles.SetActive(false);
    }

    
}
