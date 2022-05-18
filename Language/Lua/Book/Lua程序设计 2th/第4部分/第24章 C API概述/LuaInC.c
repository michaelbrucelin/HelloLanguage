// A simple stand-alone Lua interpreter:
#include <stdio.h>
#include "lua.h"
#include "lauxlib.h"
#include "lualib.h"

int main(void)
{
    char buff[256];
    int error;
    lua_State *L = luaL_newstate();  /* 打开Lua */
    luaL_openlibs(L);                /* 打开标准库 */
    while (fgets(buff, sizeof(buff), stdin) != NULL)
    {
        error = luaL_loadbuffer(L, buff, strlen(buff), "line") ||
                lua_pcall(L, 0, 0, 0);
        if (error)
        {
            fprintf(stderr, "%s", lua_tostring(L, -1));
            lua_pop(L, 1);           /* 从栈中弹出错误信息 */
        }
    }
    lua_close(L);
    return 0;
}