local Position = require('Position')

local Location = {}

function Location.InMap(map)
    local location =
    {
        MapId = map.Id,
        Position = nil
    }
    
    function location.At(x, y)
        location.Position = Position.At(x, y)
        return location
    end
    
    return location
end

return Location;
