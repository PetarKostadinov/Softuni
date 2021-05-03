function solve(array, num) {

    let element = 0;
    if(num >= array.length){

        num = Math.floor(num / array.length); // in case num is big number we dont need to rotate many times
    }

    for (let i = 0; i < num; i++) {

        element = array.pop();
        array.unshift(element);

    }
    return array.join(' ')
}

console.log(solve(['1',
    '2',
    '3',
    '4'],
    2));

console.log(solve(['Banana',
    'Orange',
    'Coconut',
    'Apple'],
    15));
