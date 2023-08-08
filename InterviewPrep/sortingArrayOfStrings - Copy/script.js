// Sort this array based on Numbers only
// There will be fixed first two chars for each element
// You're free to use native JS features
// const arr = ["dg101", "az10", "xy01", "pp25", "tt93", "qy04", "xe001", "rq56"];
// // expected output: ["xy01", "xe001", "qy04", "az10", "pp25", "rq56", "tt93", "dg101"]


// console.log(arr.sort(function (a, b) {

//     const newA = Number(a.slice(2));
//     const newB = Number(b.slice(2));

//     return newA - newB;
// }));


function factorial(n) {
    if (n === 0) {
        return 1
    }
    return n * factorial(n - 1)
}
console.log(factorial(5))

//binari search
function binariSearch() {
    let arr = [1, 2, 3, 4, 5, 6, 7]
    let target = 8
    let start = 0
    let end = arr.length - 1
    let mid = Math.floor((start + end) / 2)
    while (arr[mid] !== target && start <= end) {
        if (target < arr[mid]) {
            end = mid - 1
        } else {
            start = mid + 1
        }
        mid = Math.floor((start + end) / 2)
    }
    return arr[mid] === target ? mid : -1
}

console.log(binariSearch())

console.log()





