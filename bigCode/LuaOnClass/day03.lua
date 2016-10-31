--元表
-- t={}
-- print(getmetatable(t))
-- local mt={x=3,y=4}
-- setmetatable(t,mt)
-- print(getmetatable(t).x)


-- local t1={}
-- local t2={}
-- local mt={
-- 	__add=function(t1,t2)
-- print("Add called")
-- end
-- }
-- setmetatable(t1,mt)
-- setmetatable(t2,mt)
-- local result=t1+t2
--如果第一个值有元表，就以这个元表为准，否者第二个值有元表就以第二个为准，都没有就回报错，如果具有不同元表的值进行操作，就回报错
-- __sub __mul __div __eq __it（小于） __ie(小于等于)





-- local t={name="wanwan"}
-- local t1={money=9000000}
-- local t2={sex=2}
-- local mt1={
-- 	__index=t2
-- }
-- setmetatable(t1,mt1)
-- local mt={       					--当做父类
-- 	-- __index=function(table,key)
-- 	-- print(key)
-- -- end
-- __index=t1
-- }
-- setmetatable(t,mt)





-- local smartMan={
-- 	name="aaa",age=20,sayhello=function()
-- print("sayhello")
-- end
-- }
-- local t1={}
-- local t2={}
-- local mt={
-- 	__index=smartMan,
-- 	-- __newindex=function(t,k,v)
--  --      print("dont fuzhi")
     
--  --   end
--  __newindex=t2
-- }
-- setmetatable(t1,mt)
-- t1.sayhello=function()
-- print("newhello")
-- end
-- t1.sayhello()
-- t2.sayhello()




-- --忽略元表
-- local smartman={name="none"}
-- local t1={hehe=1234}
-- local mt={
-- 	__index=smartman,
-- 	__newindex=function(t,k,v)
-- print("biefuzhi")
-- end
-- }
-- setmetatable(t1,mt)
-- print(rawget(t1,"name"))
-- print(rawget(t1,"hehe"))
-- rawset(t1,"name","小偷")
-- print(t1.name)





-- a=100
-- for i,v in pairs(_G) do
-- 	print(i,v)
-- end



-- local game=require("GameData")
-- game.play()


-- require("GameManager")
-- GameManager.setLevel(10)
-- print(GameManager.getLevel())





-- sprite={x=0,y=0}
-- function sprite.setPosition(self,x,y)
-- 	self.x=x;
-- 	self.y=y;
-- end
-- local who=sprite;
-- sprite=nil;
-- who.setPosition(who,1,2)
-- print(who.x )




-- sprite1={x1=0,
-- y1=1,}
-- function sprite1:setPosition(x,y )
-- 	self.x1=x ;
-- 	self.y1=y;
-- end




-- t={x=3,y=5}
-- t.sayhello=function() end
-- function t.sayhello() end --等价



	-- Hero ={attack=3}
	-- function Hero:new(o)
	-- 	o=o or {}
	-- 	setmetatable(o,self)
	-- 	self.__index=self
	-- 	return o
	-- end
	-- function Hero:skill(addAttack)
	-- 	self.attack=self.attack+addAttack
	-- end
	-- oneHero=Hero:new({attack=100})
	-- oneHero:skill(10)
	-- print(oneHero.attack)





-- 	local Table={
-- 	array={},
-- 	number=12;
-- }
-- function Table:new(num,x,y)
-- 	local a={}
-- 	setmetatable(a,{__index=Table})

-- 	a.number=num
-- 	a.array[1]=x
-- 	a.array[2]=y
-- 	return a
-- end
-- function Table:trace()
-- 	print(self.number.." "..self.array[1].." "..self.array[2])
-- end
-- local a=Table:new(255,38,58)
-- local b=Table:new (333,54,67)
-- a:trace();
-- b:trace()
-- Table:trace()







