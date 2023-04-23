local Random = {}

function Random.InArray(array)
    assert(type(array) == 'table', 'bad parameter #1: must be table')
    local count = 0
    for _ in pairs(array) do count = count + 1 end
    assert(count > 0, "length == " .. count)

    local index = math.random(count)
    assert(index > 0, "index == 0")
    return array[index]
end

return Random;
