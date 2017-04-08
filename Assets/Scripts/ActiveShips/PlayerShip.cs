using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : ActiveShip {





    public void Move(UnityStandardAssets._2D.PlayerInput.Input input) {





        //Moves the ship
        shipPrefab.transform.position += new Vector3(input.horizontal * speed, input.vertical * speed, 0);
    }


}
