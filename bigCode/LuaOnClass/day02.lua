--非全局变量
-- function count()
-- 	local i=0
-- 	return function ()
-- 		i=i+1
-- 		return i
-- 	end
-- end
-- local func =count()
-- print(func)
-- print(func())
-- print(func())


-- --两种等价方式
-- local function test()
-- print("A")
-- 	end
-- local test = function ( )
-- 	print("B")
-- end
-- test()

-- --把函数向上移动效果一样
-- local eat
-- local drink
-- eat= function ()
-- print("eat")
-- return drink()--尾调用
-- end
-- drink=function ()
-- print("drink")
-- end
-- for i=1,10000 do
-- eat()
-- end


-- function Diedaiqi( t )
-- 	local i = 0
-- 	return function (  )
-- 		i=i+1
-- 		if i>#t then
-- 			return nil
-- 		end
-- 		return i, t[i]
-- 	end
-- end
-- local t={"A","B","C"}
-- local iter = Diedaiqi(t)
-- while true do
-- 	local value=iter()
-- 	if value==nil then
-- 		break
-- 	end
-- 	print(value)
-- end
-- for key ,value in Diedaiqi(t) do--判断是否为空根据第一个值作为参照
-- 	print(key..value)
-- end




-- ...表示参数任意多
-- function hello(...)
-- local t={...}
-- print(#t)
-- print(t[2])
-- end
-- hello(1,2,3,4,5,6)





-- --简单深拷贝
function copy( t )
	local t1={}
	for k,v in pairs(t) do
		t1[k]=v
	end
	return t1;
end
local a={x=3,y=5}
local  b = copy(a)
b.x=8
print(a.x..b.x)
--这是浅拷贝
local c=a;
c.y=99
print(a.y..c.y)





-- local name="zhangsan"
-- -- local result=assert(name=="zhangsan","you are not zhangsan")
-- -- print(result)
-- if name~="zhangsan" then
-- 	error("you are not zhangsan")
-- 	else 
-- 		print("you are zhangsan")
-- end



-- --pcall方法
-- function test(  )
-- 	print(a[i])
-- 	-- print("aaa")
-- end
-- local status,err=pcall(test)
-- if status then
-- 	print(err)
-- 	print("正常")
-- else
-- 	print(err)
-- print("函数出错了")
-- end



--加载别的lua文件
-- loadfile("hello.lua")
-- dofile("NewFolder/hello.lua")
-- for i=1,10 do
-- 	require("./NewFolder/hello")
-- end
-- print(#t)

-- for i,k in pairs(t[2]) do
-- 	print(i..k)
-- end



--携程
-- print(type(coroutine))
-- local co=coroutine.create(function (  )
-- 	print("coroutine hello")
-- end)
-- print(coroutine.status(co))
-- coroutine.resume(co)
-- print(coroutine.status(co))




-- local co = coroutine.create(function (  )
-- 	for i=1,2 do
-- 		print("nihao xietongchengxu")
-- 		coroutine.yield();
-- 		print(i)
-- 	end
-- end)
-- print(coroutine.status(co ))
-- coroutine.resume(co)
-- print(coroutine.status(co ))
-- coroutine.resume(co)
-- print(coroutine.status(co ))
-- coroutine.resume(co)
-- print(coroutine.status(co ))



-- local co=coroutine.create(function ( param )
-- 	print(param)
-- end)
-- coroutine.resume(co,"coroutine param")

-- local co =coroutine.create(function ( name )
-- 	for i=1,2,1 do
-- 		print(name)
-- 		print("co"..coroutine.yield("yield param"))
-- 	end
-- 	return "结束"
-- end)
-- for i=1,3,1 do
-- 	print("第"..i.."次")
-- 	local result,msg=coroutine.resume(co,"functionparam")
-- 	print("msg:"..msg)
-- 	print(result)
-- end

-- function isExist( path )
-- 	 file=io.open(path)
-- 	if file then
	
-- 		return true
-- 	else

-- 		return false
-- 	end
-- end
-- -- print(isExist("/Users/stutend/Desktop/file.txt "))



-- function io.writefile( path,content,mode )
-- 	-- mode=mode or "w+b"
-- 	-- local file=io.open(path,mode)
-- 	-- if file then
-- 	-- 	if file:write(content)==nil then
-- 	-- 	 return false 
-- 	-- 	end
-- 	-- 	io.close(file)
-- 	-- 	return true
-- 	-- else 
-- 	-- 	return false
-- 	-- end
-- 	local file=io.open(path,mode)
-- 	file:write(content)
-- end
-- -- a=io.writefile("/Users/stutend/Desktop/file.txt ","wanwanwanwawnawnhhhhhkkkkk","w")
-- -- print(a)

-- function io.readfile( path)
	
-- 	local file=io.open(path,"r")
-- 	if file then
-- 	content=file:read("*a")
-- else 
-- 	return false
-- end
-- 	return content
	
-- end


-- -- dataa=io.readfile("/Users/stutend/Desktop/file.txt ")
-- -- print(dataa)



-- function fileExist( path)
-- 	local file=io.open(path)
-- 	if file then
-- 		return true
-- 	else 
-- 		return false
-- 	end
-- end
-- -- print(fileExist("/Users/stutend/Desktop/file.txt "))

-- function write( path ,content )
-- 	file=io.open(path,"w")
-- 	file:write(content)
-- end
-- -- write("/Users/stutend/Desktop/file.txt ","diercixieru")
-- function read( path )
-- 	file=io.open(path,"r")
-- 	data=file:read("*a")
-- 	return data 
-- end
-- print(read("/Users/stutend/Desktop/file.txt "))
-- function Exist( path )
-- 	file=io.open(path)
-- 	if file then 
-- 		return true
-- 	else
-- 		return false
-- 	end
-- end
-- print(Exist("/Users/stutend/Desktop/file.txt "))




-- function copydep( a )
-- 	local b={}
-- 	for i,v in pairs(a) do
-- 		if type(v)=="table" then
-- 			k={}
-- 			for i1,v1 in pairs(v) do
-- 				k[i1]=v1
-- 			end
-- 			b[i]=k
-- 		else
-- 			b[i]=v
-- 		end
-- 	end
-- 	return b 
-- end
-- a={"a","b",{"c","d"}}
-- c=copydep(a )
-- for i,v in pairs(c[3]) do
-- 	print(i..v)
-- end

-- print(c[3][1])
-- c[3][1]="kk"
-- print(c[3][1])
-- print(a[3][1])





