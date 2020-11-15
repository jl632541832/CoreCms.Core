/**
  封装常用扩展
**/

layui.define(['admin', 'layer', 'form'], function (exports) { //提示：模块也可以依赖其它模块，如：layui.define('layer', callback);

    var $ = layui.jquery,
        layer = layui.layer,
        admin = layui.admin,
        setter = layui.setter;

    var obj = {
        log: function (str) {
            console.log('coreHelper执行：' + str);
        },
        Post: function (url, data, success, cache, alone) {
            coreAjax(url, 'post', 'json', data, success, false, cache, alone, false, false);
        },
        PostForm: function (url, data, success, cache, alone) {
            coreAjax(url, 'post', 'json', data, success, false, cache, alone, false, true);
        },
        Get: function (url, success, cache, alone) {
            coreAjax(url, 'get', 'json', {}, success, false, alone, false, false);
        },
        jsonp: function (url, success, cache, alone) {
            coreAjax(url, 'get', 'jsonp', {}, success, false, cache, alone, false, false);
        },
        viewImage: function (imgUrl) {
            layer.open({
                type: 1,
                title: false,
                closeBtn: 0,
                scrollbar: false,
                skin: 'layui-layer-nobg', //没有背景色
                shadeClose: true,
                content: "<img style='max-width: 350px;max-height: 350px;' src='" + imgUrl + "'>"
            });
        },
        stringToArray: function (str) {
            var arr = [];
            if (str.indexOf(',') != -1) {
                arr = str.split(',');
            } else {
                arr.push(str);
            }
            return arr;
        },
        stringToArrayLength: function (str) {
            var arr = [];
            if (str.indexOf(',') != -1) {
                arr = str.split(',');
            } else {
                arr.push(str);
            }
            return arr.length;
        },
        //获取随机编码
        getSN: function (str) {
            //声明一个随机数变量，默认为1
            var GetRandomn = 1;
            //js生成时间戳
            var timestamp = new Date().getTime();
            //获取随机范围内数值的函数
            function GetRandom(n) {
                //由随机数+时间戳+1组成
                GetRandomn = Math.floor(Math.random() * n + timestamp + 1);
            }
            //开始调用，获得一个1-100的随机数
            GetRandom("30");
            return str + GetRandomn;
        },
        getLabelStyle: function (str) {
            var outStr = "";
            switch (EXPR) {
                case 'red':
                    outStr = "";
                    break;
                case 'green':
                    outStr = "layui-bg-green";
                    break;
                case 'orange':
                    outStr = "layui-bg-orange";
                    break;
                case 'blue':
                    outStr = "layui-bg-blue";
                    break;
                default:
                    outStr = "";
            }
            return outStr;
        },
        //时间格式化
        getFullTime: function (date) {
            let Y = date.getFullYear() + '',
                M = (date.getMonth() + 1 < 10 ? '0' + (date.getMonth() + 1) : date.getMonth() + 1),
                D = (date.getDate() < 10 ? '0' + (date.getDate()) : date.getDate()),
                h = (date.getHours() < 10 ? '0' + (date.getHours()) : date.getHours()),
                m = (date.getMinutes() < 10 ? '0' + (date.getMinutes()) : date.getMinutes()),
                s = (date.getSeconds() < 10 ? '0' + (date.getSeconds()) : date.getSeconds());
            return Y + '-' + M + '-' + D + ' ' + h + ':' + m + ':' + s;
        },
        //保存和刷新token
        saveRefreshtime: function () {
            let nowtime = new Date();
            let lastRefreshtime = window.localStorage.refreshtime ? new Date(window.localStorage.refreshtime) : new Date(-1);
            let expiretime = new Date(Date.parse(window.localStorage.TokenExpire));

            let refreshCount = 1;//滑动系数
            if (lastRefreshtime >= nowtime) {
                lastRefreshtime = nowtime > expiretime ? nowtime : expiretime;
                lastRefreshtime.setMinutes(lastRefreshtime.getMinutes() + refreshCount);
                window.localStorage.refreshtime = lastRefreshtime;
            } else {
                window.localStorage.refreshtime = new Date(-1);
            }
        },
        //获取浏览器get参数
        getQueryValue: function () {
            var url = location.href; //获取url中"?"符后的字串
            console.log(url);
            var theRequest = new Object();
            if (url.indexOf("?") != -1) {
                var str = url.substr(1);
                strs = str.split("&");
                for (var i = 0; i < strs.length; i++) {
                    theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
                }
            }
            return theRequest;
        },
        getLabel: function (labels) {
            var html = '';
            if (labels && labels != null && typeof labels != 'undefined') {
                var label_style = '';
                if (typeof labels == 'object') {
                    $.each(labels, function (i, obj) {
                        label_style = '';
                        switch (obj.style) {
                            case 'red':
                                label_style = "";
                                break;
                            case 'green':
                                label_style = "layui-bg-green";
                                break;
                            case 'orange':
                                label_style = "layui-bg-orange";
                                break;
                            case 'blue':
                                label_style = "layui-bg-blue";
                                break;
                            default:
                                label_style = '';
                        }
                        html += '<span class="layui-badge ' + label_style + '">' + obj.name + '</span>&nbsp;';
                    });
                }
            }
            return html;
        }
    };

    function coreAjax(url, type, dataType, data, success, error, cache, alone, async, isForm) {
        var type = type || 'get'; //请求类型
        var dataType = dataType || 'json'; //接收数据类型
        var async = async || true; //异步请求
        var alone = alone || false; //独立提交（一次有效的提交）
        var cache = cache || false; //浏览器历史缓存
        var contentType = isForm ? 'application/x-www-form-urlencoded; charset=UTF-8' : 'application/json; charset=utf-8';
        var data = isForm ? data : JSON.stringify(data);
        var headers = {
            'Authorization': 'Bearer ' + layui.data(setter.tableName)[setter.request.tokenName]
        };
        var loadingIndex = false;
        var success = success ||
            function (data) {
                if (data.code === setter.response.statusCode.ok) {
                    setTimeout(function () {
                        layer.msg(data.msg, { icon: 1, time: 1500 });
                    },
                        300);
                } else if (data.code === setter.response.statusCode.error) {
                    setTimeout(function () {
                        layer.msg(data.msg, { icon: 5, time: 1500 });
                    },
                        300);
                }
                else {
                    //服务器处理失败
                    layer.msg("服务器开小差了，请稍后再试", { icon: 5, time: 1500 });
                }
            };
        var newSuccess = function (data) {
            if (data.code === setter.response.statusCode.logout) {
                admin.exit();
            }
            success(data);
        };
        var error = error ||
            function (data) {
                layer.closeAll('loading');
                setTimeout(function () {
                    if (data.status == 404) {
                        layer.msg("请求失败，请求未找到", { icon: 5, time: 1500 });
                    } else if (data.status == 503) {
                        layer.msg("请求失败，服务器内部错误", { icon: 5, time: 1500 });
                    } else {
                        layer.msg("请求失败,网络连接超时", { icon: 5, time: 1500 });
                    }
                },
                    500);
            };
        $.ajax({
            'url': setter.apiUrl + url,
            'data': data,
            'type': type,
            'headers': headers,
            'dataType': dataType,
            'contentType': contentType,
            'async': async,
            'success': newSuccess,
            'error': error,
            'jsonpCallback': 'jsonp' + (new Date()).valueOf().toString().substr(-4),
            'beforeSend': function () {
                loadingIndex = layer.msg('加载中',
                    {
                        icon: 16,
                        shade: 0.01
                    },
                    300);
            },
            'complete': function (e) {
                layer.close(loadingIndex);
            }
        });
    };


    //输出接口
    exports('coreHelper', obj);
});


