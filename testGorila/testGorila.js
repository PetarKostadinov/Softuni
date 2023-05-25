function calc(n, arr) {

    let response = [];
    const myArr = arr.slice(0, arr.length);

    if (n > arr.length) {

        return response;

    } else if (n <= 0) {

        response = arr.slice();

    } else {

        myArr.sort((a, b) => a - b);
        const set = [...new Set(myArr)]
        const toRemove = set.slice(0, n)

        for (let i = 0; i < toRemove.length; i++) {

            const index = arr.indexOf(toRemove[i]);
            arr.splice(index, 1);
        }
    }
    response = arr.slice();
    return response;
}
console.log(calc(1, [5, 3, 4, 1, 2, 2, 3, 5]));