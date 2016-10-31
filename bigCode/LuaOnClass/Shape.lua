require("day04")
local Shape=class("Shape")
function Shape:ctor(shapeName)
	self.shapeName=shapeName
	print(self.shapeName)
	printf("Shape:ctor(%s)",self.shapeName)
end
function Shape:draw()
	printf("draw %s",self.shapeName)
end

-- local sh=Shape.new("sanjiaoxing")
-- sh:draw()
return Shape 
