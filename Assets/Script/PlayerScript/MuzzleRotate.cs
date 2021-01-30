using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleRotate : MonoBehaviour {

    public GameObject muzzleRight;
    public GameObject muzzleLeft;

    bool changeSize = true;

    // Update is called once per frame
    void FixedUpdate() {
        if(PlayerController.instance.isFacingRight != changeSize) {
            if (PlayerController.instance.isFacingRight) {
                muzzleRight.SetActive(true);
                muzzleLeft.SetActive(false);
            }
            else {
                muzzleLeft.SetActive(true);
                muzzleRight.SetActive(false);
            }

            changeSize = PlayerController.instance.isFacingRight;
        }
    }
}
