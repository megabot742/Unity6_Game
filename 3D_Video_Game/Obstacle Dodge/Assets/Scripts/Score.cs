using UnityEngine;

public class Score : MonoBehaviour
{
    int hits=0;
    void OnCollisionEnter(Collision other) 
    {
        hits++;
        Debug.Log("You've bumped into a thing this many times: " + hits);
    }
}
