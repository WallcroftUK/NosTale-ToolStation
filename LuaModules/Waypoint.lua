local Waypoint = {}

function Waypoint.Create()
    local waypoint =
    {
        X = 0,
        Y = 0,
        WaitTime = 0
    }
    
    function waypoint.At(x, y)
        waypoint.X = x
        waypoint.Y = y
        return waypoint
    end
    
    function waypoint.WithWait(milliseconds)
        waypoint.WaitTime = milliseconds
        return waypoint
    end
    
    return waypoint
end

return Waypoint;
