using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    string selectableTag = "Selectable";
    string inventoryTag = "Collectible";
    string itemInteractTag = "ItemInteract";
    string itemCombineTag = "ItemCombiner";
    string dialogueTag = "Talkable";
    string colorTag = "color";
    string pipeTag = "Pipe";
    string keyTag = "KeyPiece";
    string formTag = "KeyForm";
    public Material highlightMaterial;
    Material defaultMaterial;
    public float dist;
    Transform _selection;
    public PlayerMovement Player;
    public GameObject key;
    public Camera cam;
    public List<Sprite> interactSprites;
    public Image interactImage;
    public colorPuzzleManager colorButtonPuzzle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (_selection != null)
        {
            /*
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
            */
        }
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            dist = hit.distance;
            if (hit.distance > 4)
            {
                interactImage.sprite = interactSprites[0];
            }
            if(selection.CompareTag(selectableTag))
            {
                
                float distt = Vector3.Distance(hit.transform.position, Player.holdPos.position);
                if (hit.distance < 4)
                {
                    interactImage.sprite = interactSprites[3];
                    if (Input.GetKeyDown(KeyCode.E) && Player.holding == null && !Player.throwable)
                    {
                        hit.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        hit.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        Player.holding = hit.transform.gameObject;
                        Player.holding.transform.SetParent(Player.holdPos);
                        Player.holding.transform.localPosition = Vector3.zero;
                        Player.lastWeapon = Player.curWeapon;
                        Player.curWeapon = "None";
                    }
                }
                if (distt < 16 && Player.curWeapon == "GravityGun")
                {
                    Vector3 diff = Player.holdPos.position - hit.transform.position;//new Vector3(Player.holdPos.position.x - hit.transform.position.x, hit.transform.position.y, Player.holdPos.position.z - hit.transform.position.z);
                    
                    if (Input.GetMouseButton(1) && Player.holding == null)
                    {
                        hit.transform.GetComponent<Collider>().enabled = false;
                        hit.transform.GetComponent<CharacterController>().enabled = true;
                        //hit.transform.LookAt(Player.transform);
                        hit.transform.GetComponent<CharacterController>().Move(diff * 3f * Time.deltaTime);
                        if (distt < 2)
                        {
                            hit.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                            hit.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                            Player.holding = hit.transform.gameObject;
                            Player.holding.transform.SetParent(Player.holdPos);
                            Player.holding.transform.localPosition = Vector3.zero;
                        }
                    } 
                    
                }
                if (Player.holding == null)
                {
                    hit.transform.GetComponent<BoxCollider>().enabled = true;
                    hit.transform.GetComponent<CharacterController>().enabled = false;
                    hit.transform.GetComponent<Rigidbody>().useGravity = true;
                    hit.transform.GetComponent<Rigidbody>().freezeRotation = false;
                }
                _selection = selection;
            }
            else if (selection.CompareTag(inventoryTag))
            {
                
                if (hit.distance < 4)
                {
                    interactImage.sprite = interactSprites[3];
                    if (Input.GetKeyDown(KeyCode.E) && Player.holding == null && !Player.throwable)
                    {
                        selection.GetComponent<ItemOverworld>().TextUpdate();
                        Player.gameObject.GetComponent<InventoryManager>().AddItem(selection.GetComponent<ItemOverworld>().itemToGive);
                        selection.gameObject.SetActive(false);
                    }
                }
            }
            else if (selection.CompareTag(colorTag))
            {
                
                if (hit.distance < 4)
                {
                    interactImage.sprite = interactSprites[2];
                    var selectionn = hit.transform;
                    AnimatorClipInfo[] CurrentClipInfo = selectionn.GetComponentInChildren<Animator>().GetCurrentAnimatorClipInfo(0);
                    if (Input.GetKeyDown(KeyCode.E) && CurrentClipInfo[0].clip.name.Contains("Idle"))
                    {
                        //Debug.Log("fda");
                        selectionn.GetComponentInChildren<Animator>().SetTrigger("Press");
                        selectionn.GetComponent<colorButtonScript>().Pressed();
                        colorButtonPuzzle.Check();
                    }
                }
            }
            else if (selection.CompareTag(dialogueTag))
            {
                
                if (hit.distance < 4)
                {
                    interactImage.sprite = interactSprites[1];
                    var selectionn = hit.transform;
                    AnimatorClipInfo[] CurrentClipInfo = selectionn.GetComponent<characterDialogue>().textAnimator.GetCurrentAnimatorClipInfo(0);
                    if (Input.GetKeyDown(KeyCode.E) && CurrentClipInfo[0].clip.name.Contains("Idle"))
                    {
                        //Debug.Log("fda");
                        selectionn.GetComponent<characterDialogue>().TalkInteract();
                        
                        
                    }
                }
            }
            else if (selection.CompareTag(itemInteractTag))
            {
                
                if (hit.distance < 4)
                {
                    interactImage.sprite = interactSprites[2];
                    var selectionn = hit.transform;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        InventoryManager mainInventory = Player.gameObject.GetComponent<InventoryManager>();
                        if (mainInventory.inventory[mainInventory.selectedItem] == selectionn.GetComponent<itemInteractScript>().solution)
                        {
                            selectionn.GetComponent<itemInteractScript>().finish.SetTrigger("Solve");
                            mainInventory.inventory[mainInventory.selectedItem] = null;
                            mainInventory.UpdateUI();
                        }
                    }
                }
            }
            else if (selection.CompareTag(itemCombineTag))
            {
                
                if (hit.distance < 4)
                {
                    interactImage.sprite = interactSprites[2];
                    var selectionn = hit.transform;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        InventoryManager mainInventory = Player.gameObject.GetComponent<InventoryManager>();
                        selectionn.GetComponent<ItemCombineScript>().Check(mainInventory.selectedItem, mainInventory);
                        mainInventory.UpdateUI();
                    }
                }
            }
            else
            {
                interactImage.sprite = interactSprites[0];
            }
            /*else if (selection.CompareTag(dialogueTag))
            {

            }*/
        }
    }
}
