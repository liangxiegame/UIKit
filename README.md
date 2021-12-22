# UIKit

UIKIt 是一套 UI/View 开发解决方案

由 QFramework 团队官方维护的独立工具包（不依赖 QFramework）。

## 环境要求

* Unity 2018.4LTS

## 安装

* PackageManager
    * add from package git url：https://github.com/liangxiegame/UIKit.git 
    * 或者国内镜像仓库：https://gitee.com/liangxiegame/UIKit.git
* 或者[点此下载 UIKit.unitypackage](ResKit.unitypackage) 并安装到自己项目中的任意脚本中



## 快速开始

``` csharp
// open a panel from assetBundle
UIKit.OpenPanel<UIMainPanel>();

// load a panel from specified Resources
UIKit.OpenPanel<UIMainPanel>(prefabName:"Resources/UIMainPanel");

// load a panel from specield assetName
UIKit.OpenPanel<UIMainPanel>(prefabName:"UIMainPanel1");
```

### 

## 更多

* QFramework 地址: https://github.com/liangxiegame/qframework

