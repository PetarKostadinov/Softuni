function ex7(arr) {

    const result = [];

    let arrSplited = arr[0].split('|');

    let town = arrSplited[1].trim()
    let Latitude = arrSplited[2].trim()
    let Longitude = arrSplited[3].trim()

    for (let i = 1; i < arr.length; i++){

        const obj = {};

        const splEntry = arr[i].split('|');
        obj[town] = splEntry[1].trim();
        obj[Latitude] = Number(Number(splEntry[2].trim()).toFixed(2));
        obj[Longitude] = Number(Number(splEntry[3].trim()).toFixed(2));

        result.push(obj);

    };


    return JSON.stringify(result);
 
};

console.log(ex7(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
));