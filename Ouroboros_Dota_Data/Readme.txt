本程序处于测试阶段，如果遇到bug请及时在群里报告
发布QQ群：Project LOLI（454133861）
程序运行所需的.Net Framework 4.0已经附上
英雄信息的右边栏数据来自dotamax

dota 2 beta文件夹位置：steam安装目录或国服安装目录\steamapps\common\dota 2 beta

已知bug：
初始bat≠1.7的英雄攻击间隔计算有问题
伤害系数和魔法抗性有细微差别
静谧之鞋由于官方字符串错误导致2个数值无法正常显示
幻影斧官方默认cd是远程英雄的45秒，而近战英雄的cd是30秒
物品信息里，配方里没有图片的物品不会显示名字

后续更新：
英雄的A杖效果，最近几个版本的技能改动
多语言选择
或许加入两个英雄对比模式
物品信息中的合成公式加入链接
酒仙、死灵龙等技能说明中添加召唤物技能说明
卡尔练习器可能加入日志功能

0.53:
修复了一个读取技能文件的bug
后续或许会加入artifact卡片数据库？
饰品数据库和卡尔练习器里的饰品图标功能已经提上日程

0.52:
HPMP回复和护甲公式根据7.20版本改变
修复了一个物品信息中，缺失lore文本导致的bug

0.51:
美化了英雄信息中的右边栏
修复一个可能导致内存不足的bug（下载了不存在的图片）

0.5:
卡尔练习器bug修复
针对游戏字符串文件移进vpk文件的更新：
	现在程序自己可以从vpk内提取文件，不再依赖第三方程序

0.43.1:
改进卡尔练习器：
	现在点击“开始”后会清掉元素球和已祈唤的技能
	现在不会连续出现两个相同的技能
	略微降低问题题目的出现概率（现在略低于图片题目）

0.43：
调整数据更新代码
加入新功能：卡尔练习器
卡尔练习器的CD机制和饰品图标下次更新

0.42:
属性公式更新为7.13版本
增加随机英雄功能
现在可以从dotamax网站获取一些数据，获取速度较慢
在中文字符串缺失时，自动读取英文字符串显示
英雄信息界面中，点击英雄头像或者名字，弹出英雄的背景故事

0.41：
文件读取方式修复
将英雄选择界面下扩一行，以显示邪影芳灵
将物品显示增加一行，以显示新物品
shops.txt文件现在摘出，作为显示物品的根据，最新的shops.txt文件获取方式见上方说明
pic文件夹仍然保留钢铁寒爪和穷鬼盾，以纪念这两件物品，但是数据会随着更新删除

0.4：
英雄数值计算调整为7.07版本
现在更新时，图片下载失败不会回滚整个更新
略微调整英雄信息界面的显示

0.3：
增加单位资料，但尚不能使用
英雄排序方式改为与游戏中相同（按英雄中文名ASCII排序）

0.21：
修改了英雄的筛选方式，改为与dota2客户端相同

0.20：
更改了文件的读取方式，不再依赖dota2游戏
修改了某些英雄技能顺序错误的bug
