
# 系统说明
## 核心内容管理系统底层使用的权限管理系统
### 项目介绍
基于Asp.net Core 3.1开发。  
颗粒化权限控制，能精确到单个action操作上。  
程序上手难度低，执行效率、扩展性、稳定性值得信赖，可大量节省定制化开发周期。争取让开发入门者拿来即用。  
目前是1.0版本，主要是通用功能实现，以后会增加更多功能，持续开发中...  
#### 关于开源
软件受国家计算机软件著作权保护（软著登记号：2020SR1224749）。  
使用 GPL许可证发布，可用于商业运营、二次开发，需要保留相关版权信息和许可提示。  
我们的团队水平有限，也是在探索中学习、改进。开源，是为了让认可我们的用户能自由的使用、学习软件的内部架构，也可以修改、重新发布。同时让更多的人有机会阅读并发现bug、对软件项目提出改进意见。

### 后端技术
#### 技术模块组成
| 技术 | 名称 |官网 |
| --- | --- |  --- |
| Asp.net Core | 应用框架| [https://projects.spring.io/spring-boot/](https://projects.spring.io/spring-boot/) |
| Asp.net Core WebApi | Api框架| [https://projects.spring.io/spring-cloud/](https://projects.spring.io/spring-boot/) |
| Swagger2 | Api文档| [http://www.mybatis.org/mybatis-3/zh/index.html](http://www.mybatis.org/mybatis-3/zh/index.html) |
| AutoFac | IOC框架| [https://gitee.com/free/Mapper](https://gitee.com/free/Mapper) |
| SqlSugar | ORM框架| [http://www.mybatis.org/generator/index.html](http://www.mybatis.org/generator/index.html) |
| AutoMapper | 实体映射| [https://swagger.io/](https://swagger.io/) |
| DotLiquid | 模板引擎| [https://www.thymeleaf.org/](https://www.thymeleaf.org/) |
| Nlog | 日志组件| [https://logback.qos.ch](https://logback.qos.ch/) |
| Redis | 数据缓存| [https://github.com/alibaba/druid](https://github.com/alibaba/druid) |
| Jwt | 授权认证| [http://hibernate.org/validator/](http://hibernate.org/validator/) |


#### 组件模块说明

- 提供 Redis 做缓存处理；
- 使用 Swagger 做api文档；
- 使用 Automapper 处理对象映射；
- 使用 AutoFac 做依赖注入容器，并提供批量服务注入；
- 支持 CORS 跨域；
- 封装 JWT 自定义策略授权；
- 使用 Nlog日志框架，集成原生 ILogger 接口做日志记录；
- 使用 SignalR 双工通讯；
- 添加 IpRateLimiting 做 API 限流处理;
- 支持 数据库读写分离和多库操作；


### 前端技术
| 技术 | 官网 | 说明 |
| --- | --- |--- |
| LayUIAdmin | https://www.layui.com/ | 不提供完整layUIAdmin框架，只保留5个用于运行的核心js文件。 |


### 软硬件需求

- （必选）IIS7.5或以上/docker容器/k8s
- （必选）sqlserver 2012R2 或以上版本
- （必选）阿里云OSS/腾讯云OSS
- （必选）支持https协议的域名
- （可选）Redis 5.7或以上版本
- （可选）易联云网络打印机




