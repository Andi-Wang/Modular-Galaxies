using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour {
    protected float maxHealth;
    protected float maxEnergy;
    protected float energyRegen;
    public float energyType { protected set; get; }
    protected float speed;
    protected float engineType;
    protected float weaponDamage;
    protected float weaponDrain;
    protected float weaponMaxCooldown;
    protected float specialDrain;
    protected float specialMaxCooldown;

    protected float health;
    protected float energy;
    protected float weaponCooldown;
    protected float specialCooldown;

    public GameObject weaponPrefab;
    public GameObject specialPrefab;
    protected int specialTier;

    protected GameObject HUD;
    protected Image healthbar;
    protected Image energybar;
    protected Text healthText;
    protected Text energyText;

    protected void Awake() {
        HUD = GameObject.Find("HUD");
        healthbar = HUD.transform.Find("Canvas").Find("Healthbar").Find("Health").GetComponent<Image>();
        healthText = HUD.transform.Find("Canvas").Find("Healthbar").Find("HealthText").GetComponent<Text>();
        energybar = HUD.transform.Find("Canvas").Find("Energybar").Find("Energy").GetComponent<Image>();
        energyText = HUD.transform.Find("Canvas").Find("Energybar").Find("EnergyText").GetComponent<Text>();
    }

   protected virtual void FixedUpdate() {
        weaponCooldown -= Time.fixedDeltaTime;
        specialCooldown -= Time.fixedDeltaTime;

        if (energyType == Energy.SOLAR) {
            addEnergy(energyRegen * Time.fixedDeltaTime);
        }
    }


    public void move(UnityStandardAssets._2D.PlayerInput.Input input) {
        if(input.fireDown || input.fireHold) {
            useWeapon();
        }
        if(specialCheck(input.specialDown, input.specialHold)) {
            useSpecial();
        }

        gameObject.transform.position += new Vector3(input.horizontal * speed * Time.fixedDeltaTime, input.vertical * speed * Time.fixedDeltaTime, 0);
    }

    public void clampToCameraBound(Camera camera) {
        Vector3 sprite = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.max;
        //Sprite is rotated 90 degrees, so x and y are reversed
        sprite = new Vector3(sprite.y * gameObject.transform.localScale.y, sprite.x * gameObject.transform.localScale.x);

        Vector3 edge = new Vector3((float)Screen.width / (float)Screen.height * camera.orthographicSize, camera.orthographicSize);
        Vector3 pos = camera.transform.position;

        float x = Mathf.Clamp(gameObject.transform.position.x, pos.x - edge.x + sprite.x, pos.x + edge.x - sprite.x);
        float y = Mathf.Clamp(gameObject.transform.position.y, pos.y - edge.y + sprite.y, pos.y + edge.y - sprite.y);
        gameObject.transform.position = new Vector3(x, y);
    }

    protected virtual bool specialCheck(bool specialDown, bool specialHold) {
        return specialDown || specialHold;
    }


    protected virtual void weaponEffect() {
        //Debug.Log("Weapon activated!");
        GameObject projectile = SimplePool.Spawn(weaponPrefab, transform.position, new Quaternion());
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
        projectile.GetComponent<ProjectileController>().setDamage(weaponDamage);
    }
    protected virtual void specialEffect() {
        Debug.Log("Special activated!");
    }

    public void takeDamage(float amount) {
        health -= amount;
        healthbar.fillAmount = health / maxHealth;
        healthText.text = Mathf.Round(health) + " / " + maxHealth;

        if(health <= 0) {
            //Player dies
        }
    }
    public void addEnergy(float amount) {
        energy = Mathf.Min(energy + amount, maxEnergy);
        energybar.fillAmount = energy / maxEnergy;
        energyText.text = Mathf.Round(energy) + " / " + maxEnergy;
    }

    public bool energyCost(float amount) {
        if (energy >= amount) {
            energy -= amount;
            energybar.fillAmount = energy / maxEnergy;
            energyText.text = Mathf.Round(energy) + " / " + maxEnergy;
            return true;
        }
        else return false;
    }

    protected virtual void useWeapon() {
        if(weaponCooldown <= 0 && energyCost(weaponDrain)) {
            weaponEffect();
            weaponCooldown = weaponMaxCooldown;
        }
    }
    protected virtual void useSpecial() {
        if(specialCooldown <= 0 && energyCost(specialDrain)) {
            specialEffect();
            specialCooldown = specialMaxCooldown;
        }        
    }

    // Design for engine functionality still incomplete
    public void useEngine() {
        if(engineType == Engine.FIRE) {
            Debug.Log("Fire engine activated!");
        }
        else if(engineType == Engine.WIND) {
            Debug.Log("Wind engine activated!");
        }
    }

    public void setStatistics(int frame, int engine, int energy, int armor, int weapon, int special) {
        maxHealth = Frame.health(frame);
        maxEnergy = Energy.capacity(energy);
        energyRegen = Energy.regen(energy);
        energyType = Energy.type(energy);
        speed = Engine.speed(engine, Frame.weight(frame), Frame.size(frame));
        engineType = Engine.type(engine);
        weaponDamage = Weapon.damage(weapon);
        weaponDrain = Weapon.drain(weapon);
        weaponMaxCooldown = Weapon.cooldown(weapon);
        specialDrain = Special.drain(special);
        specialMaxCooldown = Special.cooldown(special);

        health = maxHealth;
        this.energy = maxEnergy;
        energybar.fillAmount = 1;
        healthbar.fillAmount = 1;
        energyText.text = maxEnergy + " / " + maxEnergy;
        healthText.text = maxHealth + " / " + maxHealth;

        weaponCooldown = 0;
        specialCooldown = 0;

        specialTier = special;
    }
}
