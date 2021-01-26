using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    public Transform OpenButton;
    public Transform[] buttons;
    public Animation doorOpen;
    public int[] code;
    private int[] pressedKeys = new int[10];
    private bool pressLocked = false;
    private int count = 0;
    private void Start()
    {
        resetPressed();
    }

    public void PressButton(Transform Button)
    {
        if(OpenButton == Button)
        {
            openDoor();
        }else{
            if(!pressLocked)
            {
                for(int i=0; i<buttons.Length; i++)
                {
                    if(Button == buttons[i])
                    {
                        buttons[i].GetComponent<Animation>().Play();
                        checkCode(i);
                    }
                }
            }
        }
    }

    private void checkCode(int pressed)
    {
        if(count >= buttons.Length-1)
        {
            CancelInvoke("resetPressed");
            pressedKeys[count] = pressed;
            bool correct = true;
            for(int i=0; i<buttons.Length; i++)
            {
                if(pressedKeys[i] != code[i])
                {
                    correct = false;
                }
            }
            if(correct)
            {
                openDoor();
                //open sound
            }else{
                //wrong sound
                resetPressed();
            }
        }else{
            pressedKeys[count] = pressed;
            count++;
            CancelInvoke("resetPressed");
            Invoke("resetPressed",3);
        }
    }

    private void resetPressed()
    {
        CancelInvoke("resetPressed"); //makes sure that the ivoke isnt buged called again
        for(int i=0; i<pressedKeys.Length; i++)
        {
            pressedKeys[i] = 100;
        }
        count = 0;
    }
    //unlocks buttons
    private void unlockPress()
    {
        pressLocked = false;
    }
    private void openDoor()
    {
        doorOpen.Play();
        pressLocked = true;
        Invoke("unlockPress",3);
        resetPressed();
    }
}
