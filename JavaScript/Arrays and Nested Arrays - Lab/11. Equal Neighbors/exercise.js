
function solve(matrix) {
    let result = 0;

    for (let i = 0; i < matrix.length; i++) {

        for (let j = 0; j < matrix[i].length; j++) {

            if (matrix.length - 1 == i) {

                if (matrix[i][j] === matrix[i][j + 1]) {

                    result++;
                }
            }
            else {

                if (matrix[i][j] === matrix[i + 1][j]) {

                    result++;
                }

                if (matrix[i][j] === matrix[i][j + 1]) {

                    result++;
                }
            }
        }
    }

    return result;
}

console.log(solve([['2', '2', '5', '7', '4'],
['4', '0', '5', '3', '4'],
['2', '5', '5', '4', '2']]
));
console.log(solve([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]
));

