static int ll_start(lua_State *L)
{
    pthread_t thread;
    const char *chunk = luaL_checkstring(L, 1);
    lua_State *L1 = luaL_newstate();
    if (L1 == NULL)
        luaL_error(L, "unable to create new state");
    if (luaL_loadstring(L1, chunk) != 0)
        luaL_error(L, "error starting thread: %s", lua_tostring(L1, -1));
    if (pthread_create(&thread, NULL, ll_thread, L1) != 0)
        luaL_error(L, "unable to create new thread");
    pthread_detach(thread);
    return 0;
}