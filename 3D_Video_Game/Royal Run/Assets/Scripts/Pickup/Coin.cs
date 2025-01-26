using System;
using TMPro;
using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] int scoreCoin = 100;
    [SerializeField] AudioClip coinAudio;
    [SerializeField, Range(0,1)] float audioVolume;
    ScoreManager scoreManager;
    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }
    protected override void OnPickup()
    {
        scoreManager.IncreseScore(scoreCoin);
        AudioSource.PlayClipAtPoint(coinAudio, transform.position, audioVolume);
    }
}
