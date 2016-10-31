require("day04")
local Shape=require("Shape")
local Rectangle=class("Rectangle",Shape)
function Rectangle:ctor()
	Rectangle.super.ctor(self,"rectangle")
	self.chang=100
	self.kuan=50
end
function Rectangle:setCK(chang,kuan)
	self.chang=chang
	self.kuan=kuan
end
function Rectangle:draw()
	printf("chang%f,kuan%f",self.chang,self.kuan)
end
return Rectangle 