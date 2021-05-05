
function solve(input) {

    let object = {};

    for (let i = 0; i < input.length; i++) {

        object[input[i]] = Number(input[++i])
    }

    return object;
}

console.log(solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));
console.log(solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']));