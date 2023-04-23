local RaidDrop = {}

function RaidDrop.Create(boss) 
    local raidDrops = 
    {
        BossId = boss.Id,
        Drops = {},
        DropsStackCount = 0,
        GoldRange = {
            Minimum = 0,
            Maximum = 0
        },
        GoldStackCount = 0
    }
    
    function raidDrops.WithDrops(drops) 
        raidDrops.Drops = drops
        return raidDrops
    end
    
    function raidDrops.WithDropsStackCount(count) 
        raidDrops.DropsStackCount = count
        return raidDrops
    end
    
    function raidDrops.WithGoldRange(min, max) 
        raidDrops.GoldRange.Minimum = min
        raidDrops.GoldRange.Maximum = max
        
        return raidDrops
    end
    
    function raidDrops.WithGoldStackCount(count) 
        raidDrops.GoldStackCount = count
        return raidDrops
    end
    
    return raidDrops
end

return RaidDrop;