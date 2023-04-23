local RewardType = require('RewardType')
local Reward = {}

function Reward.Gold(quantity)
    local rewards =
    {
        Type = RewardType.Gold,
        Quantity = quantity
    }
    
    return rewards
end

function Reward.Reputation(quantity)
    local rewards =
    {
        Type = RewardType.Reputation,
        Quantity = quantity
    }
    
    return rewards
end

function Reward.NewItem(vnum)
    local rewards =
    {
        Type = RewardType.Item,
        ItemVnum = vnum,
        Quantity = 1
    }
    
    function rewards.WithQuantity(quantity)
        rewards.Quantity = quantity
        return rewards
    end
    return rewards
end

function Reward.NewRewards()
    local rewards = {}
    
    function rewards.Add(reward)
        table.insert(rewards, reward)
        return rewards
    end
    
    return rewards
end

return Reward;
