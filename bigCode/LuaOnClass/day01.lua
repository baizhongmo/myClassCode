-- print("hello lua")
-- print(b)
-- b=10
-- print(b)
-- print(b)

-- print(type("helloworld"))
-- print(type(true))
-- print(type(3.3))
-- print(type(print))
-- print(type(nil))
-- print(type({}))
-- print(type(type(123)))
-- print(type(number))
-- print(type(123))


-- a=10
-- print(a)
-- a="hello"
-- print(a)
-- a=print
-- a("helloa")

--false nil 为假其他都为真
-- if 0 then
-- 	print("zhen")
-- else
-- 	print("jia")
-- end



-- a="one string"
-- b=string.gsub(a,"one","another")
-- print(b)
-- print("hello".."lua")
-- print("10".."1")
-- print(10 ..1)
-- print(10+1)
-- print("10"+1)
-- print(tonumber("sss"))
-- print(tostring(234))	

-- for i=1,10,2 do
-- 	-- local name="image"..i..".png"
-- 	-- print(name)
-- 	local str=string.format("image%d.png",i)
-- 	print(str)
	
-- end
-- num=0
-- for i=1,100 do
-- 	num=num+i
-- 	print(num)
-- end
-- print(num)



-- print(4 and 5)
-- print(4 or 5)
-- print(nil and 5)
-- print(nil or 5)
-- print(false and 4)
-- print(false or 4)
-- print(4~=5)
-- print(1 and 100)

-- local  a = 20
-- local b = 10
-- a,b=b,a
-- print(a ..b)

-- local score = 80
-- if score>90 then
-- 	print("A")
-- 	elseif score>80 then
-- 		print("B")
-- else 
-- 	print("C")
-- end


-- local sun=0;
-- local i=0;
-- while i<=100 do
-- 	sun=sun+i;
-- 	i=i+1;
-- end
-- print(sun)

-- function max( a,b )
-- 	if a>b then
-- 		return a
-- 	else 
-- 		return b
-- 	end
-- end
-- print(max(30,40))

-- function test( )
-- 		return 11,22,33
-- end
-- a,b,c=test();
-- print(a..b..c)

-- local  days = {"monday","tuesday","wednesday","thursday","friday"}
-- print(days[4])
-- days[6]="saturday"
-- print (days[6])
-- local people={name="zhangsan",age=30,sex="boy"}
-- people.say="hello"
-- people["say1"]="world"
-- print(people.name)
-- print(people["name"])
-- print(table.maxn(days))
-- for i,v in pairs(people) do
-- 	print(i,v)
-- end
-- for i,v in pairs(people) do--遍历数组形式
-- 	print(i,v)
-- end

-- local tabFiles={
-- 	"A","B",
-- 	[3]="test2",
-- 	[5]="test3",
-- 	[6]="test4"
-- }
-- for k,v in ipairs(tabFiles) do
-- 	print(k,v)
-- end

local  arr = {}
for i=1,10 do
	table.insert(arr,1,i)
end
for k,v in pairs(arr) do
	print(k,v)
end






























