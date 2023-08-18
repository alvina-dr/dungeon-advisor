using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using DG.Tweening;

public class ArrowGames : MonoBehaviour
{
    [System.Serializable] 
    public class Arrows {
        [SerializeField] public GameObject[] arrows;
    }
    public Arrows arrows;
    public CinemachineVirtualCamera virtualCamera;

    private int[] arrowArray = new int[9];
    private List<int> nums = new List<int>(); 
    private int currentArrow = 0;
    private float timer = 0;
    private GameObject[] stockArrows = new GameObject[9];
    public Transform arrowParent;

    void Start()
    {
        for(int i = 0; i < 9; i++){
            nums.Add(i%3);
        } 
        int rand, num;
        
        for(int j = 0; j < 9; j++){
            rand = Random.Range(0, nums.Count);
            num = nums[rand];
            arrowArray[j] = num;
            nums.Remove(nums[rand]);
        }

        string debug = "";
        for(int i = 0; i < 9; i++){
            debug+= arrowArray[i] + " ";
        } 
        
        for(int i = 0; i < 9; i++){
            GameObject prefabArrow = arrows.arrows[arrowArray[i]];
            stockArrows[i] = Instantiate(prefabArrow, new Vector3(2*i, arrowParent.position.y, arrowParent.position.z), prefabArrow.transform.rotation, arrowParent);
        }
    }

    void Update()
    {
        if(timer > 0) {
            timer-= Time.deltaTime;
            if(timer < 0) {
                timer = 0;
            }
        } else {
            if(currentArrow == 9) {
                virtualCamera.gameObject.SetActive(false);
                GPCtrl.instance.currentInteractable.Activate();
                GPCtrl.instance.caretaker.currentRoom.virtualCamera.gameObject.SetActive(true);
                SceneManager.UnloadSceneAsync("MG_Trap");
                GPCtrl.instance.caretaker.blockPlayerMovement = false;
            }
            else {            
                if(Input.GetKeyDown(KeyCode.Q)) {
                    UpdateArrows(0);
                } else if(Input.GetKeyDown(KeyCode.D)) {
                    UpdateArrows(1);
                } else if(Input.GetKeyDown(KeyCode.Z)) {
                    UpdateArrows(2);
                }
            }
        }
    }
    private void UpdateArrows(int numArrow) {
        if(arrowArray[currentArrow] == numArrow) {
            // On déplace la fleche
            arrowParent.DOMoveX(arrowParent.position.x - 2, .4f);
            stockArrows[currentArrow].SetActive(false);
            currentArrow++;
            //timer = 0.2f;
        } else {
            timer = 1; // Pénalité
            Debug.Log("Erreur " + currentArrow);
        }
    }
}
