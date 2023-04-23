local Drop = {}

function Drop.Create(vnum, amount) 
    local drop = 
    {
        ItemVnum = vnum,
        Amount = amount
    }
    
    return drop
end

return Drop;
