// 从url中获取参数与其对应的值
// https://stackoverflow.com/questions/979975/get-the-values-from-the-get-parameters-javascript

/*
JavaScript itself has nothing built in for handling query string parameters.
Code running in a (modern) browser you can use the URL object (which is part of the APIs provided by browsers to JS):
*/

var url_string = "http://www.example.com/t.html?a=1&b=3&c=m2-m3-m4-m5"; //window.location.href
var url = new URL(url_string);
var c = url.searchParams.get("c");
console.log(c);

/*
For older browsers (including Internet Explorer), you can use this polyfill or the code from the original version of this answer that predates URL:
You could access location.search, which would give you from the ? character on to the end of the URL or the start of the fragment identifier (#foo), whichever comes first.
Then you can parse it with this:
*/

function parse_query_string(query) {
    var vars = query.split("&");
    var query_string = {};
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        var key = decodeURIComponent(pair[0]);
        var value = decodeURIComponent(pair[1]);
        // If first entry with this name
        if (typeof query_string[key] === "undefined") {
            query_string[key] = decodeURIComponent(value);
            // If second entry with this name
        } else if (typeof query_string[key] === "string") {
            var arr = [query_string[key], decodeURIComponent(value)];
            query_string[key] = arr;
            // If third or later entry with this name
        } else {
            query_string[key].push(decodeURIComponent(value));
        }
    }
    return query_string;
}

var query_string = "a=1&b=3&c=m2-m3-m4-m5";
var parsed_qs = parse_query_string(query_string);
console.log(parsed_qs.c);

/*
You can get the query string from the URL of the current page with:
*/

var query = window.location.search.substring(1);
var qs = parse_query_string(query);
