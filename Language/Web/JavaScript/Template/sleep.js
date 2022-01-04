// js中的sleep使用示例
// https://stackoverflow.com/questions/951021/what-is-the-javascript-version-of-sleep

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

async function demo() {
    for (let i = 0; i < 5; i++) {
        console.log(i);
        await sleep(1000);
    }
}

demo();

// Or as a one-liner:
await new Promise(r => setTimeout(r, 2000));