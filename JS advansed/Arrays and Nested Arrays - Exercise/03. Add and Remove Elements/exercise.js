function solve(array) {

    let result = [];

    let num = 1;

    for (let command of array) {

        if (command === 'add') {
            result.push(num)
        }
        else {
            result.pop();
        }
        num++;
    }

    return result.length == 0 ? 'Empty' : result.join('\n');

}

console.log(solve(['add',
    'add',
    'add',
    'add']));

console.log(solve(['remove',
    'remove',
    'remove']));

console.log(solve(['add',
    'add',
    'remove',
    'add',
    'add']));




