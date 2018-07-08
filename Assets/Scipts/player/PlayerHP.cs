using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int StartingHealth = 100;
    public int CurrentHealth;
    public Slider HealthSlider;
    public Image DamageImage;
    public float FlashSpeed = 5f;
    public Color FlashColour = new Color(1f, 0f, 0f, 0.1f);
    public float BuffShieldActiveTime = 30;


    private Animator _anim;
    private PlayerContoller _playerContollerl;
    private GameObject[] _playerShootings;
    private bool _isDead;
    private bool _damaged;
    private bool _buffShield;
    private ParticleSystem _shieldParticles;
    private float _shieldTimer;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _playerContollerl = GetComponent<PlayerContoller>();
        _playerShootings = GameObject.FindGameObjectsWithTag("Gun");
        CurrentHealth = StartingHealth;
        HealthSlider.value = CurrentHealth;
        _shieldParticles = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        DamageImage.color =
            _damaged ? FlashColour : Color.Lerp(DamageImage.color, Color.clear, FlashSpeed * Time.deltaTime);
        _damaged = false;
        if (_buffShield)
        
            _shieldTimer += Time.deltaTime;
        

        if (!(_shieldTimer >= BuffShieldActiveTime)) return;
        _buffShield = false;
        _shieldParticles.Stop();
    }

    public void TakeDamage(int amount)
    {
        if (_buffShield)
            return;
        _damaged = true;
        CurrentHealth -= amount;
        HealthSlider.value = CurrentHealth;
        if (CurrentHealth <= 0 && !_isDead)
            Death();
    }

    private void Death()
    {
        _anim.SetTrigger("Die");
        _isDead = true;
        _playerContollerl.enabled = false;
        Destroy(_playerShootings[0]);
        Destroy(_playerShootings[1]);
    }

    public void PickUpBuffRecoverHp()
    {
        CurrentHealth = 100;
        HealthSlider.value = CurrentHealth;
    }

    public void PickUpBuffShieldP()
    {
        _buffShield = true;
        _shieldParticles.Play();
    }
}