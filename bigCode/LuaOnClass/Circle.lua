require("day04")
local Shape=require("Shape")
local Circle=class("Circle",Shape)
function Circle:ctor()
	Circle.super.ctor(self,"circle")
	self.radius=100
end

function Circle:setRadius(radius)
	self.radius=radius
end
function Circle:draw()
	printf("draw%s,radius=%0.2f",self.shapeName,self.radius)
end
return Circle 

