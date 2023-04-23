local DropChance = {}

function DropChance.Create(vnum, amount, chance)
    local dropChance = 
    {
        ItemVnum = vnum,
        Amount = amount,
        Chance = chance
    }
    
    return dropChance
end

return DropChance;
