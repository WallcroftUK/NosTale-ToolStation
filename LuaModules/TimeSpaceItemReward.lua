local TimeSpaceItemReward = {}

function TimeSpaceItemReward.Create(itemVnum, amount)
    local rewards = {
        ItemVnum = itemVnum,
        Quantity = amount or 1
    }
    
    return rewards
end

return TimeSpaceItemReward;
