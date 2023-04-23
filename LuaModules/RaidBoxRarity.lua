local RaidBoxRarity = {}

function RaidBoxRarity.CreateBoxRarity()
    local raidBoxRarity =
    {
        Rarity = 0,
        Chance = 0
    }
    
    function raidBoxRarity.WithRarity(rarity)
        if (rarity == nil) then
            return raidBoxRarity
        end
        
        raidBoxRarity.Rarity = rarity
        return raidBoxRarity
    end
    
    function raidBoxRarity.WithChance(chance)
        if (chance == nil) then
            return raidBoxRarity
        end
        
        raidBoxRarity.Chance = chance
        return raidBoxRarity
    end
    
    return raidBoxRarity
end

return RaidBoxRarity;
