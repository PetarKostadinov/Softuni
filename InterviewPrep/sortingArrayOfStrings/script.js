// Sort this array based on Numbers only
// There will be fixed first two chars for each element
// You're free to use native JS features
const arr = ["dg101", "az10", "xy01", "pp25", "tt93", "qy04", "xe001", "rq56"];
// expected output: ["xy01", "xe001", "qy04", "az10", "pp25", "rq56", "tt93", "dg101"]


console.log(arr.sort(function (a, b) {

    const newA = Number(a.slice(2));
    const newB = Number(b.slice(2));

    return newA - newB;
}));



