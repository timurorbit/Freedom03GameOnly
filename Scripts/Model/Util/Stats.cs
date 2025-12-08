using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats
{
    public Rank rank;
    [SerializeField] public List<SkillType> skills;
    public int baseReward;

    public Stats(Rank rank, List<SkillType> skills, int baseReward)
    {
        this.rank = rank;
        this.skills = skills;
        this.baseReward = baseReward;
    }

    public Stats(Stats stats)
    {
        rank = stats.rank;
        skills = new List<SkillType>(stats.skills);
        baseReward = stats.baseReward;
    }
}