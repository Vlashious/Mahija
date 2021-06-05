using System.Collections;
using Characters;
using Magic.Spells;
using UnityEngine;
using Zenject;

public class AutoAttackSpawner : MonoBehaviour
{
    [SerializeField] private float _cooldown;
    [SerializeField] private float _range;

    private AutoAttack.Factory _autoAttackFactory;
    private MainCharacter _player;

    [Inject]
    public void Init(AutoAttack.Factory factory, MainCharacter player)
    {
        _autoAttackFactory = factory;
        _player = player;
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
            yield return new WaitForSeconds(_cooldown);
            var hitNum = Physics2D.OverlapCircleNonAlloc(_player.transform.position, _range, others, mask);
            if (hitNum > 0)
            {
                CreateSpell(others[0].gameObject);
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
                Speed = Random.Range(5f, 10f)
            });
    }
}