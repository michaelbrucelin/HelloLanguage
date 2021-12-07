require "rubygems"
require "sinatra"
require "json"

class App < Sinatra::Application
    set :bind, '0.0.0.0'

    get '/' do
        "<h1>DockerBook Test Sinatra app</h1>"
    end

    # 所有访问/json端点的POST请求参数都会被转换为JSON的格式后输出
    post '/json/?' do
        params.to_json
    end
end
