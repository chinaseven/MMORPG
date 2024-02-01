using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public enum StateOfAnimation
    {
        para=0,
        anda=1,
        atq=2,
        jump=3
    }
    Animation anima;
    public StateOfAnimation stateOfAnimation;
    string atq="atq";
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponentInChildren<Animation>();
        anima["anda"].speed = 1.8f;
		stateOfAnimation = StateOfAnimation.para;
    }

    public void SetState(StateOfAnimation state)
    {
        stateOfAnimation = state;
    }



    public int animHit = 0;

    // Update is called once per frame
    void Update()
    {
        if (stateOfAnimation == StateOfAnimation.para)
        {
            if (!anima.IsPlaying("para"))
            {
                anima.Play("para");
            }
        }
        if (stateOfAnimation == StateOfAnimation.anda)
        {
            if (!anima.IsPlaying("anda"))
            {
                anima.Play("anda");
            }
        }
        if (stateOfAnimation == StateOfAnimation.atq)
        {
            if (!anima.IsPlaying(atq))
            {
                anima.Play(atq);
            }
            /*if (animHit == 0)
            {
                if (!anima.IsPlaying("atq"))
                {
                    anima.Play("atq");
                }
            }
            else{
                if (!anima.IsPlaying("atq2"))
                {
                    anima.Play("atq2");
                }
            }*/
        }
        /*
        if (stateOfAnimation == StateOfAnimation.jump)
        {
            if (!anima.IsPlaying("atq3"))
            {
                anima.Play("atq3");
            }
        }*/
    }
}
