using UnityEngine;

public class Score : MonoBehaviour
{
    int hits=0;
    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag != "Hit")
        {
            hits++;
        Debug.Log("You've bumped into a thing this many times: " + hits);
        } 
    }
}
