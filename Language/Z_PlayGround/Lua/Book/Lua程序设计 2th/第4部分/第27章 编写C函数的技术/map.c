int l_map(lua_State *L)
{
    int i, n;
    /* 1st argument must be a table (t) */
    luaL_checktype(L, 1, LUA_TTABLE);
    /* 2nd argument must be a function (f) */
    luaL_checktype(L, 2, LUA_TFUNCTION);
    n = lua_objlen(L, 1); /* get size of table */
    for (i = 1; i <= n; i++)
    {
        lua_pushvalue(L, 2);  /* push f */
        lua_rawgeti(L, 1, i); /* push t[i] */
        lua_call(L, 1, 1);    /* call f(t[i]) */
        lua_rawseti(L, 1, i); /* t[i] = result */
    }
    return 0; /* no results */
}