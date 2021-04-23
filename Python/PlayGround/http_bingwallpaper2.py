import requests
import json

BING_URI_BASE = "http://www.bing.com"
BING_WALLPAPER_PATH = "/HPImageArchive.aspx?format=js&idx=0&n=1&mkt=en-US"

# open the Bing HPImageArchive URI and ask for a JSON response
resp = requests.get(BING_URI_BASE + BING_WALLPAPER_PATH)

if resp.status_code == 200:
    json_response = json.loads(resp.content)
    wallpaper_path = json_response['images'][0]['url']
    filename = wallpaper_path.split('/')[-1]
    wallpaper_uri = BING_URI_BASE + wallpaper_path

    # open the actual wallpaper uri, and write the response as an image on the filesystem
    response = requests.get(wallpaper_uri)
    if resp.status_code == 200:
        with open(filename, 'wb') as f:
            f.write(response.content)
    else:
        raise ValueError(
            "[ERROR] non-200 response from Bing server for '{}'".format(wallpaper_uri))
else:
    raise ValueError(
        "[ERROR] non-200 response from Bing server for '{}'".format(BING_URI_BASE + BING_WALLPAPER_PATH))
