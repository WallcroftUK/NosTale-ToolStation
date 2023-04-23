local RaidBox = {}

function RaidBox.Create() 
    local raidBox =
    {
        RewardBox = 0,
        RaidBoxRarity = {}
    }
    
    function raidBox.WithVnum(itemVnum)
        raidBox.RewardBox = itemVnum
        return raidBox
    end
    
    function raidBox.WithBoxRarity(raidBoxRarity)
        if (raidBoxRarity == nil) then
            return raidBox
        end
        
        table.insert(raidBox.RaidBoxRarity, raidBoxRarity)
        return raidBox
    end
    
    return raidBox
end

return RaidBox;
