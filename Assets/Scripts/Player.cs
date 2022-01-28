using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Player : MonoBehaviour
{
    private InputHandler inputHandler;
    public AbstractSource XAxisSource;
    public AbstractSource YAxisSource;

    
    private void Start()
    {
        GetComponents();

        if (inputHandler)
        {
        inputHandler.SetUser(this);
        }
        else
        {
            Debug.LogWarning("No InputHandler Attached On Player");
        }
    }
    private void GetComponents()
    {
        inputHandler = GetComponent<InputHandler>();
    }

    public void MoveXSource(bool moveRight)
    {
        if (moveRight)
        {
            XAxisSource.MoveSource(1);
        }
        else
        {
            XAxisSource.MoveSource(-1);
        }
    }

    public void MoveYSource(bool moveUp)
    {
        if (moveUp)
        {
            YAxisSource.MoveSource(1);
        }
        else
        {
            
            YAxisSource.MoveSource(-1);
        }
    }


}
