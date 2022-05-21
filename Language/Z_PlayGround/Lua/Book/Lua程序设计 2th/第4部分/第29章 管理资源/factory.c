#include <dirent.h>
#include <errno.h>

/* forward declaration for the iterator function */
static int dir_iter(lua_State *L);

static int l_dir(lua_State *L)
{
    const char *path = luaL_checkstring(L, 1);
    /* create a userdatum to store a DIR address */
    DIR **d = (DIR **)lua_newuserdata(L, sizeof(DIR *));
    /* set its metatable */
    luaL_getmetatable(L, "LuaBook.dir");
    lua_setmetatable(L, -2);
    /* try to open the given directory */
    *d = opendir(path);
    if (*d == NULL) /* error opening the directory? */
        luaL_error(L, "cannot open %s: %s", path, strerror(errno));
    /* creates and returns the iterator function;
    its sole upvalue, the directory userdatum,
    is already on the stack top */
    lua_pushcclosure(L, dir_iter, 1);
    return 1;
}