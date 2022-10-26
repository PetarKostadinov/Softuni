function ex6(arr) {

    const catalogue = {};

    arr.forEach((element) => {

        let [product, price] = element.split(' : ');

        price = Number(price);
        let letter = product[0];

        if (! catalogue[letter]) {

            catalogue[letter] = {}
        };

        catalogue[letter][product] = price;

    });

    let sorted = Object.keys(catalogue).sort((a, b) => a.localeCompare(b));

    for (const iterator of sorted) {
        let products = Object.entries(catalogue[iterator]).sort((a, b) => a[0].localeCompare(b[0]));

        console.log(iterator);

        products.forEach((el) => console.log(' ' + el[0] + ': ' + el[1]));
        
    }
 
};



ex6(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']);