# 宝德龙智能健身系统

## 开发环境
* VS2017
* WPF
* .NET 4.5

## 开发规约

1. C#方法名用大驼峰，如`public string Tran(int a);`
2. 包名即文件夹名，C#叫命名空间，首字母大写。参考AISports.Util
3. 依赖管理采用NuGet（C#的Maven），避免手痛赋值dll动态链接库
4. 基本包/命名空间已经建好，以AISports.XXX格式，分门别类放置
5. 一个类一个文件，避免一个文件中创建多个 **业务类** 的情况。如在`UserDAO.cs`中既有`class UserDAO{}` 又有 `class TrainDAO{}` 两个类
6. 保证提交到远程仓库上的代码是可用的，不能运行都运行不了
7. 关键业务记录日志，日志框架以经集成好