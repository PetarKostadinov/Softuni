
function city(input) {

    const cityObj = {};

    for (let singleCity of input) {

        let tokens = singleCity.split(' <-> ')

        let name = tokens[0];
        let population = Number(tokens[1]);

        if (cityObj[name] != undefined) {

            cityObj[name] += population;
        }
        else {

            cityObj[name] = population;
        }
    }
    for (let name in cityObj) {

        console.log(`${name} : ${cityObj[name]}`)
    }
}

city(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']
)
city(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']
)
