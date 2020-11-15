<script type="text/html" template lay-done="layui.data.sendParams(d);">
    <div class="layui-form layui-alone-form layui-form-pane" lay-filter="LAY-app-{{ModelClassName}}-editForm" id="LAY-app-{{ModelClassName}}-editForm">
	    {% for field in ModelFields %}{% if field.IsIdentity == true and field.IsPrimarykey == true %}<input type="hidden" name="{{field.DbColumnName}}"  value="[[d.params.data.{{field.DbColumnName}} || '' ]]" />{% endif %}{% if  field.DbColumnName contains 'Image' or field.DbColumnName contains 'image'  or field.DbColumnName contains 'thumbnail'  or field.DbColumnName contains 'Thumbnail' %}
	    <div class="layui-form-item">
            <label for="{{field.DbColumnName}}" class="layui-form-label  layui-form-required">{{field.ColumnDescription}}</label>
            <div class="layui-input-block">
                <input name="{{field.DbColumnName}}" id="{{field.DbColumnName}}Input" lay-verType="tips" lay-verify="required" class="layui-input"  value="[[d.params.data.{{field.DbColumnName}} || '' ]]" placeholder="请上传{{field.ColumnDescription}}" lay-reqText="请上传{{field.ColumnDescription}}"  />
            </div>
		    <div class="layui-input-block">
                <div class="layui-upload">
                    <button type="button" class="layui-btn" id="upBtn{{field.DbColumnName}}" lay-active="doCropperImg">上传图片</button>
                    <div class="layui-upload-list">
                        <img class="layui-upload-img" id="viewImgBox{{field.DbColumnName}}" src="[[d.params.data.{{field.DbColumnName}} || layui.setter.noImagePicUrl ]]">
                        <p id="viewTextBox{{field.DbColumnName}}"></p>
                    </div>
                </div>
            </div>
        </div>{% elsif field.DataType == 'nvarchar' %}
	    <div class="layui-form-item">
            <label for="{{field.DbColumnName}}" class="layui-form-label  layui-form-required">{{field.ColumnDescription}}</label>
            <div class="layui-input-block">
            {% if field.Length >0 %}<input name="{{field.DbColumnName}}"   lay-verType="tips" lay-verify="required|verify{{field.DbColumnName}}" class="layui-input" placeholder="请输入{{field.ColumnDescription}}" lay-reqText="请输入{{field.ColumnDescription}}"  value="[[d.params.data.{{field.DbColumnName}} || '' ]]" />{% else %}<input name="{{field.DbColumnName}}"   lay-verType="tips" lay-verify="required" class="layui-input" placeholder="请输入{{field.ColumnDescription}}" lay-reqText="请输入{{field.ColumnDescription}}"  value="[[d.params.data.{{field.DbColumnName}} || '' ]]" />
            {% endif %}
            </div>
        </div>{% elsif  field.DataType == 'int' %}
	    <div class="layui-form-item">
            <label for="{{field.DbColumnName}}" class="layui-form-label  layui-form-required">{{field.ColumnDescription}}</label>
            <div class="layui-input-block">
                <input  type="number" min="0" max="999999" name="{{field.DbColumnName}}"   lay-verType="tips" lay-verify="required|number" class="layui-input" value="[[d.params.data.{{field.DbColumnName}} || '' ]]" placeholder="请输入{{field.ColumnDescription}}" lay-reqText="请输入{{field.ColumnDescription}}并为数字"  />
            </div>
        </div>{% elsif  field.DataType == 'datetime' %}
	    <div class="layui-form-item">
            <label for="{{field.DbColumnName}}" class="layui-form-label  layui-form-required">{{field.ColumnDescription}}</label>
            <div class="layui-input-block">
                <input name="{{field.DbColumnName}}"  id="editTime-{{ModelClassName}}-{{field.DbColumnName}}" type="text" lay-verType="tips" lay-verify="required|datetime" class="layui-input" placeholder="请输入{{field.ColumnDescription}}" lay-reqText="请输入{{field.ColumnDescription}}"   value="[[d.params.data.{{field.DbColumnName}} || '' ]]"/>
            </div>
        </div>{% elsif  field.DataType == 'bit' %}
	    <div class="layui-form-item" pane>
            <label for="{{field.DbColumnName}}" class="layui-form-label  layui-form-required">{{field.ColumnDescription}}</label>
            <div class="layui-input-block">
                <input type="checkbox" lay-filter="switch" name="{{field.DbColumnName}}"   [[ d.params.data.{{field.DbColumnName}} ? 'checked' : '' ]] lay-skin="switch" lay-text="开启|关闭">
            </div>
        </div>{% else %}
	    <div class="layui-form-item">
            <label for="{{field.DbColumnName}}" class="layui-form-label  layui-form-required">{{field.ColumnDescription}}</label>
            <div class="layui-input-block">
                <input name="{{field.DbColumnName}}"   lay-verType="tips" lay-verify="required" class="layui-input" placeholder="请输入{{field.ColumnDescription}}" lay-reqText="请输入{{field.ColumnDescription}}"  value="[[d.params.data.{{field.DbColumnName}} || '' ]]" />
            </div>
        </div>{% endif %}
	    {% endfor %}
        <div class="layui-form-item text-right">
            <input type="button" class="layui-btn" lay-submit lay-filter="LAY-app-{{ModelClassName}}-editForm-submit" id="LAY-app-{{ModelClassName}}-editForm-submit" value="确认编辑">
        </div>
    </div>
</script>
<script>
    var debug= layui.setter.debug;
    layui.data.sendParams = function (d) {
        //开启调试情况下获取接口赋值数据
        if (debug) { console.log(d.params.data); }
        layui.use(['admin', 'form', 'laydate', 'upload', 'coreHelper', 'cropperImg'],
        function () {
            var $ = layui.$
                , form = layui.form
                , admin = layui.admin
                , laydate = layui.laydate
                , upload = layui.upload
                , cropperImg = layui.cropperImg
                , coreHelper = layui.coreHelper;
        {% for field in ModelFields %}{% if field.DataType == 'datetime' %}
            laydate.render({
                elem: '#editTime-{{ModelClassName}}-{{field.DbColumnName}}',
                type: 'datetime'
            });{% endif %}{% if field.DbColumnName contains 'Image' or field.DbColumnName contains 'image'  or field.DbColumnName contains 'thumbnail'   or field.DbColumnName contains 'Thumbnail' %}
            //{{field.ColumnDescription}}图片裁剪上传
            $('#upBtn{{field.DbColumnName}}').click(function () {
                cropperImg.cropImg({
                    aspectRatio: 1 / 1,
                    imgSrc: $('#viewImgBox{{field.DbColumnName}}').attr('src'),
                    onCrop: function (data) {
                        var loadIndex = layer.load(2);
                        coreHelper.Post("api/Tools/UploadFilesFByBase64", { base64: data }, function (res) {
                            if (0 === res.code) {
                                $('#viewImgBox{{field.DbColumnName}}').attr('src', res.data.fileUrl);
                                $("#{{field.DbColumnName}}Input").val(res.data.fileUrl);
                                layer.msg(res.msg);
                                layer.close(loadIndex);
                            } else {
                                layer.close(loadIndex);
                                layer.msg(res.msg, { icon: 2, anim: 6 });
                            }
                        });
                    }
                });
            });
            {% endif %}{% endfor %}
            form.verify({
                {% for field in ModelFields %}{% if field.DataType == 'nvarchar' and field.Length > 0 %}
		        verify{{field.DbColumnName}}: [/^[\S]{0,{{field.Length}}}$/,'{{field.ColumnDescription}}最大只允许输入{{field.Length}}位字符，且不能出现空格'],{% endif %}{% endfor %}
            });
            //重载form
            form.render(null, 'LAY-app-{{ModelClassName}}-editForm');
        })
    };
</script>
