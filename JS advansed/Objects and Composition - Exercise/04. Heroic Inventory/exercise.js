
function solve(heroes) {

    let splitedHeroes = [];
    let arrayResult = [];

    for (let hero of heroes) {

        splitedHeroes = hero.split(' / ');

        let [name, level, items] = splitedHeroes;

        level = Number(level);

        items = items ? items.split(', ') : [];

        const heroResult = {

            name,
            level,
            items
        }

        arrayResult[arrayResult.length] = heroResult;
    }

    return JSON.stringify(arrayResult);
}

console.log(solve(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
));
console.log(solve(['Jake / 1000 / Gauss, HolidayGrenade']));

