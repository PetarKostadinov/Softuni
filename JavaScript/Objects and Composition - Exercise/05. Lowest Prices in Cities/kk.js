function ex5(arr) {

    let catalogue = {};

    arr.forEach(element => {
        
        let[town, product, price] = element.split(' | ');
        
        price = Number(price);

        if (!catalogue[product]){

            catalogue[product] = {};

        };


            catalogue[product][town]= price;
    });


    for (const key in catalogue) {
        
        const sorted = Object.entries(catalogue[key]).sort((a, b) => a[1] - b[1] )

        console.log(`${key} -> ${sorted[0][1]} (${sorted[0][0]})`)
    }

};



ex5(['Sample Town | Sample Product | 1000',

'Sample Town | Orange | 2',

'Sample Town | Peach | 1',

'Sofia | Orange | 3',

'Sofia | Peach | 2',

'New York | Sample Product | 1000.1',

'New York | Burger | 10']);