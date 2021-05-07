merge targetTable as tar
using sourceTable as sour on tar.recid = sour.recid
    when matched
        then update set tar.c1 = sour.c1, tar.c2 = sour.c2, ......, tar.cn = sour.cn
    when not matched by target
        then insert(c1, c2, ......, cn)
             values(sour.c1, sour.c2, ......, sour.cn)
    when not matched by source
        then delete;
