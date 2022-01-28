using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
     private Player user;

    [SerializeField] private KeyCode leftInput;
    [SerializeField] private KeyCode rightInput;
    [SerializeField] private KeyCode downInput;
    [SerializeField] private KeyCode upInput;

    private void Update()
    {
        if (!user) return;

        if (Input.GetKey(leftInput))
        {
            user.MoveXSource(false);
        }

        if (Input.GetKey(rightInput))
        {
            user.MoveXSource(true);
        }

        if (Input.GetKey(upInput))
        {
            user.MoveYSource(true);
        }

        if (Input.GetKey(downInput))
        {
            user.MoveYSource(false);
        }
    }
    


    public void SetUser(Player player)
    {
        user = player;
    }
}
