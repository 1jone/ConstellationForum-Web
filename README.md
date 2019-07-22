# ConstellationForum-Web

一、系统功能说明
==================
该系统为星座主题论坛。该系统采用ASP.NET MVC框架，系统具有登录、注册、以及注销功能，具有概要展示文章信息功能，文章分类功能，文章上传功能，文章评论功能以及删除文章功能。该系统具有管理员和一般用户两类用户，管理员具有所有功能的使用权限；一般用户不具有文章的删除权限，其它权限都有。
![image](https://github.com/1jone/ConstellationForum-Web/blob/master/images/1.png)

二、使用的技术
==================
ASP.NET MVC、SQL Server Express LocalDB、jQuery、Bootstrap、CSS特效、图表，页面布局大部分是用layUI框架

三、操作步骤
==================
1、启动项目，在游览器中访问网站

2、未注册账号，可以先“注册”一个账号，然后再进行登陆

![image](https://github.com/1jone/ConstellationForum-Web/blob/master/images/3.png)

![image](https://github.com/1jone/ConstellationForum-Web/blob/master/images/4.png)

3、进入网站，在未登陆的情况下，只能查看文章，没有留言和提交文章的权限

![image](https://github.com/1jone/ConstellationForum-Web/blob/master/images/2.png)

4、进入网站页面后，点击任意一个文章区域，将会跳转到该文章的详情页面，每点击一次文章，该文章的点击数便+1

5、若进入网站，未登陆，但是点击“文章投稿”或者“留言”，页面会自动跳转到登陆界面

![image](https://github.com/1jone/ConstellationForum-Web/blob/master/images/5.png)

6、点击上方的“登陆”，进行登陆。登陆之后，留言板才会显示出来，这时，用户可以进行留言、上传文章。每给一个文章留言一个，便会在该文章的回答数量中+1

7、若是管理员登陆，则管理员多一个“管理”页面。在管理页面，管理员可以看到所有文章，可以选择“查看”文章（跳转到该文章的详情页面）或者“删除”文章。

![image](https://github.com/1jone/ConstellationForum-Web/blob/master/images/6.png)

8、登陆之后，可以“注销”账户，然后选择其它账户登录



