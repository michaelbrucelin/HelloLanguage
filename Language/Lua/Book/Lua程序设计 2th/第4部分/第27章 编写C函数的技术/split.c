static int l_split(lua_State *L)
{
    const char *s = luaL_checkstring(L, 1);
    const char *sep = luaL_checkstring(L, 2);
    const char *e;
    int i = 1;
    lua_newtable(L); /* result */
    /* repeat for each separator */
    while ((e = strchr(s, *sep)) != NULL)
    {
        lua_pushlstring(L, s, e - s); /* push substring */
        lua_rawseti(L, -2, i++);
        s = e + 1; /* skip separator */
    }
    /* push last substring */
    lua_pushstring(L, s);
    lua_rawseti(L, -2, i);
    return 1; /* return the table */
}