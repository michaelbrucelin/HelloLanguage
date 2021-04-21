// js将数据导出为csv
// https://stackoverflow.com/questions/14964035/how-to-export-javascript-array-info-to-csv-on-client-side

// 1. 数据生成
const rows = [
    ["name1", "city1", "some other info"],
    ["name2", "city2", "more info"]
];

let csvContent = "data:text/csv;charset=utf-8,";

rows.forEach(function (rowArray) {
    let row = rowArray.join(",");
    csvContent += row + "\r\n";
});

// or
const rows = [
    ["name1", "city1", "some other info"],
    ["name2", "city2", "more info"]
];

let csvContent = "data:text/csv;charset=utf-8,"
    + rows.map(e => e.join(",")).join("\n");

// 2. 导出csv
var encodedUri = encodeURI(csvContent);
window.open(encodedUri);

// or
var encodedUri = encodeURI(csvContent);
var link = document.createElement("a");
link.setAttribute("href", encodedUri);
link.setAttribute("download", "my_data.csv");
document.body.appendChild(link); // Required for FF

link.click(); // This will download the data file named "my_data.csv".