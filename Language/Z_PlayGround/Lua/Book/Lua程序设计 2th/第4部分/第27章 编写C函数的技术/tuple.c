int t_tuple(lua_State *L)
{
    int op = luaL_optint(L, 1, 0);
    if (op == 0)
    { /* no arguments? */
        int i;
        /* push each valid upvalue onto the stack */
        for (i = 1; !lua_isnone(L, lua_upvalueindex(i)); i++)
            lua_pushvalue(L, lua_upvalueindex(i));
        return i - 1; /* number of values in the stack */
    }
    else
    { /* get field 'op' */
        luaL_argcheck(L, 0 < op, 1, "index out of range");
        if (lua_isnone(L, lua_upvalueindex(op)))
            return 0; /* no such field */
        lua_pushvalue(L, lua_upvalueindex(op));
        return 1;
    }
}

int t_new(lua_State *L)
{
    lua_pushcclosure(L, t_tuple, lua_gettop(L));
    return 1;
}

static const struct luaL_Reg tuplelib[] = {
    {"new", t_new},
    {NULL, NULL}};

int luaopen_tuple(lua_State *L)
{
    luaL_register(L, "tuple", tuplelib);
    return 1;
}