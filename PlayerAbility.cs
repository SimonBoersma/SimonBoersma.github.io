using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerAbility : MonoBehaviour
{
    Customization custom;
    GlobalVariables variables;
    EnemyBossSpawn bossSpawn;
    PlayerShoot playerShoot;
    Animator animator;
    [SerializeField] AudioClip knifeSound;

    [SerializeField] GameObject fireGrenadePrefab;
    [SerializeField] GameObject iceGrenadePrefab;
    [SerializeField] GameObject poisonGrenadePrefab;

    [SerializeField] AudioClip nightVision;
    private bool isNightVisionPlayed = false;

    [SerializeField] GameObject abilityBar;
    [SerializeField] Image abilityTimeBar;

    [SerializeField] GameObject knifeHitbox;

    [SerializeField] GameObject turret;

    [SerializeField] float abilityTime = 5f;
    [SerializeField] float rechargeTime = 5f;
    private float timer = 0f;

    [SerializeField] float nightVisionTime = 1f;
    private float nightVisionTimer = 0f;

    [SerializeField] TextMeshProUGUI gKeyText;

    public bool isRecharging;

    public bool isCloakActive;
    public bool isKnifeActive;
    public bool isArmorActive;
    public bool isGrenadeActive;
    public bool isHackActive;
    public bool isTurretActive;


    void Start()
    {
        custom = FindFirstObjectByType<Customization>();
        variables = FindFirstObjectByType<GlobalVariables>();
        bossSpawn = FindFirstObjectByType<EnemyBossSpawn>();
        playerShoot = GetComponent<PlayerShoot>();
        animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        if (!custom.ability)
        {
            abilityBar.SetActive(false);
            return;
        }

        abilityBar.SetActive(true);

        // Ability activeren
        if (variables.isIntro) return;

        if (custom.cloak)
        {
            CloakerAbility();
        }
        if (custom.knife)
        {
            KnifeAbility();
        }
        if (custom.armor)
        {
            ArmorAbility();
        }
        if (custom.grenade)
        {
            GrenadeAbility();
        }
        if (custom.hack)
        {
            HackAbility();
        }
        if (custom.turret)
        {
            TurretAbility();
        }
    }

    private IEnumerator AnimateGKeyText()
    {
        float duration = 0.2f;
        Vector3 originalScale = gKeyText.transform.localScale;
        Vector3 smallScale = originalScale * 0.5f;

        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            gKeyText.transform.localScale = Vector3.Lerp(originalScale, smallScale, t / duration);
            yield return null;
        }

        t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            gKeyText.transform.localScale = Vector3.Lerp(smallScale, originalScale, t / duration);
            yield return null;
        }
    }

    private void CloakerAbility()
    {
        abilityTime = 10;
        rechargeTime = 20;

        // Ability activeren
        if (Input.GetKeyDown(KeyCode.G) && !isCloakActive && !isRecharging)
        {
            isCloakActive = true;
            timer = abilityTime;

            StartCoroutine(AnimateGKeyText());
        }

        if (isCloakActive)
        {
            timer -= Time.deltaTime;
            abilityTimeBar.fillAmount = timer / abilityTime;

            if (timer <= 0f)
            {
                isCloakActive = false;
                isRecharging = true;
                timer = 0f;
            }
        }
        else if (isRecharging)
        {
            timer += Time.deltaTime;
            abilityTimeBar.fillAmount = timer / rechargeTime;

            if (timer >= rechargeTime)
            {
                isRecharging = false;
                timer = 0f;
            }
        }
    }

    private void KnifeAbility()
    {
        abilityTime = 0.7f;
        rechargeTime = 0.5f;

        if (Input.GetKeyDown(KeyCode.G) && !isKnifeActive && !isRecharging)
        {
            StartCoroutine(AnimateGKeyText());
            animator.SetBool("Knife", true);
            playerShoot.audioSource.PlayOneShot(knifeSound);
            isKnifeActive = true;
            timer = abilityTime;

            knifeHitbox.SetActive(true); // Slashbox aan
        }

        if (isKnifeActive)
        {
            timer -= Time.deltaTime;
            abilityTimeBar.fillAmount = timer / abilityTime;

            if (timer <= 0f)
            {
                animator.SetBool("Knife", false);
                isKnifeActive = false;
                isRecharging = true;
                timer = 0f;

                knifeHitbox.SetActive(false); // Slashbox weer uit
            }
        }
        else if (isRecharging)
        {
            timer += Time.deltaTime;
            abilityTimeBar.fillAmount = timer / rechargeTime;

            if (timer >= rechargeTime)
            {
                isRecharging = false;
                timer = 0f;
            }
        }
    }


    private void ArmorAbility()
    {
        abilityTime = 10;
        rechargeTime = 15;

        // Ability activeren
        if (Input.GetKeyDown(KeyCode.G) && !isArmorActive && !isRecharging)
        {
            isArmorActive = true;
            timer = abilityTime;

            StartCoroutine(AnimateGKeyText());
        }

        if (isArmorActive)
        {
            timer -= Time.deltaTime;
            abilityTimeBar.fillAmount = timer / abilityTime;

            if (timer <= 0f)
            {
                isArmorActive = false;
                isRecharging = true;
                timer = 0f;
            }
        }
        else if (isRecharging)
        {
            timer += Time.deltaTime;
            abilityTimeBar.fillAmount = timer / rechargeTime;

            if (timer >= rechargeTime)
            {
                isRecharging = false;
                timer = 0f;
            }
        }
    }

    private void GrenadeAbility()
    {
        abilityTime = 1f;
        rechargeTime = 5f;

        if (Input.GetKeyDown(KeyCode.G) && !isGrenadeActive && !isRecharging)
        {
            isGrenadeActive = true;
            timer = abilityTime;

            StartCoroutine(AnimateGKeyText());

            GameObject chosenGrenade = GetRandomGrenade();

            Vector3 spawnPos = transform.position;

            GameObject grenade = Instantiate(chosenGrenade, spawnPos, Quaternion.identity);

            PlayerGrenadeController grenadeController = grenade.GetComponent<PlayerGrenadeController>();
            if (grenadeController != null)
            {
                string grenadeType = GetGrenadeTypeFromPrefab(chosenGrenade);
                grenadeController.Initialize(transform.position, grenadeType);
            }
        }

        if (isGrenadeActive)
        {
            timer -= Time.deltaTime;
            abilityTimeBar.fillAmount = timer / abilityTime;

            if (timer <= 0f)
            {
                isGrenadeActive = false;
                isRecharging = true;
                timer = 0f;
            }
        }
        else if (isRecharging)
        {
            timer += Time.deltaTime;
            abilityTimeBar.fillAmount = timer / rechargeTime;

            if (timer >= rechargeTime)
            {
                isRecharging = false;
                timer = 0f;
            }
        }
    }

    private GameObject GetRandomGrenade()
    {
        int randomIndex = Random.Range(0, 3);
        switch (randomIndex)
        {
            case 0: return fireGrenadePrefab;
            case 1: return iceGrenadePrefab;
            case 2: return poisonGrenadePrefab;
            default: return fireGrenadePrefab;
        }
    }

    private string GetGrenadeTypeFromPrefab(GameObject grenadePrefab)
    {
        if (grenadePrefab == fireGrenadePrefab)
            return "Fire";
        else if (grenadePrefab == iceGrenadePrefab)
            return "Ice";
        else if (grenadePrefab == poisonGrenadePrefab)
            return "Poison";
        else
            return "";
    }

    private void HackAbility()
    {
        abilityTime = 15;
        rechargeTime = 25;

        // Ability activeren
        if (Input.GetKeyDown(KeyCode.G) && !isHackActive && !isRecharging)
        {
            isHackActive = true;
            timer = abilityTime;

            StartCoroutine(AnimateGKeyText());

            TurnLights(false);
        }

        if (isHackActive)
        {
            variables.globalLight.intensity = 0f;

            nightVisionTimer += Time.deltaTime;

            if (nightVisionTimer > nightVisionTime)
            {
                if (!isNightVisionPlayed)
                {
                    playerShoot.audioSource.PlayOneShot(nightVision);
                    isNightVisionPlayed = true;
                }
                variables.globalLight.intensity = 0.3f;
                variables.globalLight.color = new Color(0f, 1f, 0f, 1f);
            }

            timer -= Time.deltaTime;
            abilityTimeBar.fillAmount = timer / abilityTime;

            if (timer <= 0f)
            {
                isHackActive = false;
                isRecharging = true;


                nightVisionTimer = 0f;
                isNightVisionPlayed = false;

                if (bossSpawn.isYagaActive)
                {
                    variables.globalLight.intensity = 0f;
                    variables.globalLight.color = variables.originalGlobalColor;
                }
                else
                {
                    TurnLights(true);
                    variables.globalLight.intensity = 0.5f;
                    variables.globalLight.color = variables.originalGlobalColor;
                }

                timer = 0f;
            }
        }
        else if (isRecharging)
        {
            timer += Time.deltaTime;
            abilityTimeBar.fillAmount = timer / rechargeTime;

            if (timer >= rechargeTime)
            {
                isRecharging = false;
                timer = 0f;
            }
        }
    }

    private void TurnLights(bool lightSwitch)
    {
        GameObject[] taggedLights = GameObject.FindGameObjectsWithTag("Light");

        foreach (GameObject lightObject in taggedLights)
        {
            Light2D light = lightObject.GetComponent<Light2D>();
            if (light != null)
            {
                light.enabled = lightSwitch;
            }
        }
    }

    private void TurretAbility()
    {
        abilityTime = 1;
        rechargeTime = 20;

        // Ability activeren
        if (Input.GetKeyDown(KeyCode.G) && !isTurretActive && !isRecharging)
        {
            isTurretActive = true;
            timer = abilityTime;

            StartCoroutine(AnimateGKeyText());

            Instantiate(turret, transform.position, Quaternion.identity);
        }

        if (isTurretActive)
        {
            timer -= Time.deltaTime;
            abilityTimeBar.fillAmount = timer / abilityTime;

            if (timer <= 0f)
            {
                isTurretActive = false;
                isRecharging = true;
                timer = 0f;
            }
        }
        else if (isRecharging)
        {
            timer += Time.deltaTime;
            abilityTimeBar.fillAmount = timer / rechargeTime;

            if (timer >= rechargeTime)
            {
                isRecharging = false;
                timer = 0f;
            }
        }
    }
}
