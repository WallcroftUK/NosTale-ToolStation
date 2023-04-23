local UUID = require('UUID')
local Position = require('Position')
local PortalType = require('PortalType')
local PortalMinimapOrientation = require('PortalMinimapOrientation')

local Portal = {}

function Portal.Create(portalType) 
    local portal = 
    {
        Id = UUID.Generate(),
        Type = portalType,
        SourceId = nil,
        DestinationId = nil,
        SourcePosition = nil,
        DestinationPosition = nil,
        CreationDelay = nil,
        IsReturn = false,
        PortalMiniMapOrientation = PortalMinimapOrientation.North
    }
    
    function portal.From(sourceMap, x, y) 
        portal.SourceId = sourceMap.Id
        portal.SourcePosition = Position.At(x, y)
        
        return portal
    end
    
    function portal.To(destinationMap, x, y) 
        portal.DestinationId = destinationMap.Id
        portal.DestinationPosition = Position.At(x, y)
        
        return portal
    end
    
    function portal.WithDelay(delayInSeconds)
        portal.CreationDelay = delayInSeconds
        
        return portal
    end
    
    function portal.AsReturn()
        portal.IsReturn = true
        
        return portal
    end

    function portal.MinimapOrientation(minimapOrientation)
        portal.PortalMiniMapOrientation = minimapOrientation
        return portal
    end
    
    return portal
end

function Portal.CreateLocked() 
    return Portal.Create(PortalType.Locked)
end

return Portal;
