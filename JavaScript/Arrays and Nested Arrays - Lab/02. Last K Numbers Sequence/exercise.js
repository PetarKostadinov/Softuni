
function solve(n, k) {

    let array = [1];
    const firstKvalue = k;

    for (let i = 0; i < n - 1; i++) {

        let sum = 0;

        k = firstKvalue;

        if (k > array.length) {

            k = array.length;
        }

        for (let f = array.length - 1; f > array.length - k - 1; f--) {

            sum += array[f];
        }

        array[array.length] = sum;
    }

    return array;
}
console.log(solve(9, 5))
console.log(solve(6, 3));
console.log(solve(8, 2));