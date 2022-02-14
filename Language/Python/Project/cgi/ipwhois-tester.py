#!/usr/bin/python3

# 通过whois查询ip属于哪个运营商。
# 增加查询IP whois结果的中的CN功能。

import os
import re, ipaddress, json
import redis

print('Content-Type: application/json')
print('')

ip_str = '203.90.232.64,59.108.59.107,123.177.20.83,223.100.213.1,256.256.256.256,1.2.4.8'
ips = set([ip.strip() for ip in ip_str.split(',')])

if len(ips) > 0:
    country_dict = {'AF':'阿富汗','AL':'阿尔巴尼亚','DZ':'阿尔及利亚','AS':'美属萨摩亚','AD':'安道尔','AO':'安哥拉','AI':'安圭拉','AQ':'南极洲','AG':'安提瓜和巴布达','AR':'阿根廷','AM':'亚美尼亚','AW':'阿鲁巴','AU':'澳大利亚','AT':'奥地利','AZ':'阿塞拜疆','BS':'巴哈马','BH':'巴林','BD':'孟加拉国','BB':'巴巴多斯','BY':'白俄罗斯','BE':'比利时','BZ':'伯利兹','BJ':'贝宁','BM':'百慕大','BT':'不丹','BO':'玻利维亚','BA':'波黑','BW':'博茨瓦纳','BV':'布韦岛','BR':'巴西','IO':'英属印度洋领地','VG':'英属维尔京群岛','BN':'文莱','BG':'保加利亚','BF':'布基纳法索','MM':'缅甸','BI':'布隆迪','CV':'佛得角','KH':'柬埔寨','CM':'喀麦隆','CA':'加拿大','KY':'开曼群岛','CF':'中非','TD':'乍得','CL':'智利','CN':'中国','CX':'圣诞岛','CC':'科科斯（基林）群岛','CO':'哥伦比亚','KM':'科摩罗','CD':'刚果民主共和国','CG':'刚果共和国','CK':'库克群岛','CR':'哥斯达黎加','CI':'科特迪瓦','HR':'克罗地亚','CU':'古巴','CW':'库拉索','CY':'塞浦路斯','CZ':'捷克','DK':'丹麦','DJ':'吉布提','DM':'多米尼克','DO':'多米尼加','EC':'厄瓜多尔','EG':'埃及','SV':'萨尔瓦多','GQ':'赤道几内亚','ER':'厄立特里亚','EE':'爱沙尼亚','ET':'埃塞俄比亚','FK':'福克兰群岛','FO':'法罗群岛','FJ':'斐济','FI':'芬兰','FR':'法国','FX':'法国本土','GF':'法属圭亚那','PF':'法属波利尼西亚','TF':'法属南部和南极领地','GA':'加蓬','GM':'冈比亚','PS':'巴勒斯坦','GE':'格鲁吉亚','DE':'德国','GH':'加纳','GI':'直布罗陀','GR':'希腊','GL':'格陵兰','GD':'格林纳达','GP':'瓜德罗普','GU':'关岛','GT':'危地马拉','GG':'根西','GN':'几内亚','GW':'几内亚比绍','GY':'圭亚那','HT':'海地','HM':'赫德岛和麦克唐纳群岛','VA':'梵蒂冈','HN':'洪都拉斯','HK':'香港','HU':'匈牙利','IS':'冰岛','IN':'印度','ID':'印尼','IR':'伊朗','IQ':'伊拉克','IE':'爱尔兰','IM':'马恩岛','IL':'以色列','IT':'意大利','JM':'牙买加','JP':'日本','JE':'泽西','JO':'约旦','KZ':'哈萨克斯坦','KE':'肯尼亚','KI':'基里巴斯','KP':'朝鲜','KR':'韩国','XK':'科索沃','KW':'科威特','KG':'吉尔吉斯斯坦','LA':'老挝','LV':'拉脱维亚','LB':'黎巴嫩','LS':'莱索托','LR':'利比里亚','LY':'利比亚','LI':'列支敦士登','LT':'立陶宛','LU':'卢森堡','MO':'澳门','MK':'北马其顿','MG':'马达加斯加','MW':'马拉维','MY':'马来西亚','MV':'马尔代夫','ML':'马里','MT':'马耳他','MH':'马绍尔群岛','MQ':'马提尼克','MR':'毛里塔尼亚','MU':'毛里求斯','YT':'马约特','MX':'墨西哥','FM':'密克罗尼西亚联邦','MD':'摩尔多瓦','MC':'摩纳哥','MN':'蒙古','ME':'黑山','MS':'蒙特塞拉特','MA':'摩洛哥','MZ':'莫桑比克','NA':'纳米比亚','NR':'瑙鲁','NP':'尼泊尔','NL':'荷兰','AN':'荷属安的列斯','NC':'新喀里多尼亚','NZ':'新西兰','NI':'尼加拉瓜','NE':'尼日尔','NG':'尼日利亚','NU':'纽埃','NF':'诺福克岛','MP':'北马里亚纳群岛','NO':'挪威','OM':'阿曼','PK':'巴基斯坦','PW':'帕劳','PA':'巴拿马','PG':'巴布亚新几内亚','PY':'巴拉圭','PE':'秘鲁','PH':'菲律宾','PN':'皮特凯恩群岛','PL':'波兰','PT':'葡萄牙','PR':'波多黎各','QA':'卡塔尔','RE':'留尼汪','RO':'罗马尼亚','TW':'台湾','RU':'俄罗斯','RW':'卢旺达','BL':'圣巴泰勒米','SH':'圣赫勒拿、阿森松和特里斯坦-达库尼亚','KN':'圣基茨和尼维斯','LC':'圣卢西亚','MF':'法属圣马丁','VC':'圣文森特和格林纳丁斯','WS':'萨摩亚','SM':'圣马力诺','ST':'圣多美和普林西比','SA':'沙特阿拉伯','SN':'塞内加尔','RS':'塞尔维亚','SC':'塞舌尔','SL':'塞拉利昂','SG':'新加坡','SX':'荷属圣马丁','SK':'斯洛伐克','SI':'斯洛文尼亚','SB':'所罗门群岛','SO':'索马里','ZA':'南非','GS':'南乔治亚和南桑威奇群岛','SS':'南苏丹','ES':'西班牙','LK':'斯里兰卡','SD':'苏丹','SR':'苏里南','PM':'圣皮埃尔和密克隆','SZ':'斯威士兰','SE':'瑞典','CH':'瑞士','SY':'叙利亚','TJ':'塔吉克斯坦','TZ':'坦桑尼亚','TH':'泰国','TL':'东帝汶','TG':'多哥','TK':'托克劳','TO':'汤加','TT':'特立尼达和多巴哥','TN':'突尼斯','TR':'土耳其','TM':'土库曼斯坦','TC':'特克斯和凯科斯群岛','TV':'图瓦卢','UG':'乌干达','UA':'乌克兰','AE':'阿联酋','GB':'英国','US':'美国','UM':'美国本土外小岛屿','UY':'乌拉圭','UZ':'乌兹别克斯坦','VU':'瓦努阿图','VE':'委内瑞拉','VN':'越南','VI':'美属维尔京群岛','WF':'瓦利斯和富图纳','PS':'巴勒斯坦','EH':'西撒哈拉','UN':'联合国','EU':'欧洲联盟','YE':'也门','ZA':'扎伊尔','ZM':'赞比亚','ZW':'津巴布韦','RO':'罗得西亚','WI':'西印度群岛联邦','EN':'独立国家联合体','AZ':'澳大拉西亚','YG':'南斯拉夫','UR':'苏联','DH':'达荷美','VL':'上沃尔特','BO':'波希米亚','TC':'捷克斯洛伐克','UA':'阿拉伯联合共和国','SG':'塞尔维亚和黑山'}
    rds = redis.StrictRedis(host='localhost', port=6379, db=0, charset='utf-8', decode_responses=True)
    re_country = re.compile(r'country\s*:\s*(.*)\n', re.I)
    re_description = re.compile(r'descr\s*:\s*(.*)\n', re.I)
    re_description2 = re.compile(r'(?:netname|organization|organisation|orgname|org-name|organization name|organisation name)\s*:\s*(.*)\n', re.I)
    result = {}
    for ip in ips:
        try:
            ipaddr = ipaddress.ip_address(ip)

            if rds.exists(ip):
                result[ip] = json.loads(rds.get(ip))
            else:
                cmd = f'whois {ip} 2> /dev/null | iconv -ct utf-8 2> /dev/null'
                rows = os.popen(cmd).readlines()

                country = list(set([country_dict.get(re_country.match(s).group(1).upper(), re_country.match(s).group(1).upper()) for s in rows if re_country.match(s)]))
                description = list(set([re_description.match(s).group(1) for s in rows if re_description.match(s)]))
                if len(description) == 0:
                    description = list(set([re_description2.match(s).group(1) for s in rows if re_description2.match(s)]))

                infos = {'country':country, 'description':description}
                if len(country) > 0 and len(description) > 0:
                    rds.set(ip, json.dumps(infos))  # 放入缓存
                    rds.expire(ip, 60*60*72)        # 72小时过期时间，或者永不过期，有另外一个脚本，每天夜里更新缓存的数据，这里先采用72小时过期时间试试
                result[ip] = infos
        except Exception as ex:
            exinfo = str(ex).splitlines()
            exinfo.insert(0, '异常，请联系管理员。')
            result[ip] = {'country':[], 'description':exinfo}

    print(json.dumps(result, sort_keys=True, indent=4, separators=(', ', ': ')))
else:
    print('{}')
