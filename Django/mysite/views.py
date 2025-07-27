from django.http import HttpResponse
from django.shortcuts import render, redirect
# 正确的导入方式
from datetime import datetime
from userModel.models import regUser
# 掌握基本模板变量的语法
def myname(request):
    context          = {}
    context["first_name"] = "pu"
    context["last_name"] = "peng"
    return render(request, "myname.html", context)
def myfavors(request):
    views_list = ["篮球","排球","足球"]
    return render(request, "myfavors.html", {"views_list": views_list})
# 掌握模板中过滤器的技巧
def myfilters(request):
    context = {
        "views_str":"我的中国心",
        "views_href": "<a href='https://www.shuishan.net.cn'>水杉在线</a>",
        "views_num": 1000000,
        "views_time": datetime.now(), # 获取当前时间from datetime import datetime
        "views_price1"        :2134.566,
        "views_price2"        :1234.461
    }
    return render(request, "myfilters.html", context)
# 掌握模板中循环的语法
def mybooks(request):
    books=["三国演义","红楼梦","水浒传","西游记","聊斋志异"]
    return render(request, "mybooks.html", {"books": books,"num": 88})
def hello(request):
    return HttpResponse("Hello world ! ")
def nick(request):
    return HttpResponse("tvbboy ")
 
# 接收请求数据
# 多参数测试网址：http://127.0.0.1:8000/getpara/?para1=8&para2=4
# 1个参数测试网址：http://127.0.0.1:8000/getpara/?para1=5
def getpara(request):  
    request.encoding='utf-8'
    msg = ""
    try:
        if 'para1' in request.GET and request.GET['para1']:
            para1 = request.GET['para1']  # 接收参数类型是string
            if int(para1) % 2==0:
                msg = "<font color='green'>para1 是偶数</font>"  #HTML语法，表示颜色为绿色
            else:
                msg = "<font color='blue'>para1 是奇数</font>"
        else:
            msg="para1 is null"
        if 'para2' in request.GET and request.GET['para2']:
            para2 = request.GET['para2'] 
            msg+="</br>para2 is "+para2  #HTML语法，表示换行
       
        else:
            msg+="</br>para2 is null"
    except Exception:
        msg= "<font color='red'>Exception occur!!!!!!!!!!</font>"
    return render(request, "getpara.html", {"msg": msg})  


def user_profile(request):
    user_id = request.session.get('user_id')
    if not user_id:
        return redirect('login')
    try:
        user = regUser.objects.get(id=user_id)
    except regUser.DoesNotExist:
        return redirect('login')
    context = {
        'username': user.username,
        'email': user.email,
        'regdate': user.regdate,
        'lastlogin': user.lastlogin,
        'logintimes': user.logintimes,
        'qq': user.qq,
        'gender': user.gender,
        'birthdate': user.birthdate,
        'nativePlace': user.nativePlace
    }
    return render(request, "user_profile.html", context)



