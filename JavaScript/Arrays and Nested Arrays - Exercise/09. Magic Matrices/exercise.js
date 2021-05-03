function solve(matrix) {

    return matrix
        .map(row => row
            .reduce((acc, c) => acc + c))
        .every((element, index, arr) => element === arr[0])
        && matrix
            .reduce((acc, c) => acc
                .map((element, index) => element + c[index]))
            .every((element, index, arr) => element === arr[0]);

}

console.log(solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
));
console.log(solve([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]
));

