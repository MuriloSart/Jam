﻿using System.Collections.Generic;
using Entities;

public class AlliesManager : Singleton<AlliesManager>
{
    public List<Entity> allies;

    private void OnEnable()
    {
        if (allies != null)
        {
            foreach(var entity in allies)
            {
                entity.OnAbilityUsed += HandleAbilityUsed;
            }
        }
    }

    private void OnDisable()
    {
        if (allies != null)
        {
            foreach (var entity in allies)
            {
                entity.OnAbilityUsed -= HandleAbilityUsed;
            }
        }
    }

    private void HandleAbilityUsed(Entity entity)
    {
        //fazer com que colete entidades com a interface ICaptureAbilities
    }
}