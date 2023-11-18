using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;
[CreateAssetMenu(fileName = "newPlayerData", menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    

    [Header("Move State")]
    public float movementVelocity = 10f;
    
    [Header("Jump State")]
    
    public float jumpVelocity = 15f;
    
    public int amountOfJumps = 1;
    
    [Header("Wall Jump State")]
    public float wallJumpVelocity = 20;
    public float wallJumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);
    
    [Header("In Air State")]
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;
    
    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3f;
    
    [Header("Wall Climb State")]
    public float wallClimbVelocity = 3f;
    
    [Header("Ledge Clinb State")]
    public Vector2 startOffset;
    public Vector2 stopOffset;
    
    [Header("Dash State")]
    public float dashCoolDown = 0.5f;
    public float maxHoldTime = 1.5f;
    public float holdTimeScale = 0.5f;
    public float dashTime = 0.5f;
    public float dashVelocity = 30f;
    public float drag = 10f;
    public float dashEndYMultiplier = 0.5f;
    public float distBetweenAfterImages = 0.5f;
    public int amountOfDash = 3;
    
    [Header("Croush States")]
    public float CrouchMovementVelocity = 5f;
    public float crouchColliderHeight = 0.8f;
    public float standColliderHeight = 1.6f;

   

   

}
