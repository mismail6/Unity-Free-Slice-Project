using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;
    Collider temp;

    private ObjectGrabbable objectGrabbable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject sword;
        GameObject sword1;
        if (Input.GetKeyDown(KeyCode.F))
        {
           

            sword = GameObject.Find("Player/Main Camera/Player_Sword2");
            sword1 = GameObject.Find("Player/Main Camera/Player_Sword");
            sword.SetActive(true);
            sword1.SetActive(false);


            //}
        }
        if (Input.GetKeyDown(KeyCode.G))
        {


            sword = GameObject.Find("Player/Main Camera/Player_Sword2");
            sword1 = GameObject.Find("Player/Main Camera/Player_Sword");
            sword.SetActive(false);
            sword1.SetActive(true);


            //}
        }
        if (Input.GetKeyDown(KeyCode.E)) {
          if (objectGrabbable == null) {
             float pickUpDistance = 32f;
             if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
             {
                if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                {
                        temp = objectGrabbable.gameObject.GetComponent<Collider>();
                        temp.enabled = false;
                         objectGrabbable.Grab(objectGrabPointTransform);
                }
              }
           }else {
               temp.enabled = true;
               temp = null;
               objectGrabbable.Drop();
               objectGrabbable = null;
           }
        }
    }
}
