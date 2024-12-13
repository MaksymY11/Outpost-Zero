using UnityEngine;
using TMPro; // Or TMPro for TextMeshPro

public class Scrap : MonoBehaviour
{
    public int scrapValue = 1; // The amount of scrap this object gives
    public TextMeshProUGUI scrapText; // Use this if using TextMeshPro

    private static int scrapCount = 0; // Keep track of total scrap collected

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to a GameObject with the "Player" tag
        if (other.CompareTag("Player"))
        {
            CollectScrap();
        }
    }

    private void CollectScrap()
    {
        // Increment scrap count
        scrapCount += scrapValue;

        // Update the UI
        if (scrapText != null)
        {
            scrapText.text = $"Alien Scrap: {scrapCount}";
        }

        // Optionally play a sound or visual effect here
        Debug.Log($"Scrap collected! Total: {scrapCount}");

        // Destroy the scrap object after it's picked up
        Destroy(gameObject);
    }
}