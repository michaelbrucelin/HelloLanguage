static int ll_send(lua_State *L)
{
    Proc *p;
    const char *channel = luaL_checkstring(L, 1);
    pthread_mutex_lock(&kernel_access);
    p = searchmatch(channel, &waitreceive);
    if (p)
    {                                  /* found a matching receiver? */
        movevalues(L, p->L);           /* move values to receiver */
        p->channel = NULL;             /* mark receiver as not waiting */
        pthread_cond_signal(&p->cond); /* wake it up */
    }
    else
        waitonlist(L, channel, &waitsend);
    pthread_mutex_unlock(&kernel_access);
    return 0;
}

static int ll_receive(lua_State *L)
{
    Proc *p;
    const char *channel = luaL_checkstring(L, 1);
    lua_settop(L, 1);
    pthread_mutex_lock(&kernel_access);
    p = searchmatch(channel, &waitsend);
    if (p)
    {                                  /* found a matching sender? */
        movevalues(p->L, L);           /* get values from sender */
        p->channel = NULL;             /* mark sender as not waiting */
        pthread_cond_signal(&p->cond); /* wake it up */
    }
    else
        waitonlist(L, channel, &waitreceive);
    pthread_mutex_unlock(&kernel_access);
    /* return all stack values but channel */
    return lua_gettop(L) - 1;
}