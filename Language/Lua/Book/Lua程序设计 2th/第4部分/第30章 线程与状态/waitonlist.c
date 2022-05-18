static void waitonlist(lua_State *L, const char *channel, Proc **list)
{
    Proc *p = getself(L);
    /* link itself at the end of the list */
    if (*list == NULL)
    { /* empty list? */
        *list = p;
        p->previous = p->next = p;
    }
    else
    {
        p->previous = (*list)->previous;
        p->next = *list;
        p->previous->next = p->next->previous = p;
    }
    p->channel = channel;
    do
    { /* waits on its condition variable */
        pthread_cond_wait(&p->cond, &kernel_access);
    } while (p->channel);
}