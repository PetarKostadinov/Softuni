
function solve(speed, area) {

    speed = Number(speed);
    let limit;

    if (area == 'motorway') {

        limit = 130;
    }
    else if (area == 'interstate') {

        limit = 90;
    }
    else if (area == 'city') {

        limit = 50;
    }
    else if (area == 'residential') {

        limit = 20;
    }

    if (speed <= limit) {

        return `Driving ${speed} km/h in a ${limit} zone`;
    }
    else {

        let difference = speed - limit;

        let status = difference <= 20 ? 'speeding'
                   : difference <= 40 ? 'excessive speeding'
                   : "reckless driving ";

        return `The speed is ${difference} km/h faster than the allowed speed of ${limit} - ${status}`
    }
}

console.log(solve(40, 'city'));
console.log(solve(21, 'residential'));
console.log(solve(120, 'interstate'));
console.log(solve(200, 'motorway'));