
function solve(input) {

    let result = [];

    for (let product of input) {

        let [name, price] = product.split(' : ');

        let obj = {
            name,
            price
        }
        result.push(obj);
    }

    result = result.sort((a, b) => a.name.localeCompare(b.name));

    let output = '';
    let currLetter = '';

    for (let element of result) {

        if (element.name[0] != currLetter) {

            currLetter = element.name[0];
            output += currLetter + '\n'
        }

        output += `${element.name}: ${element.price}` + '\n';
    }

    return output;
}

console.log(solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']));

