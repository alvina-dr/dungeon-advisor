using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGames : MonoBehaviour
{

    [System.Serializable] 
    public class Arrows {
        [SerializeField] public GameObject[] arrows;
    }
    public Arrows arrows;
    private int[] arrowArray = new int[9];

    private List<int> nums = new List<int>(); 

    private int currentArrow = 0;
    private float timer = 0;
    private GameObject[] stockArrows = new GameObject[9];

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
        Debug.Log(debug);
     
        for(int i = 0; i < 9; i++){
            GameObject prefabArrow = arrows.arrows[arrowArray[i]];
            stockArrows[i] = Instantiate(prefabArrow, new Vector3(2*i, 0, 0), prefabArrow.transform.rotation);
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
                //mini jeu fini
            } else {            
                if(Input.GetKeyDown(KeyCode.LeftArrow)) {
                    updateArrows(0);
                } else if(Input.GetKeyDown(KeyCode.DownArrow)) {
                    updateArrows(1);
                } else if(Input.GetKeyDown(KeyCode.RightArrow)) {
                    updateArrows(2);
                }
            }
        }
    }
    private void updateArrows(int numArrow) {
        if(arrowArray[currentArrow] == numArrow) {
            // On déplace la fleche
            stockArrows[currentArrow].SetActive(false);
            currentArrow++;
            timer = 0.2f;
        } else {
            timer = 1; // Pénalité
            Debug.Log("Erreur " + currentArrow);
        }
    }
}
