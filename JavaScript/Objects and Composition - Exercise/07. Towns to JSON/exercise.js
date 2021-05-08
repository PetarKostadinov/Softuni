
function solve(input) {

    let result = [];

    for (let i = 1; i < input.length; i++) {

        let [_, Town, Latitude, Longitude] = input[i].split(/\s*\|\s*/);

        Latitude = Number(Number(Latitude).toFixed(2));
        Longitude = Number(Number(Longitude).toFixed(2));

        let obj = {
            Town,
            Latitude,
            Longitude
        }

        result.push(obj);
    }
    2
    return JSON.stringify(result);
}

console.log(solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
));

