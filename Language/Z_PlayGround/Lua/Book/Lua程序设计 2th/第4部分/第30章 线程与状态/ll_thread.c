static void *ll_thread(void *arg)
{
    lua_State *L = (lua_State *)arg;
    luaL_openlibs(L);                   /* open standard libraries */
    lua_cpcall(L, luaopen_lproc, NULL); /* open lproc library */
    if (lua_pcall(L, 0, 0, 0) != 0)     /* call main chunk */
        fprintf(stderr, "thread error: %s", lua_tostring(L, -1));
    pthread_cond_destroy(&getself(L)->cond);
    lua_close(L);
    return NULL;
}