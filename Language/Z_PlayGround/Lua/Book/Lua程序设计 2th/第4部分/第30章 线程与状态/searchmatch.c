static Proc *searchmatch(const char *channel, Proc **list)
{
    Proc *node = *list;
    if (node == NULL)
        return NULL; /* empty list? */
    do
    {
        if (strcmp(channel, node->channel) == 0)
        { /* match? */
            /* remove node from the list */
            if (*list == node) /* is this node the first element? */
                *list = (node->next == node) ? NULL : node->next;
            node->previous->next = node->next;
            node->next->previous = node->previous;
            return node;
        }
        node = node->next;
    } while (node != *list);
    return NULL; /* no match */
}