using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]private AudioClipsSO audioSO;
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       


        BaseCounter.OnObjectDrop += BaseCounter_OnObjectDrop;
        DeliveryManager.OnReciepeSuccess += DeliveryManager_OnReciepeSuccess;
        DeliveryManager.OnReciepeFailure += DeliveryManager_OnReciepeFailure;
        PlayerMovement.OnPickUP += PlayerMovement_OnPickUP;
        TrashCounter.OnTrashCounter += TrashCounter_OnTrashCounter;

        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
    }

    private void TrashCounter_OnTrashCounter(object sender, System.EventArgs e)
    {
        TrashCounter trashCounter = sender as TrashCounter;
        PlaySound(audioSO.trashBin, trashCounter.transform.position);


    }

    private void BaseCounter_OnObjectDrop(object sender, System.EventArgs e)
    {
        BaseCounter baseCounter = sender as BaseCounter;
        PlaySound(audioSO.objectDrop, baseCounter.transform.position);

    }

    private void PlayerMovement_OnPickUP(object sender, System.EventArgs e)
    {
        PlayerMovement player = sender as PlayerMovement;
      
        PlaySound(audioSO.objectPickup, player.transform.position);

    }

    private void CuttingCounter_OnAnyCut(object sender, System.EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound(audioSO.chop, cuttingCounter.transform.position);
    }

    private void DeliveryManager_OnReciepeFailure(object sender, System.EventArgs e)
    {
        DeliveryManager deliveryManager = sender as DeliveryManager;
        PlaySound(audioSO.delieveryFail,deliveryManager.transform.position);
    }

    private void DeliveryManager_OnReciepeSuccess(object sender, System.EventArgs e)
    {
        DeliveryManager deliveryManager = sender as DeliveryManager;

        PlaySound(audioSO.delieverySuccess, deliveryManager.transform.position);

    }
    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClipArray[Random.Range(0,audioClipArray.Length)], position, volume);
    }

    private void PlaySound(AudioClip audioClip,Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip,position,volume); 
    }

    public void PLayFootSteps(Vector3 position, float volume)
    {
        PlaySound(audioSO.footSteps, position,volume);

    }

}
