using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootGame : MonoBehaviour
{
    public GameObject loot1;
    public GameObject loot2;
    public GameObject loot3;

    public GameObject barre;
    public GameObject zone;
    public RectTransform indicatorRectTransform;
    private float speed = 400f;

    private bool hasSelectedLoot = false;
    private bool isMoving = true;
    private bool isStopped = false;
    private bool hasWon = false;
    private float minX;
    private float maxX;
    private float originalX;

    private float zoneMinX;
    private float zoneMaxX;

    private void Start() {
        minX = barre.transform.position.x - barre.GetComponent<RectTransform>().rect.width / 2f + indicatorRectTransform.rect.width / 2f;
        maxX = barre.transform.position.x + barre.GetComponent<RectTransform>().rect.width / 2f - indicatorRectTransform.rect.width / 2f;
        originalX = indicatorRectTransform.position.x;

        float zoneWidth = zone.GetComponent<RectTransform>().rect.width;

        // Définir la position aléatoire de la zone au début du jeu
        float randomX = Random.Range(minX + zoneWidth / 2f, maxX - zoneWidth / 2f);
        Vector3 zonePosition = zone.transform.position;
        zonePosition.x = randomX;
        zone.transform.position = zonePosition;

        // Définir les coordonnées de la zone une seule fois au début du jeu
        zoneMinX = zone.transform.position.x - zoneWidth / 2f;
        zoneMaxX = zone.transform.position.x + zoneWidth / 2f;

        isMoving = zone.activeSelf; // Désactiver le mouvement si la zone est déjà affichée
    }

    private void Update() {
        if (!hasSelectedLoot) {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SelectLoot(loot1);
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                SelectLoot(loot2);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                SelectLoot(loot3);
            }
        }

        if (isMoving && Input.GetKeyDown(KeyCode.E) && !isStopped) {
            if (IsInZone())
            {
                isMoving = false;
                isStopped = true;
                hasWon = true;
                Debug.Log("Bravo, c'est gagné !");
            }
        }
    }

    private void SelectLoot(GameObject selectedLoot)
    {
        loot1.SetActive(selectedLoot == loot1);
        loot2.SetActive(selectedLoot == loot2);
        loot3.SetActive(selectedLoot == loot3);
        hasSelectedLoot = true;

        barre.SetActive(true);

        // Lancer la coroutine pour déplacer l'indicateur
        StartCoroutine(MoveIndicator());
    }

    private IEnumerator MoveIndicator() {
        while (isMoving) {
            float step = speed * Time.deltaTime;

            // Déplacement de gauche à droite
            while (indicatorRectTransform.position.x < maxX && isMoving && !isStopped) {
                Vector3 newPosition = indicatorRectTransform.position;
                newPosition.x += step;
                indicatorRectTransform.position = newPosition;

                yield return null;
            }

            // Déplacement de droite à gauche
            while (indicatorRectTransform.position.x > minX && isMoving && !isStopped) {
                Vector3 newPosition = indicatorRectTransform.position;
                newPosition.x -= step;
                indicatorRectTransform.position = newPosition;

                yield return null;
            }

            if (IsInZone()) {
                isMoving = false;
            }
        }
    }

    private bool IsInZone() {
        float indicatorX = indicatorRectTransform.position.x;
        return indicatorX >= zoneMinX && indicatorX <= zoneMaxX;
    }
}