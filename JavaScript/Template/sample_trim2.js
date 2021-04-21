// js中实现trim
// https://stackoverflow.com/questions/26156292/trim-specific-character-from-a-string

function trimChar(s, c) {
    if (c === "]") c = "\\]";
    if (c === "\\") c = "\\\\";

    return s.replace(new RegExp("^[" + c + "]+|[" + c + "]+$", "g"), "");
}

function ltrimChar(s, c) {
    if (c === "]") c = "\\]";
    if (c === "\\") c = "\\\\";

    return s.replace(new RegExp("^[" + c + "]", "g"), "");
}

function rtrimChar(s, c) {
    if (c === "]") c = "\\]";
    if (c === "\\") c = "\\\\";

    return s.replace(new RegExp("[" + c + "]+$", "g"), "");
}