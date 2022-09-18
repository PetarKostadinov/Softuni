function ex4(arr) {

        let result = [];

    arr.forEach(el =>{

        let [name, level, items] = el.split(' / ');

        result.push({
            name,
            level: Number(level),
            items: items? items.split(', '): []

        });

    });

    console.log(JSON.stringify(result));
  

};



ex4(['Isacc / 25 / Apple, GravityGun',

'Derek / 12 / BarrelVest, DestructionSword',

'Hes / 1 / Desolator, Sentinel, Antara']);