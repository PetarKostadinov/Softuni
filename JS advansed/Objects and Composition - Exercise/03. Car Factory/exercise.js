
function solve(object) {

    const components = {

        engine: {

            'Small engine': { power: 90, volume: 1800 },
            'Normal engine': { power: 120, volume: 2400 },
            'Monster engine': { power: 200, volume: 3500 }
        },
        carriage: {
            Hatchback: { type: 'hatchback', color: '' },
            Coupe: { type: 'coupe', color: '' }
        }
    }

    let engine = {};

    if (object.power <= 90) {

        engine = components.engine['Small engine'];
    }
    else if (object.power <= 120) {

        engine = components.engine['Normal engine'];
    }
    else {

        engine = components.engine['Monster engine'];
    }

    let carriage = {};

    if (object.carriage === 'hatchback') {

        carriage = components.carriage['Hatchback'];
    }
    else {

        carriage = components.carriage['Coupe'];
    }

    carriage.color = object.color;

    let wheel = {};

    if (Number(object.wheelsize) % 2 === 0) {

        wheel = object.wheelsize - 1;
    }
    else {

        wheel = object.wheelsize;
    }

    const car = {
        model: object.model,
        engine,
        carriage,
        wheels: [wheel, wheel, wheel, wheel]
    }

    return car;
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));
console.log(solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}
));

