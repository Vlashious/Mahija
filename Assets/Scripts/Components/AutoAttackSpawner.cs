using System.Collections;
using Characters;
using Magic;
using Magic.Spells;
using UnityEngine;
using Zenject;

public class AutoAttackSpawner : MonoBehaviour
{
    private AutoAttack.Factory _autoAttackFactory;
    private MainCharacter _player;
    private SpellConfig _conf;

    [Inject]
    public void Init(AutoAttack.Factory factory, MainCharacter player, SpellConfig config)
    {
        _autoAttackFactory = factory;
        _player = player;
        _conf = config;
    }

    private void Start()
    {
        StartCoroutine(TryTargetEnemy());
    }

    private IEnumerator TryTargetEnemy()
    {
        Collider2D[] others = new Collider2D[1];
        LayerMask mask = LayerMask.GetMask("Monsters");
        while (true)
        {
            yield return null;
            var hitNum =
                Physics2D.OverlapCircleNonAlloc(_player.transform.position, _conf.AutoAttackRange, others, mask);
            if (hitNum > 0)
            {
                CreateSpell(others[0].gameObject);
                yield return new WaitForSeconds(_conf.AutoAttackCooldown);
            }
        }
    }

    private void CreateSpell(GameObject target)
    {
        _autoAttackFactory.Create(
            new AutoAttack.AutoAttackInfo
            {
                Origin = _player.transform.position,
                Target = target.transform.position,
            });
    }
}