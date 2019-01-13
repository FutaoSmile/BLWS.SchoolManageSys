
## BLWS.SchoolManageSys 教学信息管理系统

 [项目地址](https://git.oschina.net/FutaoSmile/BLWS.SchoolManageSys)

 [数据库文件](https://git.oschina.net/FutaoSmile/BLWS.SchoolManageSys/attach_files)

时间：2017/5/1-2017-6-30

##### 主要功能
1.    教学信息的管理
2.    如班级成员的管理
3.    选课系统
4.    评分系统等
5.    Excel数据导入导出
6.    菜单的动态管理
7.    不同角色动态菜单权限的配置等

##### 技术清单

*backEnd*

1.    C#
2.    EntityFramework
3.    Asp.net WebApi
4.    sqlserver


*frontEnd*

5.    html
6.    css
7.    js
8.    jquery
9.    bootstrap
10.    angularJs
11.    echarts
12.    wangEditor
13.    layer
14.    layui
15.    cookie
16.    datatables
17.    font awesome
等...


##### 系统架构（数据流向）

1.  数据库交互采用EntityFramework框架的CodeFirst模式（BLWS.SchoolSystem.EF）。
2.  API通过EntityFramework进行数据操作，访问数据库（BLWS.SchoolSystem.WebApi）。
3.  App调用API接口，实现数据在浏览器的展示和操作（BLWS.SchoolSystem.App）。

##### 特点

1.  数据库交互采用EntityFramework框架的CodeFirst模式。
2.  API接口采用的是Asp.net WebApi。
3.  前端采用的是BootStrap框架布局加AngularJS框架。
4.  实现了所有页面和页面元素的响应式布局。
5.  所有的配色方案都是采用的BootStrap样式，具有良好的用户体验。
6.  所有数据的增删改查都进行了数据格式长度等要求的验证。

##### 运行环境&安装

*    数据库	Microsoft Sql Server 2014 
*    编译器	Microsoft Visual Studio 2015
*    运行环境	Chrome，Firefox，IE8以上

1.    用VS打开 教学信息管理平台-> BLWS.SchoolSystem-> BLWS.SchoolSystem.sln
2.    修改数据库配置文件：
    *    项目->BLWS.SchoolSystem.EF->App.config-
    *    项目-> BLWS.SchoolSystem.WebApi->Web.config
    *    项目-> BLWS.SchoolSystem.App->Web.config
改的是这些配置文件下的同一部分代码（如下）：

```xml
<connectionStrings>
    <add name="DBConn" connectionString="Data Source=服务器地址; Connection Timeout=60;Initial Catalog=BLWS.SchoolSys.DB;Integrated Security=False;User ID=用户名;Password=密码;multipleactiveresultsets=True;" providerName="System.Data.SqlClient" />
  </connectionStrings>

```

3.    附加数据库
4.    运行
如果不以调试模式启动程序，则需要先启动BLWS.SchoolSystem.W3bApi，让这个服4.  服务器上注册跑起来，再运行BLWS.SchoolSystem.App。
如果以调试模式启动的话则可直接运行。

![login.png](http://upload-images.jianshu.io/upload_images/1846623-33072e776ded554b.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

![index.png](http://upload-images.jianshu.io/upload_images/1846623-b8a763d4ca73b2a4.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

![index2.png](http://upload-images.jianshu.io/upload_images/1846623-14cc3c72c87f20ca.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

![menu.png](http://upload-images.jianshu.io/upload_images/1846623-c28a342d478a88df.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

![dt.png](http://upload-images.jianshu.io/upload_images/1846623-a1ac1f42c8252f79.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

![edit.png](http://upload-images.jianshu.io/upload_images/1846623-abc1eb429eda6232.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

![modal.png](http://upload-images.jianshu.io/upload_images/1846623-5474f8f5bc74d745.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

![news.png](http://upload-images.jianshu.io/upload_images/1846623-2fb0594ff24b14c3.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

![student.png](http://upload-images.jianshu.io/upload_images/1846623-310d7092b654ec69.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

![teacher.png](http://upload-images.jianshu.io/upload_images/1846623-aef8c2231cf6f980.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)









