using System.Collections;
using Characters;
using CommonEnums;
using Data;
using Magic;
using Magic.Spells;
using UnityEngine;
using Zenject;

public class AutoAttackSpawner : MonoBehaviour
{
    private AutoAttack.Factory _autoAttackFactory;
    private MainCharacter _player;
    private SpellConfig _conf;
    private PlayerData _playerData;
    private Collider2D[] _collidedMonsters = new Collider2D[1];

    [Inject]
    public void Init(AutoAttack.Factory factory, MainCharacter player, SpellConfig config, PlayerData playerData)
    {
        _autoAttackFactory = factory;
        _player = player;
        _conf = config;
        _playerData = playerData;
    }

    private void Start()
    {
        StartCoroutine(TryTargetEnemy());
    }

    private IEnumerator TryTargetEnemy()
    {
        LayerMask mask = LayerMask.GetMask("Monsters");
        while (true)
        {
            yield return null;
            var hitNum =
                Physics2D.OverlapCircleNonAlloc(_player.transform.position, _conf.AutoAttackRange, _collidedMonsters, mask);
            if (hitNum > 0)
            {
                yield return CreateSpell(_collidedMonsters[0].gameObject);
                yield return new WaitForSeconds(_conf.AutoAttackCooldown);
            }
        }
    }

    private IEnumerator CreateSpell(GameObject target)
    {
        foreach (var autoattackElement in _playerData.SpellSetup[SpellType.AutoAttack])
        {
            var targetPos = target.transform.position;
            yield return new WaitForSeconds(0.05f);
            _autoAttackFactory.Create(
                new AutoAttack.AutoAttackInfo
                {
                    Origin = _player.transform.position,
                    Target = targetPos,
                    Element = autoattackElement
                });
        }
    }
}