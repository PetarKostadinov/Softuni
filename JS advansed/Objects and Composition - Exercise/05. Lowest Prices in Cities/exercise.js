
function solve(input) {

    let result = {};

    for (let product of input) {

        let splitedProduct = product.split(' | ');

        let [town, name, price] = splitedProduct;

        price = Number(price);

        if (name in result == false) {

            result[name] = { town, price };

        }
        else if (result[name].price > price) {

            result[name].price = price;

            result[name].town = town;
        }
    }

    let output = '';

    for (let element in result) {

        output += `${element} -> ${result[element].price} (${result[element].town})` + '\n';
    }

    return output;
}

console.log(solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
));

