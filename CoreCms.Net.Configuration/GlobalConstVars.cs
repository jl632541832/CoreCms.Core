namespace CoreCms.Net.Configuration
{
    public class GlobalConstVars
    {
        /// <summary>
        /// 数据删除成功
        /// </summary>
        public const string DeleteSuccess = "数据删除成功";
        /// <summary>
        /// 数据删除失败
        /// </summary>
        public const string DeleteFailure = "数据删除失败";
        /// <summary>
        /// 系统禁止删除此数据
        /// </summary>
        public const string DeleteProhibitDelete = "系统禁止删除此数据";
        /// <summary>
        /// 此数据含有子类信息，禁止删除
        /// </summary>
        public const string DeleteIsHaveChildren = "此数据含有子类信息，禁止删除";
        /// <summary>
        /// 数据处理异常
        /// </summary>
        public const string DataHandleEx = "数据接口出现异常";
        /// <summary>
        /// 数据添加成功
        /// </summary>
        public const string CreateSuccess = "数据添加成功";
        /// <summary>
        /// 数据添加失败
        /// </summary>
        public const string CreateFailure = "数据添加失败";
        /// <summary>
        /// 数据移动成功
        /// </summary>
        public const string MoveSuccess = "数据移动成功";
        /// <summary>
        /// 数据移动失败
        /// </summary>
        public const string MoveFailure = "数据移动失败";
        /// <summary>
        /// 系统禁止添加数据
        /// </summary>
        public const string CreateProhibitCreate = "系统禁止添加数据";
        /// <summary>
        /// 数据编辑成功
        /// </summary>
        public const string EditSuccess = "数据编辑成功";
        /// <summary>
        /// 数据编辑失败
        /// </summary>
        public const string EditFailure = "数据编辑失败";
        /// <summary>
        /// 系统禁止编辑此数据
        /// </summary>
        public const string EditProhibitEdit = "系统禁止编辑此数据";
        /// <summary>
        /// 数据已存在
        /// </summary>
        public const string DataIsHave = "数据已存在";
        /// <summary>
        /// 数据不存在
        /// </summary>
        public const string DataisNo = "数据不存在";
        /// <summary>
        /// 请提交必要的参数
        /// </summary>
        public const string DataParameterError = "请提交必要的参数";
        /// <summary>
        /// 数据插入成功
        /// </summary>
        public const string InsertSuccess = "数据插入成功！";
        /// <summary>
        /// 数据插入失败
        /// </summary>
        public const string InsertFailure = "数据插入失败！";
        /// <summary>
        /// Excel导出失败
        /// </summary>
        public const string ExcelExportFailure = "Excel导出失败";
        /// <summary>
        /// Excel导出成功
        /// </summary>
        public const string ExcelExportSuccess = "Excel导出成功";
        /// <summary>
        /// 获取数据成功
        /// </summary>
        public const string GetDataSuccess = "获取数据成功！";
        /// <summary>
        /// 获取数据异常
        /// </summary>
        public const string GetDataException = "获取数据异常！";
        /// <summary>
        /// 获取数据失败
        /// </summary>
        public const string GetDataFailure = "获取数据失败！";
        /// <summary>
        /// 设置数据成功
        /// </summary>
        public const string SetDataSuccess = "设置数据成功！";
        /// <summary>
        /// 设置数据异常
        /// </summary>
        public const string SetDataException = "设置数据异常！";
        /// <summary>
        /// 设置数据失败
        /// </summary>
        public const string SetDataFailure = "设置数据失败！";

        //缓存数据
        /// <summary>
        /// 缓存已经排序后台导航
        /// </summary>
        public const string CacheFindNavSortList = "CacheFindNavSortList";
        /// <summary>
        /// 缓存未排序后台导航
        /// </summary>
        public const string CacheFindNavNoSortList = "CacheFindNavNoSortList";



        /// <summary>
        /// 缓存角色列表
        /// </summary>
        public const string CacheManagerRoleList = "CacheManagerRoleList";
        /// <summary>
        /// 缓存单页分类
        /// </summary>
        public const string CachePageCategoryList = "CachePageCategoryList";
        /// <summary>
        /// 缓存角色详细信息
        /// </summary>
        public const string CacheRoleValues = "CacheRoleValues";
        /// <summary>
        /// 缓存用户组
        /// </summary>
        public const string CacheUserCategoryList = "CacheUserCategoryList";
        /// <summary>
        /// 缓存业务
        /// </summary>
        public const string CacheJobDirectoryList = "CacheJobDirectoryList";
        /// <summary>
        /// 缓存无序区域业务
        /// </summary>
        public const string CacheAreaList = "CacheArea";


        /// <summary>
        /// 缓存配置信息
        /// </summary>
        public const string CacheCoreCmsSettingList = "CacheCoreCmsSettingList";
        public const string CacheCoreCmsSettingByComparison = "CacheCoreCmsSettingByComparison";


        /// <summary>
        /// CookieOpenid
        /// </summary>
        public const string CookieOpenId = "CookieOpenId";
        /// <summary>
        /// SessionOpenId
        /// </summary>
        public const string SessionOpenId = "SessionOpenId";
        /// <summary>
        /// 用户AccessToken有效期
        /// </summary>
        public const string CookieOAuthAccessTokenEndTime = "CookieOAuthAccessTokenEndTime";


        /// <summary>
        /// 广告表
        /// </summary>
        public const string CacheSysDictionary = "CacheSysDictionary"; //数据字典表
        public const string CacheSysDictionaryData = "CacheSysDictionaryData"; //数据字典项表
        public const string CacheSysLoginRecord = "CacheSysLoginRecord"; //登录日志表
        public const string CacheSysMenu = "CacheSysMenu"; // 菜单表
        public const string CacheSysOperRecord = "CacheSysOperRecord"; // 操作日志表
        public const string CacheSysOrganization = "CacheSysOrganization"; // 组织机构表
        public const string CacheSysRole = "CacheSysRole"; //角色表
        public const string CacheSysRoleMenu = "CacheSysRoleMenu"; //角色菜单关联表
        public const string CacheSysUser = "CacheSysUser"; //用户表
        public const string CacheSysUserRole = "CacheSysUserRole"; //用户角色关联表

    }

    /// <summary>
    /// 权限变量配置
    /// </summary>
    public static class Permissions
    {
        public const string Name = "Permission";

        /// <summary>
        /// 当前项目是否启用IDS4权限方案
        /// true：表示启动IDS4
        /// false：表示使用JWT
        public static bool IsUseIds4 = false;
    }

    /// <summary>
    /// 路由变量前缀配置
    /// </summary>
    public static class RoutePrefix
    {
        /// <summary>
        /// 前缀名
        /// 如果不需要，尽量留空，不要修改
        /// 除非一定要在所有的 api 前统一加上特定前缀
        /// </summary>
        public const string Name = "";
    }


    /// <summary>
    /// 银行卡相关常量定义
    /// </summary>
    public static class BankConst
    {
        public const string BankLogoUrl = "https://apimg.alipay.com/combo.png?d=cashier&t=";
    }




}
