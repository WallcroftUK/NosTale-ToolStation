local TimeSpaceReward = {}

function TimeSpaceReward.Create()
    local rewards = {
        DrawRewards = {},
        SpecialRewards = {},
        BonusRewards = {},
        DefaultReputation = false,
        FixedReputation = 0,
        ReputationLevelMultiplier = 0
    }

    function rewards.SetDrawRewards(newRewards)
        rewards.DrawRewards = newRewards
        return rewards
    end

    function rewards.SetSpecialRewards(newRewards)
        rewards.SpecialRewards = newRewards
        return rewards
    end
    
    function rewards.SetBonusRewards(newRewards)
        rewards.BonusRewards = newRewards
        return rewards
    end

    function rewards.WithDefaultReputation()
        rewards.DefaultReputation = true
        return rewards
    end
    
    function rewards.WithFixedReputation(reputation)
        rewards.FixedReputation = reputation
        return rewards
    end
    
    return rewards
end

return TimeSpaceReward;
