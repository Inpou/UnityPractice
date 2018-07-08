using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public int DamagePerShot = 10;
    public float BulletFiringDelay = 0.15f;
    public float ShootingDistance = 100f;
    public float EffectsDisplayTime = 0.2f;
    public bool IsRightGun;
    public float BuffTimeEnable = 15f;
    public Color BuffLineColor = new Color(246f, 79f, 72f, 255f);
    public bool Buff_2XDamage;

    private Color _originalLineColor;
    private Material _lineRenderMaterial;
    private string _fireKey;
    private LineRenderer _lineRenderer;
    private Light _gunFlash;
    private float _timer;
    private float _buffTimer;
    private Ray _shootRay;
    private RaycastHit _shootHit;
    private int _shootableMask;

    private void Awake()
    {
        _shootableMask = LayerMask.GetMask("ShootAble");
        _lineRenderer = GetComponent<LineRenderer>();
        _gunFlash = GetComponent<Light>();
        _fireKey = IsRightGun ? "Fire2" : "Fire1";
        _originalLineColor = _lineRenderer.materials[0].color;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (Buff_2XDamage)
        {
           
            _lineRenderer.materials[0].color = BuffLineColor;
            _buffTimer += Time.deltaTime;
            if (_buffTimer >= BuffTimeEnable)
            {
                _lineRenderer.materials[0].color = _originalLineColor;
                Buff_2XDamage = false;
                _buffTimer = 0f;
              

            }
        }

        if (Input.GetButton(_fireKey) && _timer >= BulletFiringDelay)
            Shoot();
        if (_timer >= BulletFiringDelay * EffectsDisplayTime)
            DisableEffects();
    }

    private void DisableEffects()
    {
        _lineRenderer.enabled = false;
        _gunFlash.enabled = false;
    }

    private void Shoot()
    {
        _timer = 0f;

        _gunFlash.enabled = true;
        
        _lineRenderer.enabled = true;
        _lineRenderer.SetPosition(0, transform.position);

        _shootRay.origin = transform.position;
        _shootRay.direction = transform.forward;
        Debug.Log(DamagePerShot * (Buff_2XDamage ? 2 : 1));
        if (Physics.Raycast(_shootRay, out _shootHit, ShootingDistance, _shootableMask))
        {
            EnemyHP enemyHealth = _shootHit.collider.GetComponent<EnemyHP>();

            if (enemyHealth != null)
                enemyHealth.TakeDamage(DamagePerShot * (Buff_2XDamage ? 2 : 1));
            _lineRenderer.SetPosition(1, _shootHit.point);
        }
        else
            _lineRenderer.SetPosition(1, _shootRay.origin + _shootRay.direction * ShootingDistance);
    }
}