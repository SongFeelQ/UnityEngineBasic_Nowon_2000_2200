using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ProjectileRocket : Projectile
{
    [SerializeField] private ParticleSystem _explosionEffect;
    private float _explosionRange;

    protected override void OnTriggerEnter(Collider other)
    {
        if (1 << other.gameObject.layer == targetLayer ||
            1 << other.gameObject.layer == touchLayer)
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, _explosionRange, Vector3.zero, 0, targetLayer);

            for (int i = 0; i < hits.Length; i++)
            {
                if (other.gameObject.TryGetComponent(out Enemy enemy))
                {
                    enemy.hp -= (int) (_explosionRange - Vector3.Distance(transform.position, enemy.transform.position));
                    GameObject effect = ObjectPool.instance.Spawn("BulletExplosionEffect", tr.position, Quaternion.LookRotation(tr.position - target.position));
                    ObjectPool.instance.Return(effect, _explosionEffect.main.duration + _explosionEffect.main.startLifetime.constant);
                    ObjectPool.instance.Return(this.gameObject);
                }
            }            
        }
    }
}
