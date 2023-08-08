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
        if (Input.GetKeyDown(KeyCode.F))
        {
            float pickUpDistance = 4f;
            //if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
            //{
                //Debug.Log("BLACK SWORD");

                //GameObject object1 = objectGrabbable.gameObject;
                //if (object1.name == "DemonicSword")
                //{
                //    Debug.Log("FOUND BLACK SWORD");
                //}
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    GameObject sword;
                    GameObject object1 = hit.collider.gameObject;
                    if (object1.name == "DemonicSword")
                    {
                        sword = GameObject.Find("Player/Main Camera/Player_Sword2");
                        GameObject sword1 = GameObject.Find("Player/Main Camera/Player_Sword");
                        sword.SetActive(true);
                        sword1.SetActive(false); 
                        Debug.Log("FOUND BLACK SWORD");
                    }
                }
            }

            //}
        }

        if (Input.GetKeyDown(KeyCode.E)) {
          if (objectGrabbable == null) {
             float pickUpDistance = 4f;
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
