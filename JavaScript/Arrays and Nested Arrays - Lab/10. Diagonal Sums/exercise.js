
function solve(matrix) {

    let primariDiagonal = 0;
    let secondaryDiagonal = 0;
    let result = [];

    for (let i = 0; i < matrix.length; i++) {

        primariDiagonal += matrix[i][i];
        secondaryDiagonal += matrix[matrix.length - 1 - i][i];
    }

    result.push(primariDiagonal);
    result.push(secondaryDiagonal);

    return result.join(' ');
}

console.log(solve([[20, 40],
[10, 60]]
))
console.log(solve([[3, 5, 17],
[-1, 7, 14],
[1, -8, 89]]
));
