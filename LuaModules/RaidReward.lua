local RaidReward = {}

function RaidReward.Create() 
    local raidReward =
    {
        RaidBox = nil,
        DefaultReputation = false,
        FixedReputation = nil,
    }
    
    function raidReward.WithRaidBox(raidBox)
        raidReward.RaidBox = raidBox
        return raidReward
    end
    
    function raidReward.WithDefaultReputation() 
        raidReward.DefaultReputation = true
        return raidReward
    end
    
    function raidReward.WithFixedReputation(reputation)
        raidReward.FixedReputation = reputation
        return raidReward
    end
    
    return raidReward
end

return RaidReward;
