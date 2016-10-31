
-- --class
-- function printf(fmt, ...)
--     print(string.format(tostring(fmt), ...))
-- end

-- function class(classname, super)
--     local superType = type(super)
--     local cls

--     if superType ~= "function" and superType ~= "table" then
--         superType = nil
--         super = nil
--     end

  
--         if super then
--             cls = {}
--             setmetatable(cls, {__index = super})
--             cls.super = super
--         else
--             cls = {ctor = function() end}
--         end

--         cls.__cname = classname
--         cls.__ctype = 2 -- lua
--         cls.__index = cls

--         function cls.new(...)
--             local instance = setmetatable({}, cls)
--             instance.class = cls
--             instance:ctor(...)
--             return instance
--         end


--     return cls
-- end




-- function search(classes ,key)
--     for i=1,#classes do
--         local value=classes[i][key]
--         if value~=nil then
--             return value
--         end
--     end
-- end
-- local t1={name="hehe"}
-- local t2={game="who"}
-- print(search({t1,t2},"game"))


-- function createClass(...)
--     local parents={...}
--     local child={}
--     setmetatable(child,{
--         __index=function(table,key)
--         return search(parents,key)
--         end
--     })


--     function child:new()
--         o={}

--         setmetatable(o,child)
--         child.__index=child
--         return o
--     end
-- return child
-- end

-- TSprite={}
-- function TSprite:hello()
--     print("hello")
-- end

-- function TSprite:new()
--     o={}
--     setmetatable(o,self)
--     self.__index=self
--     return o
-- end

-- TBullet={}
-- function TBullet:fire()
--     print("开火")
-- end

-- function TBullet:new(  )
--     o={}
--     setmetatable(o,self)
--     self.__index=self
--     return o
-- end

-- local BullentSprite=createClass(TSprite,TBullet)
-- local bSprite=BullentSprite:new()
-- bSprite:hello()
-- bSprite:fire()



-- --调用局部函数
-- function createTSprite()
--     local self={name="myName"}
--     local function myBus()
--         print("myBus is my function,you can not directly use")
--     end
--     local function myGame(  )
--         print("myGame is my function,you can not directly use")
--     end
--     local function hello(  )
--         print("hello")
--         myBus()
--     end
--     local function hi()
--         print("Hi:")
--      myGame()
--     end
--     local function setName( newName )
--      self.name=newName
--     end
--     return {hello=hello,hi=hi,setName=setName}
-- end


-- local sp = createTSprite()
-- sp.hello()
-- sp.hi()

-- --弱引用
-- t={}
-- setmetatable(t,{__mode="kv"})
-- key1={name="key1"}
-- t[key1]=1
-- key1=nil
-- key2={name="key2"}
-- t[key2]=2
-- key2=nil
-- collectgarbage()
-- for key,value in pairs(t) do
--     print(key.name ..":" ..value)
-- end

table={1,2}
for i=1,10 do
num=table[i]+table[i+1]
table[i+2]=num
print(num)
    end


















