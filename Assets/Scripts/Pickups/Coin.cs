using UnityEngine;

public class Coin : Pickup
{   
    [SerializeField] int scoreAmount = 100;
    [SerializeField] AudioSource coinPickUpAudioSource;
    ScoreManager scoreManager;

    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }
    protected override void OnPickUp()
    {
        scoreManager.IncreaseScore(scoreAmount);
        if(coinPickUpAudioSource != null && coinPickUpAudioSource.clip != null)
        {
            AudioSource.PlayClipAtPoint(
                coinPickUpAudioSource.clip,
                transform.position,
                coinPickUpAudioSource.volume
            );
        }
    }
}
