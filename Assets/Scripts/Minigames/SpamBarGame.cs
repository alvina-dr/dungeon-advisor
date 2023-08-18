using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpamBarGame : MonoBehaviour
{
    private Fill fill;
    private Image barImage;

    private void Awake() {
        barImage = transform.Find("FillBar").GetComponent<Image>();
        fill = new Fill();
        fill.ResetFillAmount();
    }

    private void Update() {
        fill.Update();

        barImage.fillAmount = fill.GetFillNormalized();

        if (Input.GetKeyDown(KeyCode.E)) { 
            // ici quand on appuie sur E on fait augmenter la barre
            int spamAmount = 1;
            fill.IncreaseFillAmount(spamAmount);
        }
    }
}

public class Fill {
    public const int FILL_MAX = 10;

    private float fillAmount;
    private float fillDecreaseRate = 1f; // Ici on dit de combien diminue la barre

    public Fill() {
        fillAmount = 0; // au début on a 0
    }

    public void ResetFillAmount() {
        fillAmount = 0;
    }

    public void Update() {
        if (fillAmount < FILL_MAX) {
            fillAmount -= fillDecreaseRate * Time.deltaTime; // Ici la barre diminue toute seule de 1f par scs

            if (fillAmount < 0) {
                fillAmount = 0;
            }
        }
    }

    public void IncreaseFillAmount(int amount) {
        fillAmount += amount;

        if (fillAmount > FILL_MAX) {
            fillAmount = FILL_MAX;
            GPCtrl.instance.currentInteractable.Activate();
            SceneManager.UnloadSceneAsync("MG_Spam");
            GPCtrl.instance.caretaker.blockPlayerMovement = false;
        }
    }

    public float GetFillNormalized() {
        return fillAmount / FILL_MAX;
    }
}