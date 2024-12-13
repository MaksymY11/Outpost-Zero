using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHUD : MonoBehaviour
{
    [Header("Weapon Info")]
    public TextMeshProUGUI weaponText;

    [Header("Player Stats")]
    public TextMeshProUGUI scrapText;
    public Slider playerHealthBar;
    public Gradient healthBarGradient; // Assign this in the Inspector
    public Image fill; // Reference the fill image
    public int scrapCount = 0;

    private float player_MaxHealth = 100f;
    private float player_CurHealth;

    [Header("Wave Info")]
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI enemyCountText;

    [Header("Minimap")]
    public RawImage minimapImage;

    private void Start()
    {
        player_CurHealth = player_MaxHealth;
        UpdateWeaponInfo("Plasma Rifle");
        UpdateScrapUI();
        UpdatePlayerHealth();
        Debug.Log($"Current Health: {player_CurHealth}, Slider Value: {playerHealthBar.value = player_CurHealth}");
        UpdateWaveInfo(1, 10);  // --- Placeholder
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*********************************************************************************************************************
     * The Player Health Bar section
     ***/
    public void UpdatePlayerHealth()
    {
        playerHealthBar.value = player_CurHealth / player_MaxHealth;
        if (healthBarGradient != null && fill != null)
        {
            fill.color = healthBarGradient.Evaluate(playerHealthBar.value);
        }
    }

    public void Heal(float amount)
    {
        player_CurHealth += amount;
        player_CurHealth = Mathf.Clamp(player_CurHealth, 0, player_MaxHealth);
        UpdatePlayerHealth();
    }

    public void TakeDamage(float damage)
    {
        player_CurHealth -= damage;
        player_CurHealth = Mathf.Clamp(player_CurHealth, 0, player_MaxHealth);
        UpdatePlayerHealth();

        if (player_CurHealth <= 0)
        {
            PlayerDeath(); // Trigger death screen to restart or back to main menu.
        }
    }

    private void PlayerDeath()
    {
        Debug.Log("Player has died!");
        SceneManager.LoadScene("GameOverScene");
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*********************************************************************************************************************
    * The Player Weapon Display Section
    ***/
    public void UpdateWeaponInfo(string weaponName)
    {
        weaponText.text = $"Weapon: {weaponName}";
    }


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*********************************************************************************************************************
    * The Alien Scrap currency section.
    ***/
    public void AddScrap(int amount)
    {
        scrapCount += amount;
        Debug.Log("Scrap collected! Total: " + scrapCount);
        UpdateScrapUI();
    }

    private void UpdateScrapUI()
    {
        if (scrapText != null)
        {
            scrapText.text = $"Alien Scrap: {scrapCount}";
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*********************************************************************************************************************
    * The Alien Sections
    ***/
    //public void UpdateEnemyHealth(float currentHealth, float maxHealth)
    //{
    //    if (maxHealth <= 0)
    //    {
    //        enemyHealthBar.gameObject.SetActive(false);
    //    }
    //    else
    //    {
    //        enemyHealthBar.gameObject.SetActive(true);
    //        enemyHealthBar.value = currentHealth / maxHealth;
    //    }
    //}

    public void UpdateWaveInfo(int currentWave, int enemiesRemaining)
    {
        waveText.text = $"Wave: {currentWave}";
        enemyCountText.text = $"Enemies Left: {enemiesRemaining}";
    }
}

