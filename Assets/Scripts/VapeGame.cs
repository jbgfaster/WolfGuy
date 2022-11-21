using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class VapeGame : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private ParticleSystem vapeParticles;
    [SerializeField] private Image staminaImage;
    [SerializeField] private Image funImage;

    private float guysFun=0f;
    private float guysFunToWin=100f;
    private float guysFunHold=0f;
    private float stamina=100f;
    private float staminaMax=100f;
    [SerializeField]private float staminaRenew=0.01f;
    [SerializeField]private float staminaLess=0.01f;
    [SerializeField]private float fun=0.01f;



    void Start()
    {
        playerInput=GameObject.FindObjectOfType<PlayerInput>();
        playerInput.actions["Action"].started+=StartPushing;
        playerInput.actions["Action"].canceled+=StopPushing;
    }

    void Update()
    {
        
    }

    private void UpdateFun()
    {
        guysFun+=guysFunHold;
        guysFunHold=0;
        if(guysFun>=guysFunToWin)
        {
            guysFun=guysFunToWin;
            print("win");
        }
        funImage.fillAmount=guysFun/guysFunToWin;        
    }

    private void StartPushing(InputAction.CallbackContext a)
    {
        vapeParticles.Play();
        StopAllCoroutines();
        StartCoroutine(StaminaLess());
    }

    private void StopPushing(InputAction.CallbackContext a)
    {
         vapeParticles.Stop();
        StopAllCoroutines();
        StartCoroutine(StaminaRenew());
        UpdateFun();
    }

    private IEnumerator StaminaRenew()
    {
        while(stamina<staminaMax)
        {
            stamina+=staminaRenew;
            staminaImage.fillAmount=stamina/staminaMax;
            yield return new WaitForSeconds(0.01f);
        }        
    }

    private IEnumerator StaminaLess()
    {
        while(stamina>0)
        {
            stamina-=staminaLess;
            staminaImage.fillAmount=stamina/staminaMax;
            guysFunHold+=fun;
            yield return new WaitForSeconds(0.01f);
            //yield return null;
        }        
    }
}
