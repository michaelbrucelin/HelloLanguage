#include <stdarg.h>

void call_va(const char *func, const char *sig, ...)
{
    va_list vl;
    int narg, nres; /* number of arguments and results */
    va_start(vl, sig);
    lua_getglobal(L, func); /* push function */
    for (narg = 0; *sig; narg++)
    { /* repeat for each argument */
        /* check stack space */
        luaL_checkstack(L, 1, "too many arguments");
        switch (*sig++)
        {
        case 'd': /* double argument */
            lua_pushnumber(L, va_arg(vl, double));
            break;
        case 'i': /* int argument */
            lua_pushinteger(L, va_arg(vl, int));
            break;
        case 's': /* string argument */
            lua_pushstring(L, va_arg(vl, char *));
            break;
        case '>': /* end of arguments */
            goto endargs;
        default:
            error(L, "invalid option (%c)", *(sig - 1));
        }
    }
endargs:

    nres = strlen(sig); /* number of expected results */
    /* do the call */
    if (lua_pcall(L, narg, nres, 0) != 0) /* do the call */
        error(L, "error calling '%s': %s", func, lua_tostring(L, -1));
    nres = -nres; /* stack index of first result */
    while (*sig)
    { /* repeat for each result */
        switch (*sig++)
        {
        case 'd': /* double result */
            if (!lua_isnumber(L, nres))
                error(L, "wrong result type");
            *va_arg(vl, double *) = lua_tonumber(L, nres);
            break;
        case 'i': /* int result */
            if (!lua_isnumber(L, nres))
                error(L, "wrong result type");
            *va_arg(vl, int *) = lua_tointeger(L, nres);
            break;
        case 's': /* string result */
            if (!lua_isstring(L, nres))
                error(L, "wrong result type");
            *va_arg(vl, const char **) = lua_tostring(L, nres);
            break;
        default:
            error(L, "invalid option (%c)", *(sig - 1));
        }
        nres++;
    }

    va_end(vl);
}