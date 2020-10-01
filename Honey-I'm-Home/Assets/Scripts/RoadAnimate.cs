using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadAnimate : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        Animate();
    }

    void Animate()
    {
        // Road only animates when player is moving forward
        if(Input.GetAxisRaw("Vertical") > 0)
            animator.speed = 0.7f;
        else
            animator.speed = 0;
    }
}
