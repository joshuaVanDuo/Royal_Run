using UnityEngine;

public class Apple : Pickup
{   
    [SerializeField] float adjustChangeMoveSpeedAmount = 3f;
    [SerializeField] AudioSource ApplePickUpAudioSource;

    LevelGenerator levelGenerator;

    public void Init(LevelGenerator levelGenerator)
    {   
        this.levelGenerator = levelGenerator;
    }

    protected override void OnPickUp()
    {   
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        if (ApplePickUpAudioSource != null && ApplePickUpAudioSource.clip != null)
        {
            AudioSource.PlayClipAtPoint(
                ApplePickUpAudioSource.clip,
                transform.position,
                ApplePickUpAudioSource.volume
            );
        }

        //Debug.Log("Speed up!");
    }
}
