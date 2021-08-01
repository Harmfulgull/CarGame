using System.Collections.Generic;
using UnityEngine;

public class AbilityRepository : BaseController, IRepository<int, IAbility>
{
    public IReadOnlyDictionary<int, IAbility> Collection => _abilitiesMapById;

    private Dictionary<int, IAbility> _abilitiesMapById = new Dictionary<int, IAbility>();

    public AbilityRepository(List<AbilityItemConfig> abilityItemConfig)
    {
        PopulateItems(abilityItemConfig);
    }

    protected override void OnDispose()
    {
        _abilitiesMapById.Clear();
    }

    private void PopulateItems(List<AbilityItemConfig> configs)
    {
        foreach (var config in configs)
        {
            if (_abilitiesMapById.ContainsKey(config.Id))
                continue;
            _abilitiesMapById.Add(config.Id, CreateAbility(config));
        }
    }

    private IAbility CreateAbility(AbilityItemConfig config)
    {
        switch (config.AbilityType) 
        {
            case AbilityType.Bomb:
                return new BombAbility(config);
            default:
                Debug.Log($"Not type ability");
                return null;
            
        }
    }
}
