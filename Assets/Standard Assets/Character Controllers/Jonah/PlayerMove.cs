using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    [SerializeField] private string HorizontalInputName;
    [SerializeField] private string VertitalInputName;
    private float MovementSpeed;

    [SerializeField] private float WalkSpeed, RunSpeed;
    // [SerializeField] private float RunBuildupSpeed;
    [SerializeField] private KeyCode SprintKey;
    [SerializeField] private KeyCode IsMoving;

    public Text currentSpeed;

    //Stamina bar
    public Slider StaminaBar;
    public float maxStamina;
    public float staminaLoss;
    public float staminaGain;
    private bool isEmpty = false;


    private CharacterController CharController;
    private void Awake()
    {
        CharController = GetComponent<CharacterController>();
        StaminaBar.maxValue = maxStamina;
    }

    void Update()
    { 
        //checkIfStaminaIsEmpty();
        PlayerMovement();      
    }

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(HorizontalInputName);
        float vertInput = Input.GetAxis(VertitalInputName);

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        CharController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * MovementSpeed);
        SetMovementSpeed();
    }

    private void SetMovementSpeed()
    {
        if (Input.GetKey(IsMoving) && Input.GetKey(SprintKey) /*&& isEmpty != true*/)
        {
            MovementSpeed = Mathf.Lerp(MovementSpeed, RunSpeed, 0.5f);
            //maxStamina -= staminaLoss * Time.deltaTime;
            //StaminaBar.value = maxStamina;
         //   currentSpeed.text = "Running " + MovementSpeed;
            
        }
        else 
        {
            //maxStamina += staminaGain * Time.deltaTime;
            //StaminaBar.value = maxStamina;
            MovementSpeed = Mathf.Lerp(MovementSpeed, WalkSpeed, 0.5f);
        //    currentSpeed.text = "Walking " + MovementSpeed;

        }
    }

    //public bool checkIfStaminaIsEmpty()
    //{
    //    if (StaminaBar.value <= 1.0f)
    //    {
    //        return isEmpty = true;
    //    }
    //    else
    //    {
    //        return isEmpty = false;
    //    }
    //}
}