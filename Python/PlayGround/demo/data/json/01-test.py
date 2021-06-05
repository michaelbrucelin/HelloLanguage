import json
import requests
import sys

# 1. basic
strofjson = '{"name":"Zophie","isCat":true,"miceCaugth":0,"felineIQ":null}'
jsonObj = json.loads(strofjson)
jsonObj  # {'name': 'Zophie', 'isCat': True, 'miceCaugth': 0, 'felineIQ': None}
jsonStr = json.dumps(jsonObj)
jsonStr  # '{"name": "Zophie", "isCat": true, "miceCaugth": 0, "felineIQ": null}'
